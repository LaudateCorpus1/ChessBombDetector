using System;
using System.Collections.Generic;
using System.IO;
using UciEngineLib.EventFields;
using UciEngineLib.Utils;

namespace UciEngineLib.Events
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

    public EventField FindField(TFieldType id)
    {
      EventField result;
      return _fields.TryGetValue(id, out result) ? result : null;
    }

    public EventField GetField(TFieldType id)
    {
      var result = FindField(id);
      if (result == null)
      {
        // TODO: typed exception
        throw new Exception(string.Format("Field {0} not found", id));
      }
      return result;
    }

    public IEnumerable<EventField> Fields()
    {
      return _fields.Values;
    }

    public override void ReadFromStream(StringReader reader)
    {
      string word;
      while ((word = reader.ReadWord()) != null)
      {
        if (word.Equals(String.Empty))
        {
          continue;
        }
        TFieldType fieldId = EnumDescriptionToValueMapper<TFieldType>.GetValueByDescription(word);
        EventField field = CreateField(fieldId);
        field.ReadFromStream(reader);
        AddField(fieldId, field);
      }
    }

    private void AddField(TFieldType fieldId, EventField field)
    {
      EventField multiEventField;
      if (!(field is MultiEventField && _fields.TryGetValue(fieldId, out multiEventField)))
      {
        _fields.Add(fieldId, field);
        return;
      }
      // TODO: typed exception
      if (field.GetType() != multiEventField.GetType())
      {
        throw new Exception("Multi field event type mismatch");
      }
      ((MultiEventField)multiEventField).AddField((MultiEventField)field);
    }

    public ComplexEvent(EventType type) : base(type) { }
  }
}
