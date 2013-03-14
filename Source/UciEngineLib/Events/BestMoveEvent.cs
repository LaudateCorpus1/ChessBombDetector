using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UciEngineLib.Utils;

namespace UciEngineLib.Events
{
  public class BestMoveEvent : Event
  {
    public string Move { get; private set; }
    public string Ponder { get; private set; }

    public BestMoveEvent()
      : base(EventType.BestMove)
    {
    }

    public override void ReadFromStream(StringReader reader)
    {
      Move = reader.ReadWord();
      string word = reader.ReadWord();
      if (word == null)
        return;
      if (word != "ponder")
        throw new InvalidDataException(String.Format("Inexpected word in BestMove variation: {0}", word));
      Ponder = reader.ReadWord();
    }
  }
}
