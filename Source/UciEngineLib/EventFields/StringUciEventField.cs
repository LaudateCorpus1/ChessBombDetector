using System.IO;

namespace ChessBombDetector.EventFields
{
  class StringUciEventField : UciEventField
  {

    public string Value { get; private set; }

    protected override void ReadFromStream(StringReader reader)
    {
      Value = reader.ReadToEnd();
    }
  }
}
