using System.IO;

namespace ChessBombDetector.EventFields
{
    public abstract class EventField
    {
        protected abstract void ReadFromStream(StringReader reader);
    }
}