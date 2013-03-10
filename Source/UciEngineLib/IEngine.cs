using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessBombDetector.Events;
using ChessBombDetector.Utils;

namespace ChessBombDetector
{
    interface IEngine
    {
        void SetPosition(EnginePositionDef position, string[] moves);
        void SetOption(string name, string value);
        void Go();
        void Stop();
        void Quit();
        event EventHandler<EventArgs<IdEvent>> IdEvent;
        event EventHandler<EventArgs<UciOkEvent>> UciOkEvent;
        event EventHandler<EventArgs<ReadyOkEvent>> ReadyOkEvent;
        event EventHandler<EventArgs<BestMoveEvent>> BestMoveEvent;
        event EventHandler<EventArgs<CopyProtectionEvent>> CopyProtectionEvent;
        event EventHandler<EventArgs<RegistrationEvent>> RegistrationEvent;
        event EventHandler<EventArgs<InfoEvent>> InfoEvent;
        event EventHandler<EventArgs<OptionEvent>> OptionEvent;
    }
}
