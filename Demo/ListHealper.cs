using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    public delegate bool FilterNum<T>(T x);
    internal static class ListHealper
    {
        // public static List<T> Filter<T>(List<T> list, Func<T,bool> filter)
        public static List<T> Filter<T>(List<T> list, Predicate<T> filter)
        {
            List<T> result = new List<T>();
            foreach (T i in list)
            {
                if (filter(i)) 
                    result.Add(i);
            }
            return result;
        }

        public static bool IsEven(int n) => n % 2 == 0;
        public static bool IsOdd(int n) => n % 2 != 0;
    }
}
