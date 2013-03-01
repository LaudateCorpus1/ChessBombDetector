using System.IO;

namespace ChessBombDetector.Fields
{
    abstract class UciEventField
    {
      protected abstract void ReadFromStream(StreamReader reader);
    }
}