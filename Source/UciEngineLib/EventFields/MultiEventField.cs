using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBombDetector.EventFields
{
  public abstract class MultiEventField : EventField
  {
    public abstract void AddField(MultiEventField multiEventField);
  }

  public class MultiEventField<TField> : MultiEventField where TField : EventField, new()
  {
    private readonly ICollection<TField> _fields = new List<TField>();

    public ICollection<TField> Fields { get { return _fields; } }

    public override void ReadFromStream(StringReader reader)
    {
      TField field = new TField();
      field.ReadFromStream(reader);
      _fields.Add(field);
    }

    private void AddField(MultiEventField<TField> multiEventField)
    {
      foreach (var field in multiEventField.Fields)
      {
        Fields.Add(field);
      }
    }

    public override void AddField(MultiEventField multiEventField)
    {
      AddField((MultiEventField<TField>)multiEventField);
    }

    public static MultiEventField<TField> operator +(MultiEventField<TField> left, MultiEventField<TField> right)
    {
      if (left == null)
        return right;
      left.AddField(right);
      return left;
    }

  }
}
