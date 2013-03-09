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
