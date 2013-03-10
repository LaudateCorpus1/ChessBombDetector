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
    public class Engine: IEngine
    {
        
        private readonly StreamReader _reader;

        private readonly StreamWriter _writer;

        public Engine(StreamReader reader, StreamWriter writer)
        {
            _reader = reader;
            _writer = writer;
        }

        public void SetPosition(EnginePositionDef position, string[] moves)
        {
            throw new NotImplementedException();
        }

        public void SetOption(string name, string value)
        {
            throw new NotImplementedException();
        }

        public void Go()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public void Quit()
        {
            throw new NotImplementedException();
        }

        public event EventHandler<EventArgs<IdEvent>> IdEvent;
        public event EventHandler<EventArgs<UciOkEvent>> UciOkEvent;
        public event EventHandler<EventArgs<ReadyOkEvent>> ReadyOkEvent;
        public event EventHandler<EventArgs<BestMoveEvent>> BestMoveEvent;
        public event EventHandler<EventArgs<CopyProtectionEvent>> CopyProtectionEvent;
        public event EventHandler<EventArgs<RegistrationEvent>> RegistrationEvent;
        public event EventHandler<EventArgs<InfoEvent>> InfoEvent;
        public event EventHandler<EventArgs<OptionEvent>> OptionEvent;

    }
}
