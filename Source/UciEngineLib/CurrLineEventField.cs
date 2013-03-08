using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessBombDetector.Fields;

namespace ChessBombDetector
{
    class CurrLineEventField : UciEventField
    {
        protected override void ReadFromStream(StringReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
