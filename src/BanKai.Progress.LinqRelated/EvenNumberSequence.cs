using System.Collections.Generic;
using Xunit;

namespace BanKai.Progress.LinqRelated
{
    public class EvenNumberSequence
    {
        [Fact]
        public void should_get_even_integer_sequence_increment()
        {
            int[] expected = {2, 4, 6, 8, 10};
            IEnumerable<int> result = GetEvenSequence(1, 10);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void should_get_even_integer_sequence_decrement()
        {
            int[] expected = {10, 8, 6, 4, 2};
            IEnumerable<int> result = GetEvenSequence(10, 1);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void should_get_single_even_number_if_start_and_end_are_same_even_number()
        {
            int[] expected = { 10 };
            IEnumerable<int> result = GetEvenSequence(10, 10);

            Assert.Equal(expected, result);
        }

        public void should_get_nothing_if_start_and_end_are_same_odd_number()
        {
            int[] expected = { };
            IEnumerable<int> result = GetEvenSequence(5, 5);

            Assert.Equal(expected, result);
        }

        static IEnumerable<int> GetEvenSequence(int start, int end)
        {
            // TODO: write your implementation here.
            throw new System.NotImplementedException();
        }
    }
}