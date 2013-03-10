using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBombDetector.Events
{
    class Event
    {
        private static Dictionary<EventType, Func<EventType, Event>> _factoryRegistry = 
                new Dictionary<EventType, Func<EventType, Event>>();
        
        private readonly EventType _type;

        private static Event CreateEvent(EventType type)
        {
            return _factoryRegistry[type](type);
        }

        static Event()
        {
            _factoryRegistry.Add(EventType.Id, type => new IdEvent(EventType.Id));
            _factoryRegistry.Add(EventType.UciOk, type => new Event(EventType.UciOk));
            _factoryRegistry.Add(EventType.ReadyOk, type => new Event(EventType.ReadyOk));
            _factoryRegistry.Add(EventType.BestMove, type => new Event(EventType.BestMove));
            _factoryRegistry.Add(EventType.CopyProtection, type => new Event(EventType.CopyProtection));
            _factoryRegistry.Add(EventType.Registration, type => new Event(EventType.Registration));
            _factoryRegistry.Add(EventType.Info, type => new InfoEvent(EventType.Info));
            _factoryRegistry.Add(EventType.Option, type => new Event(EventType.Option));
        }

        protected virtual void ReadFromStream(StringReader reader)
        {
        }

        public EventType Type
        {
            get { return _type; }
        }
        
        public Event(EventType type)
        {
            _type = type;
        }
        
    }
}
