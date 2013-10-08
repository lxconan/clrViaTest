using BanKai.HackedStruct;
using FluentAssertions;
using Xunit;

namespace BanKai.TypeAndMember
{
    public class ValueTypeConstructorFact
    {
        internal struct Point
        {
            private int m_x;
            private int m_y;

            public Point(int x, int y)
            {
                m_x = x;
                m_y = y;
            }

            public int X { get { return m_x; } }
            public int Y { get { return m_y; } }
        }

        [Fact]
        public void there_will_always_be_a_default_ctor_for_value_type()
        {
            var point = new Point();

            point.X.Should().Be(1);
            point.Y.Should().Be(1);
        }

        internal class ThisIsTricky
        {
            public StructWithHackedDefaultCtor valueTypeInstance;
        }

        [Fact]
        public void default_ctor_of_value_type_will_execute_only_when_explicitly_called()
        {
            var point = new StructWithHackedDefaultCtor();

            point.X.Should().Be(5);
            point.Y.Should().Be(5);

            var tricky = new ThisIsTricky();
            tricky.valueTypeInstance.Should().NotBeNull();

            // so far, so good.
            tricky.valueTypeInstance.X.Should().Be(5);
            tricky.valueTypeInstance.Y.Should().Be(5);
        }
    }
}