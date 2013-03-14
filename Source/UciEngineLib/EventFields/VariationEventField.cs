using System;
using System.Collections.Generic;
using System.IO;
using UciEngineLib.Utils;

namespace UciEngineLib.EventFields
{
  public class VariationEventField : EventField
  {
    public String[] Moves { get; private set; }

    public override void ReadFromStream(StringReader reader)
    {
      List<string> words = new List<string>();
      string word;
      while ((word = reader.ReadWord()) != null)
      {
        words.Add(word);
      }
      Moves = words.ToArray();
    }
  }
}
