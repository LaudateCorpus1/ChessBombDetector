using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBombDetector.Events
{
    class OptionEvent: ComplexEvent<OptionEventFieldType>
    {
        public OptionEvent() : base(EventType.Option)
        {
        }
    }

}
