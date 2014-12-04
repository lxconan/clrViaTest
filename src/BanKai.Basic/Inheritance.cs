using System.Text;
using BanKai.Basic.Common;
using FluentAssertions;
using Xunit;

namespace BanKai.Basic
{
    // ReSharper disable ConditionIsAlwaysTrueOrFalse
    // ReSharper disable ExpressionIsAlwaysNull

    public class Inheritance
    {
        [Fact]
        public void should_access_public_memeber_in_derived_class()
        {
            var demoClass = new InheritMemberAccessDemoClass();

            // please change the variable value to correct one.
            const string expected = "";

            demoClass.PublicProperty.Should().Be(expected);
        }

        [Fact]
        public void should_access_protected_member_in_derived_class()
        {
            var demoClass = new InheritMemberAccessDemoClass();

            string actualValue = demoClass.ManipulateProtectedMember();

            // please change the variable value to correct one.            
            const string expected = "";

            actualValue.Should().Be(expected);
        }

        [Fact]
        public void should_access_member_of_most_derived_class()
        {
            var demoClass = new PolymorphismDemoClass();
            var castToBaseClass = (PolymorphismDemoClassBase) demoClass;

            string actualValue = castToBaseClass.VirtualMethod();

            // please change the variable value to correct one.
            const string expected = "";

            actualValue.Should().Be(expected);
        }

        [Fact]
        public void should_return_casted_result_if_it_is_castable()
        {
            var demoClass = new PolymorphismDemoClass();
            var castToBaseClass = demoClass as PolymorphismDemoClassBase;

            bool isNull = castToBaseClass == null;

            // please change the variable value to correct one.
            const bool expected = true;

            isNull.Should().Be(expected);
        }

        [Fact]
        public void should_return_null_if_it_is_not_castable()
        {
            var demoClass = new PolymorphismDemoClass();
            object castToObject = demoClass;

            var castResult = castToObject as StringBuilder;
            bool isNull = castResult == null;

            // please change the variable value to correct one.
            const bool expected = false;

            isNull.Should().Be(expected);
        }
    }

    // ReSharper restore ExpressionIsAlwaysNull
    // ReSharper restore ConditionIsAlwaysTrueOrFalse
}