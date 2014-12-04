using System;
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

            // please change the variable value to fix the test.
            const string expected = "";

            demoClass.PublicProperty.Should().Be(expected);
        }

        [Fact]
        public void should_access_protected_member_in_derived_class()
        {
            var demoClass = new InheritMemberAccessDemoClass();

            string actualValue = demoClass.ManipulateProtectedMember();

            // please change the variable value to fix the test.            
            const string expected = "";

            actualValue.Should().Be(expected);
        }

        [Fact]
        public void should_access_member_of_most_derived_class()
        {
            var demoClass = new PolymorphismDemoClass();
            var castToBaseClass = (PolymorphismDemoClassBase) demoClass;

            string actualValue = castToBaseClass.VirtualMethod();

            // please change the variable value to fix the test.
            const string expected = "";

            actualValue.Should().Be(expected);
        }

        [Fact]
        public void should_return_casted_result_if_it_is_castable()
        {
            var demoClass = new PolymorphismDemoClass();
            var castToBaseClass = demoClass as PolymorphismDemoClassBase;

            bool isNull = castToBaseClass == null;

            // please change the variable value to fix the test.
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

            // please change the variable value to fix the test.
            const bool expected = false;

            isNull.Should().Be(expected);
        }

        [Fact]
        public void should_throw_exception_if_it_is_not_castable()
        {
            var demoClass = new PolymorphismDemoClass();
            object castToObject = demoClass;

            // please change the variable value to fix the test.
            Type expectedExceptionType = typeof(ArgumentException);

            expectedExceptionType.Should().NotBe(typeof(SystemException));
            expectedExceptionType.Should().NotBe(typeof(Exception));
            Assert.Throws(expectedExceptionType, () => (StringBuilder) castToObject);
        }

        [Fact]
        public void should_reference_to_same_object_after_casting()
        {
            var demoClass = new PolymorphismDemoClass();
            var castToBaseClass = (PolymorphismDemoClassBase)demoClass;

            bool referenceEqual = ReferenceEquals(demoClass, castToBaseClass);

            // please change the variable value to fix the test.
            const bool expected = false;

            Assert.Equal(expected, referenceEqual);
        }

        [Fact]
        public void should_throw_exception_when_downcasting_fail()
        {
            var demoClassBase = new PolymorphismDemoClassBase();

            // please change the variable value to fix the test.
            Type expectedExceptionType = typeof(ArgumentException);

            expectedExceptionType.Should().NotBe(typeof(SystemException));
            expectedExceptionType.Should().NotBe(typeof(Exception));
            Assert.Throws(expectedExceptionType, () => (PolymorphismDemoClass)demoClassBase);
        }

        [Fact]
        public void should_be_able_to_hide_non_virtual_method_in_derived_class()
        {
            var demoClass = new HideMemberDemoClass();
            var castedToBaseClass = (HideMemberDemoClassBase) demoClass;

            string methodReturnValue = demoClass.MethodToHide();
            string baseClassMethodReturnValue = castedToBaseClass.MethodToHide();

            // please change the following 2 variable values to fix the test.
            const string expectedMethodReturnValue = "";
            const string expectedBaseClassMethodReturnValue = "";

            methodReturnValue.Should().Be(expectedMethodReturnValue);
            baseClassMethodReturnValue.Should().Be(expectedBaseClassMethodReturnValue);
        }

        [Fact]
        public void should_be_able_to_get_base_class_members_using_base_keyword()
        {
            var demoClass = new BaseKeywordDemoClass();

            string name = demoClass.Name;

            // please change the variable value to fix the test.
            const string expected = "";

            name.Should().Be(expected);
        }

        [Fact]
        public void should_call_default_constructors_of_base_class()
        {
            var demoClass = new InheritanceConstructorCallDemoClass();

            string message = demoClass.ConstructorCallMessage;

            // please change the variable value to fix the test.
            const string expected = "";

            message.Should().Be(expected);
        }

        [Fact]
        public void should_call_default_constructor_of_base_class_when_call_derived_ctor_with_args()
        {
            var demoClass = new InheritanceConstructorCallDemoClass(1);

            string message = demoClass.ConstructorCallMessage;

            // please change the variable value to fix the test.
            const string expected = "";

            message.Should().Be(expected);
        }

        [Fact]
        public void should_be_able_to_specify_which_base_ctor_to_call()
        {
            var demoClass = new InheritanceConstructorCallDemoClass("1");

            string message = demoClass.ConstructorCallMessage;

            // please change the variable value to fix the test.
            const string expected = "";

            message.Should().Be(expected);
        }

        [Fact]
        public void should_be_able_to_specify_which_ctor_of_current_class_to_call()
        {
            var demoClass = new InheritanceConstructorCallDemoClass(1, "1");

            string message = demoClass.ConstructorCallMessage;

            // please change the variable value to fix the test.
            const string expected = "";

            message.Should().Be(expected);
        }

        [Fact]
        public void should_be_able_to_choose_most_specific_type_when_overloading()
        {
            var demoClass = new MethodOverloadDemoClass();

            string returnValueForBaseClassOverloading = 
                demoClass.Foo(new MethodOverloadBaseClass());
            string returnValueForDerivedClassOverloading =
                demoClass.Foo(new MethodOverloadDerivedClass());
            string returnValueForCastingOverloading =
                demoClass.Foo((MethodOverloadBaseClass) (new MethodOverloadDerivedClass()));

            const string expectedBaseClassOverloadingValue = "";
            const string expectedDerivedClassOverloadingValue = "";
            const string expectedCastOverloadingValue = "";

            returnValueForBaseClassOverloading.Should().Be(expectedBaseClassOverloadingValue);
            returnValueForDerivedClassOverloading.Should().Be(expectedDerivedClassOverloadingValue);
            returnValueForCastingOverloading.Should().Be(expectedCastOverloadingValue);
        }
    }

    // ReSharper restore ExpressionIsAlwaysNull
    // ReSharper restore ConditionIsAlwaysTrueOrFalse
}