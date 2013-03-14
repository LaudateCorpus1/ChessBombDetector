using UciEngineLib.EventFields;

namespace UciEngineLib.Events
{
  public class InfoEvent : ComplexEvent<InfoEventFieldType>
  {

    static InfoEvent()
    {
      RegisterField<IntegerEventField>(InfoEventFieldType.Depth,
        (ev, field) => ((InfoEvent)ev).Depth = field);
      RegisterField<IntegerEventField>(InfoEventFieldType.SelDepth,
        (ev, field) => ((InfoEvent)ev).SelDepth = field);
      RegisterField<IntegerEventField>(InfoEventFieldType.Time,
        (ev, field) => ((InfoEvent)ev).Time = field);
      RegisterField<IntegerEventField>(InfoEventFieldType.Nodes,
        (ev, field) => ((InfoEvent)ev).Nodes = field);
      RegisterField<VariationEventField>(InfoEventFieldType.Pv,
        (ev, field) => ((InfoEvent)ev).Pv = field);
      RegisterField<IntegerEventField>(InfoEventFieldType.MultiPv,
        (ev, field) => ((InfoEvent)ev).MultiPv = field);
      RegisterField<ScoreEventField>(InfoEventFieldType.Score,
        (ev, field) => ((InfoEvent)ev).Score = field);
      RegisterField<WordEventField>(InfoEventFieldType.CurrMove,
        (ev, field) => ((InfoEvent)ev).CurrMove = field);
      RegisterField<IntegerEventField>(InfoEventFieldType.CurrMoveNumber,
        (ev, field) => ((InfoEvent)ev).CurrMoveNumber = field);
      RegisterField<IntegerEventField>(InfoEventFieldType.HashFull,
        (ev, field) => ((InfoEvent)ev).HashFull = field);
      RegisterField<IntegerEventField>(InfoEventFieldType.Nps,
        (ev, field) => ((InfoEvent)ev).Nps = field);
      RegisterField<IntegerEventField>(InfoEventFieldType.TbHits,
        (ev, field) => ((InfoEvent)ev).TbHits = field);
      RegisterField<IntegerEventField>(InfoEventFieldType.CpuLoad,
        (ev, field) => ((InfoEvent)ev).CpuLoad = field);
      RegisterField<StringEventField>(InfoEventFieldType.String,
        (ev, field) => ((InfoEvent)ev).String = field);
      RegisterField<VariationEventField>(InfoEventFieldType.Refutation,
        (ev, field) => ((InfoEvent)ev).Refutation = field);
      RegisterField<CurrLineEventField>(InfoEventFieldType.CurrLine,
        (ev, field) => ((InfoEvent)ev).CurrLine = field);
      RegisterField<WordEventField>(InfoEventFieldType.Idle,
        (ev, field) => ((InfoEvent)ev).Idle = field);
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
    public WordEventField Idle { get; private set; }

    public InfoEvent() : base(EventType.Info) { }

  }
}
