using System.IO;

namespace UciEngineLib.EventFields
{
    public abstract class EventField
    {
        public abstract void ReadFromStream(StringReader reader);
    }
}