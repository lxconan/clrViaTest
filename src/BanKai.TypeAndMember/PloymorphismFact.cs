using Xunit;

namespace BanKai.TypeAndMember
{
    public class PloymorphismFact
    {
        private class Calculator
        {
            public int GetResult(int number)
            {
                return number * GetFactor();
            }

            protected virtual int GetFactor()
            {
                return 1;
            }
        }

        private class CalculatorA : Calculator
        {
            protected override int GetFactor()
            {
                return 2;
            }
        }

        // ReSharper disable once ClassWithVirtualMembersNeverInherited.Local
        private class CalculatorB : Calculator
        {
            protected virtual new int GetFactor()
            {
                return 7;
            }
        }

        // ReSharper disable once ClassWithVirtualMembersNeverInherited.Local
        private class CalculatorC : Calculator
        {
            public new int GetResult(int number)
            {
                return base.GetResult(number) * 3;
            }

            protected virtual new int GetFactor()
            {
                return 8;
            }
        }

        [Fact]
        public void should_call_override_get_factor_method_for_polymorphism()
        {
            var calculatorA = new CalculatorA();
            Assert.Equal(0, calculatorA.GetResult(9));
        }

        [Fact]
        public void the_method_has_no_relation_ship_with_base_using_new_keyword()
        {
            var calculatorB = new CalculatorB();
            Assert.Equal(0, calculatorB.GetResult(9));
        }

        [Fact]
        public void a_more_complex_situation_using_new_keyword()
        {
            var calculatorC = new CalculatorC();
            Assert.Equal(0, calculatorC.GetResult(9));
        }
    }
}