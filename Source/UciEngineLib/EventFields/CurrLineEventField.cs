using System;
using System.IO;
using UciEngineLib.Utils;

namespace UciEngineLib.EventFields
{
    public class CurrLineEventField : VariationEventField
    {

      public int CpuNumber { get; private set; }

      public override void ReadFromStream(StringReader reader)
      {
          CpuNumber = int.Parse(reader.ReadWord());
          base.ReadFromStream(reader);
        }
    }
}
