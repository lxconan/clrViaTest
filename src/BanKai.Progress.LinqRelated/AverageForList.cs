using Xunit;

namespace BanKai.Progress.LinqRelated
{
    public class AverageForList
    {
        [Fact]
        public void should_calculate_average()
        {
            const string listString = "1->3->5->98->67->456";
            const int expect = 105;

            Assert.Equal(expect, CalculateAverage(listString));
        }

        static int CalculateAverage(string listString)
        {
            throw new System.NotImplementedException();
        }
    }
}