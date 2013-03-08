using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBombDetector.Utils
{
    static class EnumValueToDescriptionMapper<T> where T: struct
    {
        private static readonly Dictionary<string, T> _valueToDescriptionMapping =
            new Dictionary<string, T>();

        public static string GetDescriptionByValue(T value)
        {
            throw new NotImplementedException();
        }
    }
}
