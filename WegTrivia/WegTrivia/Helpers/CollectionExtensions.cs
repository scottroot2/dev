using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WegTrivia.Helpers
{
    public static class CollectionExtensions
    {
        public static T GetRandomItem<T>(this IEnumerable<T> list)
        {
            if (list == null)
                return default(T);

            int min = 0;
            int max = list.Count<T>();

            Random rnd = new Random();
            int index = rnd.Next(min, max);
            return (T) list.ToList<T>()[index];
        }
    }
}
