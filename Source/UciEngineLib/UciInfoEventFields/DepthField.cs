using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBombDetector.UciInfoEventFields
{
    [UciFieldId("depth")]
    public class DepthField : UciInfoEventField
    {
        public int Depth { get; set; }
    }
}
