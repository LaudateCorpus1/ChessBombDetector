using System.IO;
using UciEngineLib.Utils;

namespace UciEngineLib.EventFields
{
    public class WordEventField : EventField
  {

    public string Value { get; private set; }

    public override void ReadFromStream(StringReader reader)
    {
        Value = reader.ReadWord();
    }
  }
}
