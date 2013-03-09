using System;

namespace ChessBombDetector.Events
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
