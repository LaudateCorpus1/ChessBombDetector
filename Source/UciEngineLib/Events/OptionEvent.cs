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
  public class OptionEvent : Event
  {
    private static Regex Regex = new Regex(@"name (?<name>.*) type (?<type>\w+)( min (?<min>\d+))?( max (?<max>\d+))?( default (?<default>\w+))?( var (?<var>\w+))*");

    public StringEventField NameField { get; private set; }
    public OptionTypeEventField TypeField { get; private set; }
    public WordEventField DefaultField { get; private set; }
    public IntegerEventField MinField { get; private set; }
    public IntegerEventField MaxField { get; private set; }
    public MultiEventField<WordEventField> VarField { get; private set; }

    public OptionEvent()
      : base(EventType.Option)
    {
    }

    public static TField ReadFieldFromRegexGroup<TField>(Match match, String groupName, bool mandatory = false) where TField : EventField, new()
    {
      Group group = match.Groups[groupName];
      if (mandatory && !group.Success)
        throw new InvalidDataException(String.Format("Field {0} not found", groupName));
      if (!group.Success)
        return null;
      TField field = new TField();
      if (!(field is MultiEventField))
      {
        field.ReadFromStream(new StringReader(group.Value));
      }
      else
      {
        foreach (Capture capture in group.Captures)
        {
          field.ReadFromStream(new StringReader(capture.Value));
        }
      }
      return field;
    }

    public override void ReadFromStream(StringReader reader)
    {
      string str = reader.ReadToEnd();
      Match match = Regex.Match(str);
      if (!match.Success)
        throw new InvalidDataException(String.Format("Option event format mismatch: {0}", str));
      NameField = ReadFieldFromRegexGroup<StringEventField>(match, "name", true);
      TypeField = ReadFieldFromRegexGroup<OptionTypeEventField>(match, "type", true);
      MinField = ReadFieldFromRegexGroup<IntegerEventField>(match, "min");
      MaxField = ReadFieldFromRegexGroup<IntegerEventField>(match, "max");
      DefaultField = ReadFieldFromRegexGroup<WordEventField>(match, "default");
      VarField = ReadFieldFromRegexGroup<MultiEventField<WordEventField>>(match, "var");
    }

  }

}
