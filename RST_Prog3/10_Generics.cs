using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace RST_Prog3
{
    public interface IUnique<T>
    {
        public T ID { get; }
    }

    public class Employee : IUnique<string>
    {
        public string ID { get; }

        public Employee(string id)
        {
            this.ID = id;
        }
    }

    public class Student : IUnique<int>
    {
        public int ID { get; }

        public Student(int id)
        {
            this.ID = id;
        }
    }

    public class Article<T, U, V> : IUnique<T> /* where V : IComparable */
    {
        public T ID { get; }
        public (U Key, V Value) KeyValue { get; set; }

        public Article(T id, U key, V value)
        {
            this.ID = id;
            this.KeyValue = (key, value);
        }

        /*
        public int CompareSpecial(V par1, V par2)
        {
            return par1.CompareTo(par2);
        }
        */
    }

    public static class GenericExtensions
    {
        public static string WriteEnumerable<T>(this IEnumerable<T> lst, string separator = ",")
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            bool first = true;
            foreach (T elt in lst)
            {
                if (first)
                {
                    sb.Append(elt);
                }
                else
                {
                    sb.Append(separator + " " + elt);
                }
                first = false;
            }
            sb.Append("}");
            return sb.ToString();
        }
    }
}
