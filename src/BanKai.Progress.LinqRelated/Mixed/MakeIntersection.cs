using System.Collections.Generic;
using Xunit;

namespace BanKai.Progress.LinqRelated.Mixed
{
    public class MakeIntersection
    {
        [Fact]
        public void should_get_intersection()
        {
            int[] collectionA = { 10, 27, 28, 19, 5 };
            int[] collectionB = { 5, 78, 28, 19, 23 };
            int[] intersection = { 5, 28, 19 };

            Assert.Equal(intersection, GetIntersection(collectionA, collectionB));
        }

        static IEnumerable<int> GetIntersection(IEnumerable<int> c1, IEnumerable<int> c2)
        {
            throw new System.NotImplementedException();
        }
    }
}