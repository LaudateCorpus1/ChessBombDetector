using System.IO;

namespace ChessBombDetector.EventFields
{
    abstract class UciEventField
    {
        protected abstract void ReadFromStream(StringReader reader);
    }
}