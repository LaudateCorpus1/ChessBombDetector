using System.IO;

namespace ChessBombDetector.EventFields
{
    public abstract class EventField
    {
        public abstract void ReadFromStream(StringReader reader);
    }
}