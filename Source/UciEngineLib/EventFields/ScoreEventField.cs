using System;
using System.ComponentModel;
using System.IO;
using UciEngineLib.Utils;

namespace UciEngineLib.EventFields
{
  public class ScoreEventField : EventField
  {
    public enum ScoreType
    {
      [Description("cp")]
      Cp,

      [Description("mate")]
      Mate,

      [Description("lowerbound")]
      LowerBound,

      [Description("upperbound")]
      UpperBound
    }

    public ScoreType Type { get; private set; }

    public int CpScore { get; private set; }

    public int MateDepth { get; private set; }

    public override void ReadFromStream(StringReader reader)
    {
      Type = EnumDescriptionToValueMapper<ScoreType>.GetValueByDescription(reader.ReadWord());
      switch (Type)
      {
        case ScoreType.Cp:
          CpScore = int.Parse(reader.ReadWord());
          break;
        case ScoreType.Mate:
          MateDepth = int.Parse(reader.ReadWord());
          break;
      }
    }
  }
}
