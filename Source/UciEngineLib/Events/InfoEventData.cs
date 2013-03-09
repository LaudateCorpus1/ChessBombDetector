using ChessBombDetector.EventFields;

namespace ChessBombDetector.Events
{
  class InfoEventData : UciEventData<InfoEventFieldId>
  {

    private static void RegisterFields()
    {
        RegisterField<IntegerEventField>(InfoEventFieldId.Depth,
          (data, field) => ((InfoEventData)data).Depth = field);
        RegisterField<IntegerEventField>(InfoEventFieldId.SelDepth,
          (data, field) => ((InfoEventData)data).SelDepth = field);
        RegisterField<IntegerEventField>(InfoEventFieldId.Time,
          (data, field) => ((InfoEventData)data).Time = field);
        RegisterField<IntegerEventField>(InfoEventFieldId.Nodes,
          (data, field) => ((InfoEventData)data).Nodes = field);
        RegisterField<VariationEventField>(InfoEventFieldId.Pv,
          (data, field) => ((InfoEventData)data).Pv = field);
        RegisterField<IntegerEventField>(InfoEventFieldId.MultiPv,
          (data, field) => ((InfoEventData)data).MultiPv = field);
        RegisterField<ScoreEventField>(InfoEventFieldId.Score,
          (data, field) => ((InfoEventData)data).Score = field);
        RegisterField<WordEventField>(InfoEventFieldId.CurrMove,
          (data, field) => ((InfoEventData)data).CurrMove = field);
        RegisterField<IntegerEventField>(InfoEventFieldId.CurrMoveNumber,
          (data, field) => ((InfoEventData)data).CurrMoveNumber = field);
        RegisterField<IntegerEventField>(InfoEventFieldId.HashFull,
          (data, field) => ((InfoEventData)data).HashFull = field);
        RegisterField<IntegerEventField>(InfoEventFieldId.Nps,
          (data, field) => ((InfoEventData)data).Nps = field);
        RegisterField<IntegerEventField>(InfoEventFieldId.TbHits,
          (data, field) => ((InfoEventData)data).TbHits = field);
        RegisterField<IntegerEventField>(InfoEventFieldId.CpuLoad,
          (data, field) => ((InfoEventData)data).CpuLoad = field);
        RegisterField<StringEventField>(InfoEventFieldId.String,
          (data, field) => ((InfoEventData)data).String = field);
        RegisterField<VariationEventField>(InfoEventFieldId.Refutation,
          (data, field) => ((InfoEventData)data).Refutation = field);
        RegisterField<CurrLineEventField>(InfoEventFieldId.CurrLine,
          (data, field) => ((InfoEventData)data).CurrLine = field);
    }

    static InfoEventData()
    {
      RegisterFields();
    }

    public IntegerEventField Depth { get; private set; }
    public IntegerEventField SelDepth { get; private set; }
    public IntegerEventField Time { get; private set; }
    public IntegerEventField Nodes { get; private set; }
    public VariationEventField Pv { get; private set; }
    public IntegerEventField MultiPv { get; private set; }
    public ScoreEventField Score { get; private set; }
    public WordEventField CurrMove { get; private set; }
    public IntegerEventField CurrMoveNumber { get; private set; }
    public IntegerEventField HashFull { get; private set; }
    public IntegerEventField Nps { get; private set; }
    public IntegerEventField TbHits { get; private set; }
    public IntegerEventField CpuLoad { get; private set; }
    public StringEventField String { get; private set; }
    public VariationEventField Refutation { get; private set; }
    public CurrLineEventField CurrLine { get; private set; }
  }
}
