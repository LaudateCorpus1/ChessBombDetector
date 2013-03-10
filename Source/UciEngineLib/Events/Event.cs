using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessBombDetector.Utils;

namespace ChessBombDetector.Events
{
    abstract class Event
    {
        private static Dictionary<EventType, Func<Event>> _factoryRegistry = 
                new Dictionary<EventType, Func<Event>>();
        
        private readonly EventType _type;

        private static Event CreateEvent(EventType type)
        {
            return _factoryRegistry[type]();
        }

        static Event()
        {
            _factoryRegistry.Add(EventType.Id, () => new IdEvent());
            _factoryRegistry.Add(EventType.UciOk, () => new UciOkEvent());
            _factoryRegistry.Add(EventType.ReadyOk, () => new ReadyOkEvent());
            _factoryRegistry.Add(EventType.BestMove, () => new BestMoveEvent());
            _factoryRegistry.Add(EventType.CopyProtection, () => new CopyProtectionEvent());
            _factoryRegistry.Add(EventType.Registration, () => new RegistrationEvent());
            _factoryRegistry.Add(EventType.Info, () => new InfoEvent());
            _factoryRegistry.Add(EventType.Option, () => new OptionEvent());
        }

        protected virtual void ReadFromStream(StringReader reader)
        {
        }

        public EventType Type
        {
            get { return _type; }
        }
        
        protected Event(EventType type)
        {
            _type = type;
        }

        public static Event CreateFromStream(StringReader reader)
        {
            EventType eventType = EnumDescriptionToValueMapper<EventType>.GetValueByDescription(reader.ReadWord());
            Event res = CreateEvent(eventType);
            res.ReadFromStream(reader);
            return res;
        }
        
    }
}
