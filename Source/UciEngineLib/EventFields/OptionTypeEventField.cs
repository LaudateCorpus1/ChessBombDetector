using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessBombDetector.Utils;

namespace ChessBombDetector.EventFields
{
  public class OptionTypeEventField : EventField
  {
    public OptionType Value { get; private set; }

    public override void ReadFromStream(StringReader reader)
    {
      Value = EnumDescriptionToValueMapper<OptionType>.GetValueByDescription(reader.ReadWord());
    }
  }
}
