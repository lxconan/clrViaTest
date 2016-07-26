using System;
using System.Collections.Generic;
using Xunit;

namespace BanKai.Progress.LinqRelated
{
    public class DividableInteger
    {
        [Fact]
        public void should_choose_dividable_integer()
        {
            int[] collectionA = { 4, 7, 9, 25, 16, 21, 64, 32, 35, 49 };
            int[] collectionB = { 2, 3, 5 };
            int[] expectedResults = {4, 9, 16, 21, 25, 32, 35, 64};

            Assert.Equal(
                expectedResults,
                ChooseDividableNumberFromCollection(collectionA, collectionB));
        }

        IEnumerable<int> ChooseDividableNumberFromCollection(
            IEnumerable<int> source,
            IEnumerable<int> dividers)
        {
            throw new NotImplementedException();
        }
    }
}