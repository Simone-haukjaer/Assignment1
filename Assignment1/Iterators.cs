using System;
using System.Collections.Generic;

namespace BDSA2019.Assignment01
{
    public static class Iterators
    {
        public static IEnumerable<T> Flatten<T>(IEnumerable<IEnumerable<T>> items)
        {
            var list = new List<T>();
            foreach (var item in items)
            {
                foreach (var it in item)
                {
                    list.Add(it);
                }
            }
            return list;
        }

        public static IEnumerable<T> Filter<T>(IEnumerable<T> items, Predicate<T> predicate)
        {
            var list = new List<T>();

            foreach (var item in items)
            {
                if (predicate.Invoke(item))
                {
                    list.Add(item);
                }
            }
            return list;
        }
    }
}
