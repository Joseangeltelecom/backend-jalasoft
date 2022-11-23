using System;
using System.Collections.Generic;

namespace FilterExtensionMethod
{
    public static class ExtentionMethod
    {
        public static IEnumerable<T> Filter1<T>(this IEnumerable<T> source, Func<T, bool> callback)
        {
            foreach (T value in source)
            {
                var item = callback(value);
                if (item)
                {
                    yield return value;
                }
            }
        }

        public static IEnumerable<T> Filter2<T>(this IEnumerable<T> source, Func<T, bool> callback)
        {
            List<T> list2 = new List<T>();
            foreach (T value in source)
            {
                var item = callback(value);
                if (item)
                {
                    list2.Add(value);
                }
            }
            return list2;
        }

        public static void PrintPrimitive<T>(this IEnumerable<T> source)
        {
            foreach (T value in source)
            {
                    Console.WriteLine(value);
            }
        }
    }
}
