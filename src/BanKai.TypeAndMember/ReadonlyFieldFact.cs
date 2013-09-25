using Xunit;

namespace BanKai.TypeAndMember
{
    public class ReadonlyFieldFact
    {
        private class ReadonlySample
        {
            public readonly char[] InvalidChars = new[] {'a', 'b', 'c'};
        }

        [Fact]
        public void the_read_only_field_only_protect_the_reference_rather_than_inner_data()
        {
            var readonlySample = new ReadonlySample();
            readonlySample.InvalidChars[0] = 'X';
            readonlySample.InvalidChars[1] = 'Y';
            readonlySample.InvalidChars[2] = 'Z';

            Assert.Equal(new [] {'a', 'b', 'c'}, readonlySample.InvalidChars);
        }
    }
}