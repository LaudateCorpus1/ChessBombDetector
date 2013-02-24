using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessBombDetector.UciInfoEventFields;

namespace ChessBombDetector
{
    public class UciInfoEvent
    {

        private readonly IDictionary<Type, UciInfoEventField> _fields = new Dictionary<Type, UciInfoEventField>();

        
        public UciInfoEventField FindField<T>() where T : class
        {
            UciInfoEventField result;
            return _fields.TryGetValue(typeof (T), out result) ? result : null;
        }

        public UciInfoEventField GetField<T>() where T : Type
        {
            var result = FindField<T>();
            if (result == null)
            {
                // TODO: typed exception
                throw new Exception(string.Format("Field for type {0} not found", typeof (T)));
            }
            return result;
        }
    }
}
