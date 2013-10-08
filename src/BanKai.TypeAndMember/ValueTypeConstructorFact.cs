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
    }
}