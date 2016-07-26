using System.Collections.Generic;
using Xunit;

namespace BanKai.Progress.LinqRelated
{
    public class CollectEvenNumber
    {
        [Fact]
        public void should_collect_all_even_number()
        {
            int[] source = { 1, 2, 3, 4, 5 };
            int[] expected = { 2, 4 };

            IEnumerable<int> result = CollectAllEvenNumbers(source);

            Assert.Equal(expected, result);
        }

        static IEnumerable<int> CollectAllEvenNumbers(int[] source)
        {
            // TODO: write your implementation here.
            throw new System.NotImplementedException();
        }
    }
}