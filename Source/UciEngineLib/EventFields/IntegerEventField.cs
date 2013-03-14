using System.IO;
using UciEngineLib.Utils;

namespace UciEngineLib.EventFields
{
    public class IntegerEventField: EventField
  {
    public int Value { get; private set; }

    public override void ReadFromStream(StringReader reader)
    {
        Value = int.Parse(reader.ReadWord());
    }
  }
}
