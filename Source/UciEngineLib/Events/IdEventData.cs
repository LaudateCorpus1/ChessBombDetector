using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessBombDetector.EventFields;

namespace ChessBombDetector.Events
{
    internal class IdEventData : UciEventData<IdEventFieldId>
    {
        private static void RegisterFields()
        {
            RegisterField<StringEventField>(IdEventFieldId.Name,
                                               (data, field) => ((IdEventData) data).Name = field);
            RegisterField<StringEventField>(IdEventFieldId.Author,
                                               (data, field) => ((IdEventData) data).Author = field);
        }

        static IdEventData()
        {
            RegisterFields();
        }

        public StringEventField Name { get; private set; }
        public StringEventField Author { get; private set; }
    }
}