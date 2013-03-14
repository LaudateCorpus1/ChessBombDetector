using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UciEngineLib.Events;
using UciEngineLib.Utils;

namespace UciEngineLib
{
  class EngineEventParser
  {
    private Dictionary<EventType, Func<Event>> _eventFactoryRegistry =
            new Dictionary<EventType, Func<Event>>();

    public void RegisterEventType<TEventType>(EventType eventType) where TEventType : Event, new()
    {
      _eventFactoryRegistry.Add(eventType, () => new TEventType());
    }

    private Event CreateEvent(EventType type)
    {
      return _eventFactoryRegistry[type]();
    }

    private Event ParseEventBody(EventType eventType, StringReader reader)
    {
      Contract.Ensures(Contract.Result<Event>().Type == eventType);
      Event ev = CreateEvent(eventType);
      ev.ReadFromStream(reader);
      return ev;
    }

    public Event ParseEvent(string line)
    {
      Contract.Ensures(Contract.Result<Event>() != null);
      StringReader reader = new StringReader(line);
      EventType eventType = EnumDescriptionToValueMapper<EventType>.GetValueByDescription(reader.ReadWord());
      return ParseEventBody(eventType, reader);
    }

  }
}
