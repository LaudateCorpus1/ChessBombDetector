using System.IO;

namespace ChessBombDetector.EventFields
{
    abstract class EventField
    {
        protected abstract void ReadFromStream(StringReader reader);
    }
}