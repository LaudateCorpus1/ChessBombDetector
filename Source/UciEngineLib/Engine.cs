using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
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

    private static readonly log4net.ILog log = log4net.LogManager.GetLogger
        (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType); 
    
    private readonly StreamReader _reader;

    private readonly StreamWriter _writer;

    private readonly Task _eventProcessorTask;

    private static EngineEventParser _eventParser = new EngineEventParser();

    private static EngineEventDispatcher _eventDispatcher =
            new EngineEventDispatcher();

    private static void RegisterEventType<TEventType>(EventType eventType, Action<object, TEventType> eventHandler) where TEventType : Event, new()
    {
      _eventParser.RegisterEventType<TEventType>(eventType);
      _eventDispatcher.RegisterEventType(eventType, eventHandler);
    }

    static Engine()
    {
      RegisterEventType<IdEvent>(EventType.Id, (sender, ev) => ((Engine)sender).IdEvent(sender, ev));
      RegisterEventType<UciOkEvent>(EventType.UciOk, (sender, ev) => ((Engine)sender).UciOkEvent(sender, ev));
      RegisterEventType<ReadyOkEvent>(EventType.ReadyOk, (sender, ev) => ((Engine)sender).ReadyOkEvent(sender, ev));
      RegisterEventType<BestMoveEvent>(EventType.BestMove, (sender, ev) => ((Engine)sender).BestMoveEvent(sender, ev));
      RegisterEventType<CopyProtectionEvent>(EventType.CopyProtection, (sender, ev) => ((Engine)sender).CopyProtectionEvent(sender, ev));
      RegisterEventType<RegistrationEvent>(EventType.Registration, (sender, ev) => ((Engine)sender).RegistrationEvent(sender, ev));
      RegisterEventType<InfoEvent>(EventType.Info, (sender, ev) => ((Engine)sender).InfoEvent(sender, ev));
      RegisterEventType<OptionEvent>(EventType.Option, (sender, ev) => ((Engine)sender).OptionEvent(sender, ev));
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
        try
        {
          _eventDispatcher.HandleEvent(this, _eventParser.ParseEvent(line));
        }
        catch (Exception e)
        {
          log.ErrorFormat("Error handling event '{0}': {1}", line, e);  
        }
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
