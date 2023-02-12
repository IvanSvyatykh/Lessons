using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Dynamic;

namespace Lessons
{
    public interface IHashable
    {
        int GetHash();
    }
    class MyInt : IHashable
    {
        public int Value;
        public MyInt(int value) 
        {
            Value = value;
        }
        public int GetHash()
        {
            return Value.GetHashCode();
        }
    }
    public class Set<TValue> : IEnumerable<TValue>
        where TValue : IHashable
    {
        private List<TValue> _data { get; } = new List<TValue>();

        public void Add(TValue value)
        {
            if (IsContains(value))
            {
                _data.Add(value);
            }

        }
        private bool IsContains(TValue value)
        {
            foreach (var item in _data)
            {
                if (item.GetHash() == value.GetHash()) return false;
            }
            return true;
        }
        public IEnumerator<TValue> GetEnumerator()
        {
            return ((IEnumerable<TValue>)_data).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        public TValue this[int index]
        {
            get
            {
                return _data[index];
            }
        }

    }

    public class Program
    {
        static void Main()
        {
            Set<MyInt> ints = new Set<MyInt>();
            ints.Add(new MyInt(5));
            ints.Add(new MyInt(6));
            ints.Add(new MyInt(7));
            ints.Add(new MyInt(5));
            ints.Add(new MyInt(7));

            foreach (var item in ints) 
            {
                Console.WriteLine(item.Value);    
            }

        }
    }
}
