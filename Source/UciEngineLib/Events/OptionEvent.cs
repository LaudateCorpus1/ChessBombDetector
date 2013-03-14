using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UciEngineLib.EventFields;

namespace UciEngineLib.Events
{
  public class OptionEvent: Event
  {
    // private static Regex Regex = new Regex("name (?<name>.*) type (?<type>/w+)( min (?<min>/d+))?( max (?<max>/d+))?( default (?<default>.*))?( var (?<var>.*))*");
    private static Regex Regex = new Regex("name (?<name>.*?) type (?<type>.*?)");
    
    public WordEventField NameField { get; private set; }
    public OptionTypeEventField TypeField { get; private set; }
    public WordEventField DefaultField { get; private set; }
    public IntegerEventField MinField { get; private set; }
    public IntegerEventField MaxField { get; private set; }
    public MultiEventField<WordEventField> VarField { get; private set; }

    public OptionEvent()
      : base(EventType.Option)
    {
    }

    public override void ReadFromStream(StringReader reader)
    {
      string str = reader.ReadToEnd();
      Match match = Regex.Match(str);
      if (!match.Success)
        throw new InvalidDataException(String.Format("Option event format mismatch: {0}", str));
      NameField.ReadFromRegexGroup(match, "name", true);
      TypeField.ReadFromRegexGroup(match, "type", true);
      MinField.ReadFromRegexGroup(match, "min");
      MaxField.ReadFromRegexGroup(match, "max");
      DefaultField.ReadFromRegexGroup(match, "default");
      VarField.ReadFromRegexGroup(match, "var");
    }

  }

  static class EventFieldExtension
  {
    public static void ReadFromRegexGroup(this EventField field, Match match, String groupName, bool mandatory = false)
    {
      Group group = match.Groups[groupName];
      if (mandatory && !group.Success)
        throw new InvalidDataException(String.Format("Field {0} not found", groupName));
      if (!group.Success)
        return;
      if (!(field is MultiEventField))
      {
        field.ReadFromStream(new StringReader(group.Value));
        return;
      }
      foreach (Capture capture in group.Captures)
      {
        field.ReadFromStream(new StringReader(capture.Value));
      }
    }
  }

}
