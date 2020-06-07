using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Assortment
{
    

    public class Perm
    {
        public static IEnumerable<IEnumerable<int>> GetAllPerm(IEnumerable<int> numbers)
        {
            var permutations = new List<List<int>>();

            permutations.Add(numbers.ToList());

            return permutations;
        }

        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }
    }
}