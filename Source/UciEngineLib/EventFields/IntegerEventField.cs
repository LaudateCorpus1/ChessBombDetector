using System.IO;
using UciEngineLib.Utils;

namespace UciEngineLib.EventFields
{
    public class IntegerEventField: EventField
  {
    public long Value { get; private set; }

    public override void ReadFromStream(StringReader reader)
    {
      Value = long.Parse(reader.ReadWord());
    }
  }
}
