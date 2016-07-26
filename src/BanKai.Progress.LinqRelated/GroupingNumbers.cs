using System.Collections.Generic;
using Xunit;

namespace BanKai.Progress.LinqRelated
{
    public class GroupingNumbers
    {
        [Fact]
        public void should_grouping_count()
        {
            int[] collection = { 1, 1, 1, 1, 2, 3, 1, 3, 4, 2, 3, 1, 3, 4, 2 };
            int[] result = {6, 3, 4, 2};

            Assert.Equal(result, GroupingNumbersAndSort(collection));
        }

        static IEnumerable<int> GroupingNumbersAndSort(IEnumerable<int> collection)
        {
            throw new System.NotImplementedException();
        }
    }
}