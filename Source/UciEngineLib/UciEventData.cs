using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessBombDetector.Fields;
using ChessBombDetector.Utils;

namespace ChessBombDetector
{
    class UciEventData<TFieldId> where TFieldId : struct
    {

        private static readonly Dictionary<TFieldId, Func<UciEventData<TFieldId>, UciEventField>> _fieldFactoryRegistry = new Dictionary<TFieldId, Func<UciEventData<TFieldId>, UciEventField>>();

        private readonly IDictionary<TFieldId, UciEventField> _fields = new Dictionary<TFieldId, UciEventField>();

        private UciEventField CreateField(TFieldId fieldId)
        {
            return _fieldFactoryRegistry[fieldId](this);
        }

        protected static void RegisterField<TFieldClass>(TFieldId fieldId, Action<UciEventData<TFieldId>, TFieldClass> fieldSetter = null) where TFieldClass : UciEventField, new()
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

        protected UciEventField FindField(TFieldId id)
        {
            UciEventField result;
            return _fields.TryGetValue(id, out result) ? result : null;
        }

        protected UciEventField GetField(TFieldId id)
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
                
            }              
        }
    }
}
