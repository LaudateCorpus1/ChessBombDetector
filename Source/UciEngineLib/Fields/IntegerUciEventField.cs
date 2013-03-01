using System;
using System.IO;

namespace ChessBombDetector.Fields
{
  class IntegerUciEventField: UciEventField
  {
    public int Value { get; private set; }

    protected override void ReadFromStream(StreamReader reader)
    {
      throw new NotImplementedException();
    }
  }
}
