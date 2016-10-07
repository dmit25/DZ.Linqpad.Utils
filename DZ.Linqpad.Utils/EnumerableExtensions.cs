using System;
using System.Collections.Generic;

namespace DZ.Linqpad.Utils
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Enumerates through objects calling action on each of them
        /// </summary>
        public static void ForEach<T>(this IEnumerable<T> input, Action<T> action)
        {
            foreach (var x1 in input)
            {
                action(x1);
            }
        }

        /// <summary>
        /// Returns index of element in an enumeration or -1 if it wasn't found
        /// </summary>
        public static int IndexOf<T>(this IEnumerable<T> source, Func<T, bool> select, int startIndex = 0)
        {
            var index = 0;
            foreach (var item in source)
            {
                if (index >= startIndex && @select(item))
                    return index;
                index += 1;
            }
            return -1;
        }

        /// <summary>
        /// Creates new hashset out of enumeration
        /// </summary>
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> input)
        {
            return new HashSet<T>(input);
        }

        /// <summary>
        /// Shuffles elements inside container
        /// </summary>
        public static IList<T> Shuffle<T>(this IList<T> list, Random rand)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rand.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }

        /// <summary>
        /// Returns array with entries and their frequencies
        /// </summary>
        public static Dictionary<T, int> GetFrequencyDistribution<T>(this IEnumerable<T> collection)
        {
            var dict = new Dictionary<T, int>();
            foreach (var item in collection)
            {
                int value;
                if (dict.TryGetValue(item, out value))
                {
                    dict[item] = value + 1;
                }
                else
                {
                    dict.Add(item, 1);
                }
            }
            return dict;
        }

        /// <summary>
        /// Returns array with entries and their frequencies
        /// </summary>
        public static Dictionary<TKey, Tuple<TItem, int>> GetFrequencyDistribution<TItem, TKey>(this IEnumerable<TItem> collection, Func<TItem, TKey> keySelector)
        {
            var dict = new Dictionary<TKey, Tuple<TItem, int>>();
            foreach (var item in collection)
            {
                Tuple<TItem, int> tuple;
                var key = keySelector(item);
                if (dict.TryGetValue(key, out tuple))
                {
                    dict[key] = Tuple.Create(item, tuple.Item2 + 1);
                }
                else
                {
                    dict.Add(key, Tuple.Create(item, 1));
                }
            }
            return dict;
        }
    }
}