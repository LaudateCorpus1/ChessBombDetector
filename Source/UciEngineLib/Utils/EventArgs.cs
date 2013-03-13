using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UciEngineLib.Utils
{
    public class EventArgs<T>
    {
        private readonly T _data;

        public T Data { get { return _data;  } }

        public EventArgs(T data)
        {
            _data = data;
        }

        public static implicit operator EventArgs<T>(T data)
        {
            return new EventArgs<T>(data);
        }
    }
}
