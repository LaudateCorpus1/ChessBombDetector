using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UciEngineLib
{
    public struct EnginePositionDef
    {
        public bool StartPos { get; set; }
        public string Fen { get; set; }

        public override string ToString()
        {
          return StartPos ? "startpos" : String.Format("fen {0}", Fen);
        }
    }

}
