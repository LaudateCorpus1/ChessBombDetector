using ChessBombDetector.EventFields;

namespace ChessBombDetector.Events
{
  class InfoUciEventData : UciEventData<InfoUciEventFieldId>
  {

    private static void RegisterFields()
    {
        RegisterField<IntegerUciEventField>(InfoUciEventFieldId.Depth,
          (data, field) => ((InfoUciEventData)data).Depth = field);
        RegisterField<IntegerUciEventField>(InfoUciEventFieldId.SelDepth,
          (data, field) => ((InfoUciEventData)data).SelDepth = field);
        RegisterField<IntegerUciEventField>(InfoUciEventFieldId.Time,
          (data, field) => ((InfoUciEventData)data).Time = field);
        RegisterField<IntegerUciEventField>(InfoUciEventFieldId.Nodes,
          (data, field) => ((InfoUciEventData)data).Nodes = field);
        RegisterField<VariationEventField>(InfoUciEventFieldId.Pv,
          (data, field) => ((InfoUciEventData)data).Pv = field);
        RegisterField<IntegerUciEventField>(InfoUciEventFieldId.MultiPv,
          (data, field) => ((InfoUciEventData)data).MultiPv = field);
        RegisterField<ScoreEventField>(InfoUciEventFieldId.Score,
          (data, field) => ((InfoUciEventData)data).Score = field);
        RegisterField<WordUciEventField>(InfoUciEventFieldId.CurrMove,
          (data, field) => ((InfoUciEventData)data).CurrMove = field);
        RegisterField<IntegerUciEventField>(InfoUciEventFieldId.CurrMoveNumber,
          (data, field) => ((InfoUciEventData)data).CurrMoveNumber = field);
        RegisterField<IntegerUciEventField>(InfoUciEventFieldId.HashFull,
          (data, field) => ((InfoUciEventData)data).HashFull = field);
        RegisterField<IntegerUciEventField>(InfoUciEventFieldId.Nps,
          (data, field) => ((InfoUciEventData)data).Nps = field);
        RegisterField<IntegerUciEventField>(InfoUciEventFieldId.TbHits,
          (data, field) => ((InfoUciEventData)data).TbHits = field);
        RegisterField<IntegerUciEventField>(InfoUciEventFieldId.CpuLoad,
          (data, field) => ((InfoUciEventData)data).CpuLoad = field);
        RegisterField<StringUciEventField>(InfoUciEventFieldId.String,
          (data, field) => ((InfoUciEventData)data).String = field);
        RegisterField<VariationEventField>(InfoUciEventFieldId.Refutation,
          (data, field) => ((InfoUciEventData)data).Refutation = field);
        RegisterField<CurrLineEventField>(InfoUciEventFieldId.CurrLine,
          (data, field) => ((InfoUciEventData)data).CurrLine = field);
    }

    static InfoUciEventData()
    {
      RegisterFields();
    }

    public IntegerUciEventField Depth { get; private set; }
    public IntegerUciEventField SelDepth { get; private set; }
    public IntegerUciEventField Time { get; private set; }
    public IntegerUciEventField Nodes { get; private set; }
    public VariationEventField Pv { get; private set; }
    public IntegerUciEventField MultiPv { get; private set; }
    public ScoreEventField Score { get; private set; }
    public WordUciEventField CurrMove { get; private set; }
    public IntegerUciEventField CurrMoveNumber { get; private set; }
    public IntegerUciEventField HashFull { get; private set; }
    public IntegerUciEventField Nps { get; private set; }
    public IntegerUciEventField TbHits { get; private set; }
    public IntegerUciEventField CpuLoad { get; private set; }
    public StringUciEventField String { get; private set; }
    public VariationEventField Refutation { get; private set; }
    public CurrLineEventField CurrLine { get; private set; }
  }
}
