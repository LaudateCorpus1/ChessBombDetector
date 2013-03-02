using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessBombDetector.Fields;
using ChessBombDetector.Utils;

namespace ChessBombDetector
{
    class UciEventData<TFieldId> where TFieldId: struct
    {

      private static readonly FactoryRegistry<TFieldId, UciEventField> _fieldRegistry = new FactoryRegistry<TFieldId, UciEventField>();

      private readonly IDictionary<TFieldId, UciEventField> _fields = new Dictionary<TFieldId, UciEventField>();

      protected static void RegisterField<TFieldClass>(TFieldId fieldId, Action<UciEventData<TFieldId>, TFieldClass> fieldSetter = null) where TFieldClass : UciEventField, new()
      {
        _fieldRegistry.Register<TFieldClass>(fieldId);
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
    }
}
