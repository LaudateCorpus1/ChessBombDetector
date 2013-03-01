using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessBombDetector.Fields;

namespace ChessBombDetector
{
  class InfoUciEventData : UciEventData<InfoUciEventFieldId>
  {

    private static void RegisterFields()
    {
      RegisterField<IntegerUciEventField>(InfoUciEventFieldId.Depth);
      RegisterField<IntegerUciEventField>(InfoUciEventFieldId.SelDepth);
      RegisterField<IntegerUciEventField>(InfoUciEventFieldId.Time);
      RegisterField<IntegerUciEventField>(InfoUciEventFieldId.Nodes);
      // RegisterField<IntegerUciEventField>(InfoUciEventFieldId.Pv);
      RegisterField<IntegerUciEventField>(InfoUciEventFieldId.MultiPv);
      // RegisterField<IntegerUciEventField>(InfoUciEventFieldId.Score);
      RegisterField<WordUciEventField>(InfoUciEventFieldId.CurrMove);
      RegisterField<IntegerUciEventField>(InfoUciEventFieldId.CurrMoveNumber);
      RegisterField<IntegerUciEventField>(InfoUciEventFieldId.HashFull);
      RegisterField<IntegerUciEventField>(InfoUciEventFieldId.Nps);
      RegisterField<IntegerUciEventField>(InfoUciEventFieldId.TbHits);
      RegisterField<IntegerUciEventField>(InfoUciEventFieldId.CpuLoad);
      RegisterField<StringUciEventField>(InfoUciEventFieldId.String);
      // RegisterField<IntegerUciEventField>(InfoUciEventFieldId.Refutation);
      // RegisterField<IntegerUciEventField>(InfoUciEventFieldId.CurrLine);
    }

    static InfoUciEventData()
    {
      RegisterFields();
    }
  }
}
