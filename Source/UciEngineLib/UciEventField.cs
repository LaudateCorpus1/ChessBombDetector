using System.IO;

namespace ChessBombDetector
{
    abstract class UciEventField
    {
      protected abstract void ReadFromStream(StreamReader reader);
    }
}