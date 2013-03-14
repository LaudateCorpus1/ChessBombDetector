using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UciEngineLib.EventFields;

namespace UciEngineLib.Events
{
  public class IdEvent : ComplexEvent<IdEventFieldType>
  {
    static IdEvent()
    {
      RegisterField<StringEventField>(IdEventFieldType.Name,
                                         (ev, field) => ((IdEvent)ev).Name = field);
      RegisterField<StringEventField>(IdEventFieldType.Author,
                                         (ev, field) => ((IdEvent)ev).Author = field);
    }

    public StringEventField Name { get; private set; }
    public StringEventField Author { get; private set; }

    public IdEvent() : base(EventType.Id) { }
  }
}