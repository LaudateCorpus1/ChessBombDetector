using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessBombDetector.EventFields;

namespace ChessBombDetector.Events
{
    internal class IdEvent : ComplexEvent<IdEventFieldType>
    {
        private static void RegisterFields()
        {
            RegisterField<StringEventField>(IdEventFieldType.Name,
                                               (data, field) => ((IdEvent) data).Name = field);
            RegisterField<StringEventField>(IdEventFieldType.Author,
                                               (data, field) => ((IdEvent) data).Author = field);
        }

        static IdEvent()
        {
            RegisterFields();
        }

        public StringEventField Name { get; private set; }
        public StringEventField Author { get; private set; }

        public IdEvent() : base(EventType.Id) {}
    }
}