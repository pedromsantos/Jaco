using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

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
    }
}
