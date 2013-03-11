using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessBombDetector.Events;
using ChessBombDetector.Utils;

namespace ChessBombDetector
{
  public class Engine : IEngine, IDisposable
  {

    private readonly StreamReader _reader;

    private readonly StreamWriter _writer;

    private readonly Task _eventProcessorTask;

    private static Dictionary<EventType, Action<Engine, StringReader>> _eventHandlerRegistry =
            new Dictionary<EventType, Action<Engine, StringReader>>();

    private void ParseAndHandleEvent(EventType type, StringReader reader)
    {
      _eventHandlerRegistry[type](this, reader);
    }

    private static void RegisterEventType<TEventType>(EventType eventType, Action<Engine, TEventType> eventHandler) where TEventType : Event, new()
    {
      _eventHandlerRegistry.Add(eventType, (engine, reader) =>
        {
          TEventType ev = new TEventType();
          ev.ReadFromStream(reader);
          eventHandler(engine, ev);
        });
    }

    static Engine()
    {
      RegisterEventType<IdEvent>(EventType.Id, (engine, ev) => engine.IdEvent(engine, ev));
      RegisterEventType<UciOkEvent>(EventType.UciOk, (engine, ev) => engine.UciOkEvent(engine, ev));
      RegisterEventType<ReadyOkEvent>(EventType.ReadyOk, (engine, ev) => engine.ReadyOkEvent(engine, ev));
      RegisterEventType<BestMoveEvent>(EventType.BestMove, (engine, ev) => engine.BestMoveEvent(engine, ev));
      RegisterEventType<CopyProtectionEvent>(EventType.CopyProtection, (engine, ev) => engine.CopyProtectionEvent(engine, ev));
      RegisterEventType<RegistrationEvent>(EventType.Registration, (engine, ev) => engine.RegistrationEvent(engine, ev));
      RegisterEventType<InfoEvent>(EventType.Info, (engine, ev) => engine.InfoEvent(engine, ev));
      RegisterEventType<OptionEvent>(EventType.Option, (engine, ev) => engine.OptionEvent(engine, ev));
    }

    public Engine(StreamReader reader, StreamWriter writer)
    {
      _reader = reader;
      _writer = writer;
      _eventProcessorTask = new Task(ProcessEvents);
    }

    public void Run()
    {
      _eventProcessorTask.Start();
    }

    private void ProcessEvents()
    {
      string line;
      while ((line = _reader.ReadLine()) != null)
      {
        StringReader stringReader = new StringReader(line);
        EventType eventType = EnumDescriptionToValueMapper<EventType>.GetValueByDescription(stringReader.ReadWord());
        ParseAndHandleEvent(eventType, stringReader);
      }

    }

    public void SetPosition(EnginePositionDef position, string[] moves)
    {
      string movesStr = moves.Length > 0 ? String.Format("moves {0}", String.Join(" ", moves)) : "";
      _writer.WriteLine(String.Join(" ", "position", position, movesStr));
    }

    public void SetOption(string name, string value)
    {
      _writer.WriteLine("go");
    }

    public void Go()
    {
      _writer.WriteLine("go");
    }

    public void Stop()
    {
      _writer.WriteLine("stop");
    }

    public void Quit()
    {
      _writer.WriteLine("quit");
    }

    public event EventHandler<EventArgs<IdEvent>> IdEvent;
    public event EventHandler<EventArgs<UciOkEvent>> UciOkEvent;
    public event EventHandler<EventArgs<ReadyOkEvent>> ReadyOkEvent;
    public event EventHandler<EventArgs<BestMoveEvent>> BestMoveEvent;
    public event EventHandler<EventArgs<CopyProtectionEvent>> CopyProtectionEvent;
    public event EventHandler<EventArgs<RegistrationEvent>> RegistrationEvent;
    public event EventHandler<EventArgs<InfoEvent>> InfoEvent;
    public event EventHandler<EventArgs<OptionEvent>> OptionEvent;

    public void Dispose()
    {
      _eventProcessorTask.Wait();
    }
  }
}
