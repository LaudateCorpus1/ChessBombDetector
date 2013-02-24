using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBombDetector.UciInfoEventFields
{
    public class DepthField : UciInfoEventField
    {
        public int Depth { get; set; }

        public override string Id
        {
            get { return "depth"; }
        }
    }
}
