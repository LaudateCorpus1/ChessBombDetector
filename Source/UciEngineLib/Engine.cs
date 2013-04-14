using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UciEngineLib.Events;
using UciEngineLib.Utils;
using log4net;

namespace UciEngineLib
{
    public class Engine : IEngine, IDisposable
    {

        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly StreamReader _reader;

        private readonly StreamWriter _writer;

        private readonly Task _eventProcessorTask;

        private static readonly EngineEventParser _eventParser = new EngineEventParser();

        private static readonly EngineEventDispatcher _eventDispatcher =
                new EngineEventDispatcher();

        private static void RegisterEventType<TEventType>(EventType eventType, Action<object, TEventType> eventHandler) where TEventType : Event, new()
        {
            _eventParser.RegisterEventType<TEventType>(eventType);
            _eventDispatcher.RegisterEventType(eventType, eventHandler);
        }

        static Engine()
        {
            RegisterEventType<IdEvent>(EventType.Id, (sender, ev) => ((Engine)sender).IdEvent(sender, ev));
            RegisterEventType<UciOkEvent>(EventType.UciOk, (sender, ev) => ((Engine)sender).UciOkEvent(sender, ev));
            RegisterEventType<ReadyOkEvent>(EventType.ReadyOk, (sender, ev) => ((Engine)sender).ReadyOkEvent(sender, ev));
            RegisterEventType<BestMoveEvent>(EventType.BestMove, (sender, ev) => ((Engine)sender).BestMoveEvent(sender, ev));
            RegisterEventType<CopyProtectionEvent>(EventType.CopyProtection, (sender, ev) => ((Engine)sender).CopyProtectionEvent(sender, ev));
            RegisterEventType<RegistrationEvent>(EventType.Registration, (sender, ev) => ((Engine)sender).RegistrationEvent(sender, ev));
            RegisterEventType<InfoEvent>(EventType.Info, (sender, ev) => ((Engine)sender).InfoEvent(sender, ev));
            RegisterEventType<OptionEvent>(EventType.Option, (sender, ev) => ((Engine)sender).OptionEvent(sender, ev));
        }

        public Engine(StreamReader reader, StreamWriter writer)
        {
            _reader = reader;
            _writer = writer;
            _eventProcessorTask = new Task(ProcessEvents);
        }

        public void Run()
        {
            _eventProcessorTask.Start();
        }

        private void ProcessEvents()
        {
            string line;
            while ((line = _reader.ReadLine()) != null)
            {
                try
                {
                    _eventDispatcher.HandleEvent(this, _eventParser.ParseEvent(line));
                }
                catch (Exception e)
                {
                    ExceptionEvent(this, new Tuple<string, Exception>(line, e));
                }
            }

        }

        public void SetPosition(EnginePositionDef position, string[] moves)
        {
            string movesStr = moves.Length > 0 ? String.Format("moves {0}", String.Join(" ", moves)) : "";
            _writer.WriteLine(String.Join(" ", "position", position, movesStr));
        }

        public void SetOption(string name, string value)
        {
            _writer.WriteLine("go");
        }

        public void Go()
        {
            _writer.WriteLine("go");
        }

        public void Stop()
        {
            _writer.WriteLine("stop");
        }

        public void Quit()
        {
            _writer.WriteLine("quit");
        }

        public event EventHandler<EventArgs<IdEvent>> IdEvent = delegate { };
        public event EventHandler<EventArgs<UciOkEvent>> UciOkEvent = delegate { };
        public event EventHandler<EventArgs<ReadyOkEvent>> ReadyOkEvent = delegate { };
        public event EventHandler<EventArgs<BestMoveEvent>> BestMoveEvent = delegate { };
        public event EventHandler<EventArgs<CopyProtectionEvent>> CopyProtectionEvent = delegate { };
        public event EventHandler<EventArgs<RegistrationEvent>> RegistrationEvent = delegate { };
        public event EventHandler<EventArgs<InfoEvent>> InfoEvent = delegate { };
        public event EventHandler<EventArgs<OptionEvent>> OptionEvent = delegate { };
        public event EventHandler<EventArgs<Tuple<string, Exception>>> ExceptionEvent = delegate { };

        public void WaitForEventProcessor()
        {
            _eventProcessorTask.Wait();
        }

        public void Dispose()
        {
            WaitForEventProcessor();
        }
    }
}
