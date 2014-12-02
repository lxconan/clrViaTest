using BanKai.Basic.Common;
using BanKai.Basic.Extensions;
using FluentAssertions;
using Xunit;

namespace BanKai.Basic
{
    public class Classes
    {
        [Fact]
        public void should_choose_correct_overloading_method_at_compile_time_1()
        {
            var demoObject = new MethodOverloadDemoClass();

            string chosenOne = demoObject.Foo(1);

            // change variable value to correct one.
            const string expected = "Foo()";

            chosenOne.Should().Be(expected);
        }

        [Fact]
        public void should_choose_correct_overloading_method_at_compile_time_2()
        {
            var demoObject = new MethodOverloadDemoClass();

            string chosenOne = demoObject.Foo((object)1);

            // change variable value to correct one.
            const string expected = "Foo()";

            chosenOne.Should().Be(expected);
        }

        [Fact]
        public void should_choose_correct_overloading_method_at_compile_time_3()
        {
            var demoObject = new MethodOverloadDemoClass();

            const short argument = 2;
            string chosenOne = demoObject.Foo(argument);

            // change variable value to correct one.
            const string expected = "Foo()";

            chosenOne.Should().Be(expected);
        }

        [Fact]
        public void should_call_other_instance_constructor_in_overload_constructor()
        {
            var demoClass = new ConstructorOverloadingDemoClass("arg");

            string constructorCallSequence = demoClass.ConstructorCallSequence;

            // change variable value to correct one.
            const string expectedSequence = "Ctor(string)";

            constructorCallSequence.Should().Be(expectedSequence);
        }

        [Fact]
        public void should_generate_parameterless_constructor_by_default()
        {
            var demoClass = new ImplicitConstructorClassDemo();

            bool hasDefaultConstructor = demoClass.HasDefaultConstructor();

            // change variable value to correct one.
            const bool expected = false;

            hasDefaultConstructor.Should().Be(expected);
        }

        [Fact]
        public void should_not_generate_parameterless_constructor_if_parameterized_constructor_exists()
        {
            var demoClass = new ParameterizedConstructorClassDemo(1);

            bool hasDefaultConstructor = demoClass.HasDefaultConstructor();

            // change variable value to correct one.
            const bool expected = true;

            hasDefaultConstructor.Should().Be(expected);
        }

        [Fact]
        public void should_initailize_object_properties()
        {
            var demoClass = new ObjectInitializerDemoClass("property1")
            {
                // add property initialization logic here.
            };

            const string expectedProperty1 = "property1.1";
            const string expectedProperty2 = "property2.1";

            demoClass.Property1.Should().Be(expectedProperty1);
            demoClass.Property2.Should().Be(expectedProperty2);
        }
    }
}