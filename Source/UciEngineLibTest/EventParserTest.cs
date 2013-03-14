using System;
using System.Linq;
using UciEngineLib;
using UciEngineLib.EventFields;
using UciEngineLib.Events;
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
      //OptionEvent ev = ParseEvent<OptionEvent>(EventType.Option, "option name Style type combo default Normal var Solid var Normal var Risky");
      OptionEvent ev = ParseEvent<OptionEvent>(EventType.Option, "option name Style type combo");
      Assert.AreEqual("Style", ev.NameField.Value);
      Assert.IsTrue(OptionTypeEventField.OptionType.Combo == ev.TypeField.Value);
      //Assert.AreEqual("Normal", ev.DefaultField.Value);
      //Assert.IsNotNull(ev.VarField);
      //WordEventField[] fields = ev.VarField.Fields.ToArray();
      //Assert.AreEqual(3, fields.Length);
      //Assert.AreEqual("Solid", fields[0].Value);
      //Assert.AreEqual("Normal", fields[1].Value);
      //Assert.AreEqual("Risky", fields[2].Value);
    }

    [TestMethod]
    public void TestParseEventOption2()
    {
      OptionEvent ev = ParseEvent<OptionEvent>(EventType.Option, "option name Tactical Mode type check default false");
      Assert.AreEqual("Tactical Mode", ev.NameField.Value);
      Assert.IsTrue(OptionTypeEventField.OptionType.Check == ev.TypeField.Value);
      Assert.AreEqual("false", ev.DefaultField.Value);
      Assert.IsNull(ev.VarField);
    }

    [TestMethod]
    public void TestParseEventInfo()
    {
      InfoEvent ev = ParseEvent<InfoEvent>(EventType.Info, "info multipv 1 depth 4 seldepth 16 score cp -13 time 7 nodes 13957 nps 1993000 tbhits 0 hashfull 0 pv f8d8 b3c2 h3f5 c2e4 b5b4 c3b4 d6b4");
      Assert.AreEqual(1, ev.MultiPv.Value);
      Assert.AreEqual(4, ev.Depth.Value);
      Assert.AreEqual(16, ev.SelDepth.Value);
      Assert.IsTrue(ScoreEventField.ScoreType.Cp == ev.Score.Type);
      Assert.AreEqual(-13, ev.Score.CpScore);
      Assert.AreEqual(7, ev.Time.Value);
      Assert.AreEqual(13957, ev.Nodes.Value);
      Assert.AreEqual(1993000, ev.Nps.Value);
      Assert.AreEqual(0, ev.TbHits.Value);
      Assert.AreEqual(0, ev.HashFull.Value);
      Assert.AreEqual(7, ev.Pv.Moves.Length);
      Assert.AreEqual("f8d8", ev.Pv.Moves[0]);
      Assert.AreEqual("b3c2", ev.Pv.Moves[1]);
      Assert.AreEqual("h3f5", ev.Pv.Moves[2]);
      Assert.AreEqual("c2e4", ev.Pv.Moves[3]);
      Assert.AreEqual("b5b4", ev.Pv.Moves[4]);
      Assert.AreEqual("c3b4", ev.Pv.Moves[5]);
      Assert.AreEqual("d6b4", ev.Pv.Moves[6]);
    }
  }
}
