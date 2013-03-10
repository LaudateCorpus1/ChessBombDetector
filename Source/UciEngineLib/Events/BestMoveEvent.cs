using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBombDetector.Events
{
    class BestMoveEvent: Event
    {
        public BestMoveEvent() : base(EventType.BestMove)
        {
        }
    }
}
