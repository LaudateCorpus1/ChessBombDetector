using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessBombDetector.Events;

namespace ChessBombDetector
{
    class UciInfoEventArgs : EventArgs
    {
        public InfoEventData Data { get; set; }
    }
    
    interface IEngine
    {
        void SetPosition(EnginePositionDef position, string[] moves);
        void SetOption(string name, string value);
        void Go();
        void Stop();
        void Quit();
        event EventHandler<UciInfoEventArgs> InfoEvent;
    }
}
