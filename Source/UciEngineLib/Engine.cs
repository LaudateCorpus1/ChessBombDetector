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

        private Task _eventProcessorTask;

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
                Event ev = Event.CreateFromStream(new StringReader(line));
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
