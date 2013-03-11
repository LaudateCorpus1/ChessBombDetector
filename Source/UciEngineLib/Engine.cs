using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessBombDetector.Events;
using ChessBombDetector.Utils;

namespace ChessBombDetector
{
    public class Engine: IEngine, IDisposable
    {
        
        private readonly StreamReader _reader;

        private readonly StreamWriter _writer;

        private readonly Task _eventProcessorTask;

        private static Dictionary<EventType, Func<Event>> _eventFactoryRegistry =
                new Dictionary<EventType, Func<Event>>();

        private static Event CreateEvent(EventType type)
        {
          return _eventFactoryRegistry[type]();
        }

      static Engine()
      {
        _eventFactoryRegistry.Add(EventType.Id, () => new IdEvent());
        _eventFactoryRegistry.Add(EventType.UciOk, () => new UciOkEvent());
        _eventFactoryRegistry.Add(EventType.ReadyOk, () => new ReadyOkEvent());
        _eventFactoryRegistry.Add(EventType.BestMove, () => new BestMoveEvent());
        _eventFactoryRegistry.Add(EventType.CopyProtection, () => new CopyProtectionEvent());
        _eventFactoryRegistry.Add(EventType.Registration, () => new RegistrationEvent());
        _eventFactoryRegistry.Add(EventType.Info, () => new InfoEvent());
        _eventFactoryRegistry.Add(EventType.Option, () => new OptionEvent());
      }

      public static Event ParseEvent(StringReader reader)
      {
        EventType eventType = EnumDescriptionToValueMapper<EventType>.GetValueByDescription(reader.ReadWord());
        Event res = CreateEvent(eventType);
        res.ReadFromStream(reader);
        return res;
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
                Event ev = ParseEvent(new StringReader(line));
                switch (ev.Type)
                {
                        case EventType.Id: 
                            IdEvent.Invoke(this, (IdEvent) ev);
                            break;
                        case EventType.UciOk:
                            UciOkEvent.Invoke(this, (UciOkEvent) ev);
                            break;
                        case EventType.ReadyOk:
                            ReadyOkEvent.Invoke(this, (ReadyOkEvent) ev);
                            break;
                        case EventType.BestMove:
                            BestMoveEvent.Invoke(this, (BestMoveEvent) ev);
                            break;
                        case EventType.CopyProtection:
                            CopyProtectionEvent.Invoke(this, (CopyProtectionEvent) ev);
                            break;
                        case EventType.Registration:
                            RegistrationEvent.Invoke(this, (RegistrationEvent) ev);
                            break;
                        case EventType.Info:
                            InfoEvent.Invoke(this, (InfoEvent) ev);
                            break;
                        case EventType.Option:
                            OptionEvent.Invoke(this, (OptionEvent) ev);
                            break;
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

        public event EventHandler<EventArgs<IdEvent>> IdEvent;
        public event EventHandler<EventArgs<UciOkEvent>> UciOkEvent;
        public event EventHandler<EventArgs<ReadyOkEvent>> ReadyOkEvent;
        public event EventHandler<EventArgs<BestMoveEvent>> BestMoveEvent;
        public event EventHandler<EventArgs<CopyProtectionEvent>> CopyProtectionEvent;
        public event EventHandler<EventArgs<RegistrationEvent>> RegistrationEvent;
        public event EventHandler<EventArgs<InfoEvent>> InfoEvent;
        public event EventHandler<EventArgs<OptionEvent>> OptionEvent;

        public void Dispose()
        {
            _eventProcessorTask.Wait();
        }
    }
}
