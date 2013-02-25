using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBombDetector.UciEventFields
{
  [UciFieldId("seldepth")]
  public class SelDepthField : UciEventField
  {
    public int SelDepth { get; set; }
  }
}
