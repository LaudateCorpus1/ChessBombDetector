using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBombDetector.Utils
{
    static class StringReaderExtension
    {
        public static string ReadWord(this StringReader reader)
        {
            StringWriter word = null;
            char c;
            do
            {
                int readRes = reader.Read();
                if (readRes == -1)
                    break;
                word = new StringWriter();
                c = Convert.ToChar(readRes);
                if (c != ' ')
                    word.Write(c);
            } while (c != ' ');
            return (word != null) ? word.ToString() : null;
        }
    }
}
