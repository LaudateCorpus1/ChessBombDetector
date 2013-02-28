using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBombDetector
{
  [System.AttributeUsage(AttributeTargets.Class)]
  class UciFieldIdAttribute : Attribute
  {
    public string FieldId { get; private set; }
    
    public UciFieldIdAttribute(string fieldId)
    {
      FieldId = fieldId;
    }
  }
}
