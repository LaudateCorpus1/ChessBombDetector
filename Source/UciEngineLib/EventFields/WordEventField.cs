using System.IO;
using ChessBombDetector.Utils;

namespace ChessBombDetector.EventFields
{
    public class WordEventField : EventField
  {

    public string Value { get; private set; }

    protected override void ReadFromStream(StringReader reader)
    {
        Value = reader.ReadWord();
    }
  }
}
