using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UciEngineLib.Utils
{
    static class EnumDescriptionToValueMapper<T> where T: struct
    {
        private static readonly Dictionary<string, T> _dictionary = 
            new Dictionary<string, T>();

        static EnumDescriptionToValueMapper()
        {
            foreach (T value in Enum.GetValues(typeof(T)))
            {
                string description = value.GetDescription<T>();
                if (description != null)
                {
                    _dictionary.Add(description, value);
                }
            }
        }

        public static T GetValueByDescription(string description)
        {
            return _dictionary[description];
        }

    }
}
