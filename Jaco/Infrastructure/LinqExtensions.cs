using System;
using System.Collections.Generic;
using System.Linq;

namespace Jaco.Infrastructure
{
    public static class LinqExtensions
    {
        public static IList<T> Swap<T>(this IList<T> list, int indexA, int indexB)
        {
            var tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
            return list;
        }

        public static IList<T> Rotate<T>(this IList<T> list)
        {
            return list.Skip(1).Concat(list.Take(1)).ToList();
        }

        public static IEnumerable<T> Rotate<T>(this IEnumerable<T> list)
        {
            return list.Skip(1).Concat(list.Take(1)).ToList();
        }

        public static TSource MinBy<TSource, TKey>(this IEnumerable<TSource> source, 
            Func<TSource, TKey> selector)
        {
            return source.MinBy(selector, Comparer<TKey>.Default);
        }

        public static TSource MinBy<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> selector, IComparer<TKey> comparer)
        {
            using (IEnumerator<TSource> sourceIterator = source.GetEnumerator())
            {
                if (!sourceIterator.MoveNext())
                {
                    throw new InvalidOperationException("Sequence was empty");
                }

                var min = sourceIterator.Current;
                var minKey = selector(min);

                while (sourceIterator.MoveNext())
                {
                    var candidate = sourceIterator.Current;
                    var candidateProjected = selector(candidate);

                    if (comparer.Compare(candidateProjected, minKey) < 0)
                    {
                        min = candidate;
                        minKey = candidateProjected;
                    }
                }

                return min;
            }
        }
    }
}
