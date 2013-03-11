using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessBombDetector.Utils;

namespace ChessBombDetector.Events
{
  public abstract class Event
  {
    private readonly EventType _type;

    public virtual void ReadFromStream(StringReader reader)
    {
    }

    public EventType Type
    {
      get { return _type; }
    }

    protected Event(EventType type)
    {
      _type = type;
    }

  }
}
