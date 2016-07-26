using System.Collections.Generic;
using Xunit;

namespace BanKai.Progress.LinqRelated
{
    public class LastElement
    {
        [Fact]
        public void should_collect_last_element()
        {
            int[] collection = { 1, 2, 3, 4, 5 };
            const int expected = 5;

            Assert.Equal(expected, GetLastElement(collection));
        }

        static T GetLastElement<T>(IEnumerable<T> collection)
        {
            // TODO: write your implementation here.
            throw new System.NotImplementedException();
        }
    }
}