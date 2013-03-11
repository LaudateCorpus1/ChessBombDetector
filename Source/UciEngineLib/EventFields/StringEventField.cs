using System.IO;

namespace ChessBombDetector.EventFields
{
    public class StringEventField : EventField
  {

    public string Value { get; private set; }

    public override void ReadFromStream(StringReader reader)
    {
      Value = reader.ReadToEnd();
    }
  }
}
