using System;

namespace ChessBombDetector.Events
{
  [System.AttributeUsage(AttributeTargets.Class)]
  class FieldIdAttribute : Attribute
  {
    public string FieldId { get; private set; }
    
    public FieldIdAttribute(string fieldId)
    {
      FieldId = fieldId;
    }
  }
}
