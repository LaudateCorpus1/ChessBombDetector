using System;
using System.Linq;
using ChessBombDetector;
using ChessBombDetector.EventFields;
using ChessBombDetector.Events;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UciEngineLibTest
{
  [TestClass]
  public class EventParserTest
  {
    
    private static TEventType ParseEvent<TEventType>(EventType eventType, string line) where TEventType: Event, new()
    {
      EngineEventParser eventParser = new EngineEventParser();
      eventParser.RegisterEventType<TEventType>(eventType);
      Event ev = eventParser.ParseEvent(line);
      Assert.AreEqual(ev.Type, eventType);
      Assert.IsInstanceOfType(ev, typeof(TEventType));
      return (TEventType) ev;

    }
    
    [TestMethod]
    public void TestParseEventInfoString()
    {
      InfoEvent ev = ParseEvent<InfoEvent>(EventType.Info, "info string 128 MB Hash");
      Assert.AreEqual("128 MB Hash", ev.String.Value);
      Assert.AreEqual(ev.Fields().Count(), 1);
    }

    [TestMethod]
    public void TestParseEventUciOk()
    {
      ParseEvent<UciOkEvent>(EventType.UciOk, "uciok");
    }

    [TestMethod]
    public void TestParseEventReadyOk()
    {
      ParseEvent<ReadyOkEvent>(EventType.ReadyOk, "readyok");
    }

    [TestMethod]
    public void TestParseEventReadyIdName()
    {
      IdEvent ev = ParseEvent<IdEvent>(EventType.Id, "id name Houdini 3a Pro w32");
      Assert.AreEqual("Houdini 3a Pro w32", ev.Name.Value);
      Assert.AreEqual(ev.Fields().Count(), 1);
    }

    [TestMethod]
    public void TestParseEventReadyIdAuthor()
    {
      IdEvent ev = ParseEvent<IdEvent>(EventType.Id, "id author Robert Houdart");
      Assert.AreEqual("Robert Houdart", ev.Author.Value);
      Assert.AreEqual(ev.Fields().Count(), 1);
    }

    [TestMethod]
    public void TestParseEventOption()
    {
      OptionEvent ev = ParseEvent<OptionEvent>(EventType.Option, "option name Style type combo default Normal var Solid var Normal var Risky");
      Assert.AreEqual("Style", ev.NameField.Value);
      Assert.IsTrue(OptionType.Combo == ev.TypeField.Value);
      Assert.AreEqual("Normal", ev.DefaultField.Value);
      Assert.IsNotNull(ev.VarField);
      WordEventField[] fields = ev.VarField.Fields.ToArray();
      Assert.AreEqual(3, fields.Length);
      Assert.AreEqual("Solid", fields[0].Value);
      Assert.AreEqual("Normal", fields[1].Value);
      Assert.AreEqual("Risky", fields[2].Value);
      Assert.AreEqual(ev.Fields().Count(), 4);
    }
  }
}
