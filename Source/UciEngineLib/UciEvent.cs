using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessBombDetector.UciEventFields;

namespace ChessBombDetector
{
    public class UciEvent
    {

        private readonly IDictionary<Type, UciEventField> _fields = new Dictionary<Type, UciEventField>();
        
        public UciEventField FindField<T>() where T : UciEventField
        {
            UciEventField result;
            return _fields.TryGetValue(typeof (T), out result) ? result : null;
        }

        public UciEventField GetField<T>() where T : UciEventField
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
