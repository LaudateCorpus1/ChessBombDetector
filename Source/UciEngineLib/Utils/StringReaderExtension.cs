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
            string word = "";
            char c;
            do
            {
                c = Convert.ToChar(reader.Read());
                word += c;
            } while (c != ' ');
            return word;
        }
    }
}
