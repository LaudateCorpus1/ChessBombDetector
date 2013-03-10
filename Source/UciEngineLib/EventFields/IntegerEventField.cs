using System.IO;
using ChessBombDetector.Utils;

namespace ChessBombDetector.EventFields
{
    public class IntegerEventField: EventField
  {
    public int Value { get; private set; }

    protected override void ReadFromStream(StringReader reader)
    {
        Value = int.Parse(reader.ReadWord());
    }
  }
}
