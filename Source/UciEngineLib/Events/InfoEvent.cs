using ChessBombDetector.EventFields;

namespace ChessBombDetector.Events
{
  class InfoEvent : ComplexEvent<InfoEventFieldType>
  {

    private static void RegisterFields()
    {
        RegisterField<IntegerEventField>(InfoEventFieldType.Depth,
          (data, field) => ((InfoEvent)data).Depth = field);
        RegisterField<IntegerEventField>(InfoEventFieldType.SelDepth,
          (data, field) => ((InfoEvent)data).SelDepth = field);
        RegisterField<IntegerEventField>(InfoEventFieldType.Time,
          (data, field) => ((InfoEvent)data).Time = field);
        RegisterField<IntegerEventField>(InfoEventFieldType.Nodes,
          (data, field) => ((InfoEvent)data).Nodes = field);
        RegisterField<VariationEventField>(InfoEventFieldType.Pv,
          (data, field) => ((InfoEvent)data).Pv = field);
        RegisterField<IntegerEventField>(InfoEventFieldType.MultiPv,
          (data, field) => ((InfoEvent)data).MultiPv = field);
        RegisterField<ScoreEventField>(InfoEventFieldType.Score,
          (data, field) => ((InfoEvent)data).Score = field);
        RegisterField<WordEventField>(InfoEventFieldType.CurrMove,
          (data, field) => ((InfoEvent)data).CurrMove = field);
        RegisterField<IntegerEventField>(InfoEventFieldType.CurrMoveNumber,
          (data, field) => ((InfoEvent)data).CurrMoveNumber = field);
        RegisterField<IntegerEventField>(InfoEventFieldType.HashFull,
          (data, field) => ((InfoEvent)data).HashFull = field);
        RegisterField<IntegerEventField>(InfoEventFieldType.Nps,
          (data, field) => ((InfoEvent)data).Nps = field);
        RegisterField<IntegerEventField>(InfoEventFieldType.TbHits,
          (data, field) => ((InfoEvent)data).TbHits = field);
        RegisterField<IntegerEventField>(InfoEventFieldType.CpuLoad,
          (data, field) => ((InfoEvent)data).CpuLoad = field);
        RegisterField<StringEventField>(InfoEventFieldType.String,
          (data, field) => ((InfoEvent)data).String = field);
        RegisterField<VariationEventField>(InfoEventFieldType.Refutation,
          (data, field) => ((InfoEvent)data).Refutation = field);
        RegisterField<CurrLineEventField>(InfoEventFieldType.CurrLine,
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

    public InfoEvent() : base(EventType.Info) {}

  }
}
