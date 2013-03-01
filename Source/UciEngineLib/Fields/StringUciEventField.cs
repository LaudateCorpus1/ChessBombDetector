using System;
using System.IO;

namespace ChessBombDetector.Fields
{
  class StringUciEventField : UciEventField
  {

    public string Value { get; private set; }

    protected override void ReadFromStream(StreamReader reader)
    {
      throw new NotImplementedException();
    }
  }
}
