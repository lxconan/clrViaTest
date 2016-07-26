using System.Collections.Generic;
using Xunit;

namespace BanKai.Progress.LinqRelated
{
    public class NumberSequence
    {
        [Fact]
        public void should_get_number_sequence_incrementally()
        {
            int[] expectedResult = {1, 2, 3, 4, 5};

            Assert.Equal(expectedResult, GetNumberSequence(1, 5));
        }

        [Fact]
        public void should_get_number_sequence_decrementally()
        {
            int[] expectedResult = {5, 4, 3, 2, 1};

            Assert.Equal(expectedResult, GetNumberSequence(5, 1));
        }

        [Fact]
        public void should_get_number()
        {
            int[] expectedResult = {5};

            Assert.Equal(expectedResult, GetNumberSequence(5, 5));
        }

        static IEnumerable<int> GetNumberSequence(int start, int end)
        {
            // TODO: write your code here.
            throw new System.NotImplementedException();
        }
    }
}