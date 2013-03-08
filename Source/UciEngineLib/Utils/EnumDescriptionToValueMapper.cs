using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBombDetector.Utils
{
    static class EnumDescriptionToValueMapper<T> where T: struct
    {
        private static readonly Dictionary<string, T> _descriptionToValueMapping = 
            new Dictionary<string, T>();

        public static T GetValueByDescription(string description)
        {
            throw new NotImplementedException();
        }

    }
}
