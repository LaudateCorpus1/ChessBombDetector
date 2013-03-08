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
      RegisterField<IntegerUciEventField>(InfoUciEventFieldId.Depth,
        (data, field) => ((InfoUciEventData) data).Depth = field);
      RegisterField<IntegerUciEventField>(InfoUciEventFieldId.SelDepth);
      RegisterField<IntegerUciEventField>(InfoUciEventFieldId.Time);
      RegisterField<IntegerUciEventField>(InfoUciEventFieldId.Nodes);
      RegisterField<VariationEventField>(InfoUciEventFieldId.Pv);
      RegisterField<IntegerUciEventField>(InfoUciEventFieldId.MultiPv);
      RegisterField<ScoreEventField>(InfoUciEventFieldId.Score);
      RegisterField<WordUciEventField>(InfoUciEventFieldId.CurrMove);
      RegisterField<IntegerUciEventField>(InfoUciEventFieldId.CurrMoveNumber);
      RegisterField<IntegerUciEventField>(InfoUciEventFieldId.HashFull);
      RegisterField<IntegerUciEventField>(InfoUciEventFieldId.Nps);
      RegisterField<IntegerUciEventField>(InfoUciEventFieldId.TbHits);
      RegisterField<IntegerUciEventField>(InfoUciEventFieldId.CpuLoad);
      RegisterField<StringUciEventField>(InfoUciEventFieldId.String);
      RegisterField<VariationEventField>(InfoUciEventFieldId.Refutation);
      RegisterField<CurrLineEventField>(InfoUciEventFieldId.CurrLine);
    }

    static InfoUciEventData()
    {
      RegisterFields();
    }

      public IntegerUciEventField Depth { get; private set; }
  }
}
