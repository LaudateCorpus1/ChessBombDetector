using System;
using System.IO;
using ChessBombDetector.EventFields;

namespace ChessBombDetector.Events
{
    class CurrLineEventField : UciEventField
    {
        protected override void ReadFromStream(StringReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
