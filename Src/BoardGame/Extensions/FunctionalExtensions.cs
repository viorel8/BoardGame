using System;
using System.Collections.Generic;
using System.Linq;

namespace BoardGame
{
    public static class FunctionalExtensions
    {
        public static IEnumerable<IEnumerable<T>> Partition<T>(this IEnumerable<T> l, int sizeOfSubsequences)
        {
            return l.Select((x, i) => new { Group = i / sizeOfSubsequences, Value = x })
                .GroupBy(item => item.Group, g => g.Value)
                .Select(g => g.Where(x => true));
        }


        public static T Next<T>(this T src) where T : struct
        {
            if (!typeof(T).IsEnum) throw new ArgumentException(String.Format("Argumnent {0} is not an Enum", typeof(T).FullName));

            T[] Arr = (T[])Enum.GetValues(src.GetType());
            int j = Array.IndexOf<T>(Arr, src) + 1;
            return (Arr.Length == j) ? Arr[0] : Arr[j];
        }

        public static T Prev<T>(this T src) where T : struct
        {
            if (!typeof(T).IsEnum) throw new ArgumentException(String.Format("Argumnent {0} is not an Enum", typeof(T).FullName));

            T[] Arr = (T[])Enum.GetValues(src.GetType());
            int j = Array.IndexOf<T>(Arr, src) - 1;
            return (Arr.Length == j) ? Arr[0] : Arr[j];
        }
    }

}
