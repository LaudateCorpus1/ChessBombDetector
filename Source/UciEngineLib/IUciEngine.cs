using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBombDetector
{
    class UciInfoEventArgs : EventArgs
    {
        public UciEvent Data { get; set; }
    }
    
    interface IUciEngine
    {
        void SetPosition(UciEnginePositionDef position, string[] moves);
        void SetOption(string name, string value);
        void Go();
        void Stop();
        void Quit();
        event EventHandler<UciInfoEventArgs> InfoEvent;
    }
}
