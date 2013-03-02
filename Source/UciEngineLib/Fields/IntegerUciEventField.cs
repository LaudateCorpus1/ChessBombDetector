using System;
using System.IO;
using ChessBombDetector.Utils;

namespace ChessBombDetector.Fields
{
  class IntegerUciEventField: UciEventField
  {
    public int Value { get; private set; }

    protected override void ReadFromStream(StringReader reader)
    {
        Value = int.Parse(reader.ReadWord());
    }
  }
}
