using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBombDetector.Events
{
    public class ReadyOkEvent: Event
    {
        public ReadyOkEvent() : base(EventType.ReadyOk)
        {
        }
    }
}
