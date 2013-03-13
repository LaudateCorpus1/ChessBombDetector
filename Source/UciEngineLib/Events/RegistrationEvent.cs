using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UciEngineLib.Events
{
  public class RegistrationEvent : Event
  {
    public RegistrationEvent()
      : base(EventType.Registration)
    {
    }
  }
}
