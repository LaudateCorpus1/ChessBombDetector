using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UciEngineLib.Utils;

namespace UciEngineLib.EventFields
{
  public class OptionTypeEventField : EventField
  {
    public enum OptionType
    {
      [Description("check")]
      Check,

      [Description("spin")]
      Spin,

      [Description("combo")]
      Combo,

      [Description("button")]
      Button,

      [Description("string")]
      String
    }

    public OptionType Value { get; private set; }

    public override void ReadFromStream(StringReader reader)
    {
      Value = EnumDescriptionToValueMapper<OptionType>.GetValueByDescription(reader.ReadWord());
    }
  }
}
