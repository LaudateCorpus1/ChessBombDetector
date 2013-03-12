using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBombDetector.EventFields
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
}
