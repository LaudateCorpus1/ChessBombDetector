using System;
using System.Collections.Generic;
using System.IO;
using ChessBombDetector.EventFields;
using ChessBombDetector.Utils;

namespace ChessBombDetector.Events
{
    class ComplexEvent<TFieldId> where TFieldId : struct
    {

        private static readonly Dictionary<TFieldId, Func<ComplexEvent<TFieldId>, EventField>> _fieldFactoryRegistry = new Dictionary<TFieldId, Func<ComplexEvent<TFieldId>, EventField>>();

        private readonly IDictionary<TFieldId, EventField> _fields = new Dictionary<TFieldId, EventField>();

        private EventField CreateField(TFieldId fieldId)
        {
            return _fieldFactoryRegistry[fieldId](this);
        }

        protected static void RegisterField<TFieldClass>(TFieldId fieldId, Action<ComplexEvent<TFieldId>, TFieldClass> fieldSetter = null) where TFieldClass : EventField, new()
        {
            _fieldFactoryRegistry.Add(fieldId,
                obj =>
                {
                    var field = new TFieldClass();
                    if (fieldSetter != null)
                        fieldSetter(obj, field);
                    return field;
                }
            );
        }

        protected EventField FindField(TFieldId id)
        {
            EventField result;
            return _fields.TryGetValue(id, out result) ? result : null;
        }

        protected EventField GetField(TFieldId id)
        {
            var result = FindField(id);
            if (result == null)
            {
                // TODO: typed exception
                throw new Exception(string.Format("Field {0} not found", id));
            }
            return result;
        }

        protected void ReadFromStream(StringReader reader)
        {
            string word = null;
            while ((word = reader.ReadWord()) != null)
            {
                TFieldId fieldId = EnumDescriptionToValueMapper<TFieldId>.GetValueByDescription(word);
                EventField field = CreateField(fieldId);
                _fields.Add(fieldId, field);
            }              
        }
    }
}
