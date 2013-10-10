using FluentAssertions;
using Xunit;

namespace BanKai.TypeAndMember
{
    public class ConversionOperatorFact
    {
        public sealed class Duck
        {
            public int Id { get; set; }
            public static implicit operator Duck(int id)
            {
                return new Duck {Id = id};
            }

            public static explicit operator Duck(string idStr)
            {
                return new Duck {Id = int.Parse(idStr)};
            }
        }

        [Fact]
        public void implicit_conversion_op_will_do_cast_automatically()
        {
            Duck duck = 5;
            duck.Id.Should().Be(default(int));
        } 

        [Fact]
        public void explicit_conversion_op_requires_explicit_cast_operator()
        {
            var duck = (Duck)"23";
            duck.Id.Should().Be(default(int));
        }

        [Fact]
        public void the_casting_op_will_never_invoke_when_using_as_or_is_operator()
        {
            5.GetType().Should().Be(typeof (Duck));
            (5 is Duck).Should().BeTrue();
        }
    }
}