using System;
using System.Collections.Generic;
using System.IO;
using ChessBombDetector.EventFields;
using ChessBombDetector.Utils;

namespace ChessBombDetector.Events
{
  public class ComplexEvent<TFieldType> : Event where TFieldType : struct
  {

    private static readonly Dictionary<TFieldType, Func<ComplexEvent<TFieldType>, EventField>> _fieldFactoryRegistry = new Dictionary<TFieldType, Func<ComplexEvent<TFieldType>, EventField>>();

    private readonly IDictionary<TFieldType, EventField> _fields = new Dictionary<TFieldType, EventField>();

    private EventField CreateField(TFieldType fieldId)
    {
      return _fieldFactoryRegistry[fieldId](this);
    }

    protected static void RegisterField<TFieldClass>(TFieldType fieldId, Action<ComplexEvent<TFieldType>, TFieldClass> fieldSetter = null) where TFieldClass : EventField, new()
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

    protected EventField FindField(TFieldType id)
    {
      EventField result;
      return _fields.TryGetValue(id, out result) ? result : null;
    }

    protected EventField GetField(TFieldType id)
    {
      var result = FindField(id);
      if (result == null)
      {
        // TODO: typed exception
        throw new Exception(string.Format("Field {0} not found", id));
      }
      return result;
    }

    public override void ReadFromStream(StringReader reader)
    {
      string word;
      while ((word = reader.ReadWord()) != null)
      {
        TFieldType fieldId = EnumDescriptionToValueMapper<TFieldType>.GetValueByDescription(word);
        EventField field = CreateField(fieldId);
        _fields.Add(fieldId, field);
      }
    }

    public ComplexEvent(EventType type) : base(type) { }
  }
}
