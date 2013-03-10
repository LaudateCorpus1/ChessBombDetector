using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBombDetector.Events
{
    public class CopyProtectionEvent: Event
    {
        public CopyProtectionEvent() : base(EventType.CopyProtection)
        {
        }
    }
}
