using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBombDetector
{
    class UciEventData
    {

      private readonly IDictionary<string, UciEventField> _fields = new Dictionary<string, UciEventField>();
        
        protected UciEventField FindField(string id)
        {
            UciEventField result;
            return _fields.TryGetValue(id, out result) ? result : null;
        }

        protected UciEventField GetField(string id)
        {
            var result = FindField(id);
            if (result == null)
            {
                // TODO: typed exception
                throw new Exception(string.Format("Field {0} not found", id));
            }
            return result;
        }
    }
}
