using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UciEngineLib.Events;

namespace UciEngineLib
{
  class EngineEventDispatcher
  {
    private static Dictionary<EventType, Action<object, Event>> _eventHandlerRegistry =
            new Dictionary<EventType, Action<object, Event>>();

    public void RegisterEventType<TEventType>(EventType eventType, Action<object, TEventType> eventHandler)
      where TEventType : Event
    {
      _eventHandlerRegistry.Add(eventType, (engine, ev) => eventHandler(engine, (TEventType) ev));
    }

    public void HandleEvent(object sender, Event ev)
    {
      _eventHandlerRegistry[ev.Type](sender, ev);
    }

  }
}
