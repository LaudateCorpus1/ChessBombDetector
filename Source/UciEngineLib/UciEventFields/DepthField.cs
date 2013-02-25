using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBombDetector.UciEventFields
{
    [UciFieldId("depth")]
    public class DepthField : UciEventField
    {
        public int Depth { get; set; }
    }
}
