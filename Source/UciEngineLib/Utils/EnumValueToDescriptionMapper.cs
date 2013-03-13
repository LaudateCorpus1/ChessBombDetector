using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UciEngineLib.Utils
{
    static class EnumValueToDescriptionMapper<T> where T: struct
    {
        private static readonly Dictionary<T, string> _dictionary =
            new Dictionary<T, string>();

        static EnumValueToDescriptionMapper()
        {
            foreach (T value in Enum.GetValues(typeof(T)))
            {
                string description = value.GetDescription<T>();
                if (description != null)
                {
                    _dictionary.Add(value, description);
                }
            }
        }
        
        public static string GetDescriptionByValue(T value)
        {
            return _dictionary[value];
        }
    }
}
