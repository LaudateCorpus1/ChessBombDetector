using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessBombDetector.EventFields;

namespace ChessBombDetector.Events
{
  public class OptionEvent : ComplexEvent<OptionEventFieldType>
  {
    private readonly ICollection<WordEventField> _varFields = new List<WordEventField>();

    public WordEventField NameField { get; private set; }
    public WordEventField TypeField { get; private set; }
    public WordEventField DefaultField { get; private set; }
    public IntegerEventField MinField { get; private set; }
    public IntegerEventField MaxField { get; private set; }
    public ICollection<WordEventField> VarFields { get { return _varFields; } }

    public OptionEvent()
      : base(EventType.Option)
    {
    }

    static OptionEvent()
    {
      RegisterField<WordEventField>(OptionEventFieldType.Name,
                                         (ev, field) => ((OptionEvent)ev).NameField = field);
      RegisterField<WordEventField>(OptionEventFieldType.Type,
                                         (ev, field) => ((OptionEvent)ev).TypeField = field);
      RegisterField<WordEventField>(OptionEventFieldType.Default,
                                         (ev, field) => ((OptionEvent)ev).DefaultField = field);
      RegisterField<IntegerEventField>(OptionEventFieldType.Min,
                                         (ev, field) => ((OptionEvent)ev).MinField = field);
      RegisterField<IntegerEventField>(OptionEventFieldType.Max,
                                         (ev, field) => ((OptionEvent)ev).MaxField = field);
      RegisterField<WordEventField>(OptionEventFieldType.Var,
                                         (ev, field) => ((OptionEvent)ev).VarFields.Add(field));
    }

  }

}
