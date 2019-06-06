using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Thanos.Common
{
    public static class Extensions
    {
        public static List<T> ReduceByHalf<T>(this List<T> input)
        {
            var output = new List<T>(input);

            int halfOfCount = output.Count() / 2;
            var random = new Random();

            var shuffledList = output.OrderBy(i => random.Next()).ToList();
            shuffledList.RemoveRange(0, halfOfCount);

            output = output.Where(x => shuffledList.Contains(x)).ToList();

            return output;
        }
    }
}
