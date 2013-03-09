using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessBombDetector.EventFields;

namespace ChessBombDetector.Events
{
    internal class IdUciEventData : UciEventData<IdUciEventFieldId>
    {
        private static void RegisterFields()
        {
            RegisterField<StringUciEventField>(IdUciEventFieldId.Name,
                                               (data, field) => ((IdUciEventData) data).Name = field);
            RegisterField<StringUciEventField>(IdUciEventFieldId.Author,
                                               (data, field) => ((IdUciEventData) data).Author = field);
        }

        static IdUciEventData()
        {
            RegisterFields();
        }

        public StringUciEventField Name { get; private set; }
        public StringUciEventField Author { get; private set; }
    }
}