using ChessBombDetector.EventFields;

namespace ChessBombDetector.Events
{
  class InfoEvent : ComplexEvent<InfoEventFieldId>
  {

    private static void RegisterFields()
    {
        RegisterField<IntegerEventField>(InfoEventFieldId.Depth,
          (data, field) => ((InfoEvent)data).Depth = field);
        RegisterField<IntegerEventField>(InfoEventFieldId.SelDepth,
          (data, field) => ((InfoEvent)data).SelDepth = field);
        RegisterField<IntegerEventField>(InfoEventFieldId.Time,
          (data, field) => ((InfoEvent)data).Time = field);
        RegisterField<IntegerEventField>(InfoEventFieldId.Nodes,
          (data, field) => ((InfoEvent)data).Nodes = field);
        RegisterField<VariationEventField>(InfoEventFieldId.Pv,
          (data, field) => ((InfoEvent)data).Pv = field);
        RegisterField<IntegerEventField>(InfoEventFieldId.MultiPv,
          (data, field) => ((InfoEvent)data).MultiPv = field);
        RegisterField<ScoreEventField>(InfoEventFieldId.Score,
          (data, field) => ((InfoEvent)data).Score = field);
        RegisterField<WordEventField>(InfoEventFieldId.CurrMove,
          (data, field) => ((InfoEvent)data).CurrMove = field);
        RegisterField<IntegerEventField>(InfoEventFieldId.CurrMoveNumber,
          (data, field) => ((InfoEvent)data).CurrMoveNumber = field);
        RegisterField<IntegerEventField>(InfoEventFieldId.HashFull,
          (data, field) => ((InfoEvent)data).HashFull = field);
        RegisterField<IntegerEventField>(InfoEventFieldId.Nps,
          (data, field) => ((InfoEvent)data).Nps = field);
        RegisterField<IntegerEventField>(InfoEventFieldId.TbHits,
          (data, field) => ((InfoEvent)data).TbHits = field);
        RegisterField<IntegerEventField>(InfoEventFieldId.CpuLoad,
          (data, field) => ((InfoEvent)data).CpuLoad = field);
        RegisterField<StringEventField>(InfoEventFieldId.String,
          (data, field) => ((InfoEvent)data).String = field);
        RegisterField<VariationEventField>(InfoEventFieldId.Refutation,
          (data, field) => ((InfoEvent)data).Refutation = field);
        RegisterField<CurrLineEventField>(InfoEventFieldId.CurrLine,
          (data, field) => ((InfoEvent)data).CurrLine = field);
    }

    static InfoEvent()
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
