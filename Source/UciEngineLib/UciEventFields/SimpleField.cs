using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBombDetector.UciEventFields
{
  class SimpleField<T>: UciEventField where T: struct
  {
    public T Value { get; private set; }
  }
}
