using System.Linq;
using BanKai.Basic.Common;
using FluentAssertions;
using Xunit;

namespace BanKai.Basic
{
    // ReSharper disable ConvertToConstant.Local
    // ReSharper disable RedundantAssignment
    // ReSharper disable UnusedVariable
    // ReSharper disable ExpressionIsAlwaysNull

    public class VariablesAndParameters
    {
        [Fact]
        public void should_initialize_to_default_value()
        {
            var defaultValueDemo = new DefaultValueDemoClass();

            // change the variable values of the following 2 lines to correct values
            var expectedReferenceTypeValue = new RefTypeClass(default(int));
            const int expectedValueTypeValue = 1;

            defaultValueDemo.referenceTypeValue.Should().Be(expectedReferenceTypeValue);
            defaultValueDemo.valueTypeValue.Should().Be(expectedValueTypeValue);
        }

        [Fact]
        public void should_get_default_value_using_default_operator()
        {
            // change the variable values of the following 4 lines to correct values.
            const int expectedDefaultIntResult = 1;
            const bool expectedDefaultBoolResult = true;
            const char expectedDefaultCharResult = 'a';
            var expectedDefaultObjectResult = new object();

            default(int).Should().Be(expectedDefaultIntResult);
            default(bool).Should().Be(expectedDefaultBoolResult);
            default(char).Should().Be(expectedDefaultCharResult);
            default(object).Should().Be(expectedDefaultObjectResult);
        }

        [Fact]
        public void should_get_copy_of_the_argument_when_passing_by_value_for_value_type()
        {
            int passingInt = 1;

            // change the variable value to correct one.
            const int expectedResult = 2;

            FunctionPassingIntAsArgument(passingInt);

            passingInt.Should().Be(expectedResult);
        }

        [Fact]
        public void should_get_copy_of_the_argument_when_passing_by_value_for_ref_type()
        {
            var refTypeObject = new RefTypeClass(1);
            RefTypeClass modifiedRefTypeObject = FunctionPassingRefTypeClassAsArgument(refTypeObject);

            // change the variable value to correct one.
            RefTypeClass expectedResult = modifiedRefTypeObject;

            refTypeObject.Should().BeSameAs(expectedResult);
        }

        [Fact]
        public void should_ref_to_same_location_when_passing_by_ref_for_value_type()
        {
            int passingInt = 1;

            // change the variable value to correct one.
            const int expectedResult = 1;

            FunctionPassingRefIntAsArgument(ref passingInt);

            passingInt.Should().Be(expectedResult);
        }

        [Fact]
        public void should_ref_to_same_location_when_passing_by_ref_for_ref_type()
        {
            var refTypeObject = new RefTypeClass(1);
            RefTypeClass refToOriginalObject = refTypeObject;

            RefTypeClass modifiedRefTypeObject = FunctionPassingRefRefTypeClassAsArgument(
                ref refTypeObject);

            // change the variable value to correct one
            object expectedResult = refToOriginalObject;
            refTypeObject.Should().BeSameAs(expectedResult);
        }

        [Fact]
        public void should_ref_to_same_location_when_passing_by_out_for_value_type()
        {
            int passingInt;

            FunctionPassingOutIntAsArgument(out passingInt);

            // change the variable value to correct one
            const int expectedResult = default(int);

            passingInt.Should().Be(expectedResult);
        }

        [Fact]
        public void should_ref_to_same_location_when_passing_by_out_for_ref_type()
        {
            RefTypeClass refTypeObject;

            RefTypeClass modifiedRefTypeObject =
                FunctionPassingOutRefTypeClassAsArgument(out refTypeObject);
            
            // change the variable value to correct one
            object expectedResult = default(object);

            refTypeObject.Should().Be(expectedResult);
        }

        [Fact]
        public void should_pass_variable_length_parameter_as_array()
        {
            int sum = PassVariableLengthArguments(1, 2, 3, 4, 5);

            // change the variable value to correct one
            const int expectedResult = default(int);

            sum.Should().Be(expectedResult);
        }

        [Fact]
        public void should_pass_as_optional_parameter()
        {
            int optionalParameterValue = PassAsOptionalArgument();

            // change the variable value to correct one
            const int expectedResult = default(int);

            optionalParameterValue.Should().Be(expectedResult);
        }

        private static int PassAsOptionalArgument(int value = 23)
        {
            return value;
        }

        private static int PassVariableLengthArguments(params int[] values)
        {
            return values.Sum(i => i);
        }

        private static RefTypeClass FunctionPassingOutRefTypeClassAsArgument(
            out RefTypeClass refTypeObject)
        {
            refTypeObject = new RefTypeClass(1);
            return refTypeObject;
        }

        private static void FunctionPassingOutIntAsArgument(out int passingInt)
        {
            passingInt = 2;
        }

        private RefTypeClass FunctionPassingRefRefTypeClassAsArgument(
            ref RefTypeClass refTypeObject)
        {
            refTypeObject = new RefTypeClass(2);
            return refTypeObject;
        }

        private static void FunctionPassingRefIntAsArgument(ref int passingInt)
        {
            passingInt = passingInt * 2;
        }

        private static RefTypeClass FunctionPassingRefTypeClassAsArgument(
            RefTypeClass refTypeObject)
        {
            refTypeObject = new RefTypeClass(2);
            return refTypeObject;
        }

        private static void FunctionPassingIntAsArgument(int value)
        {
            value = value * 2;
        }
    }

    // ReSharper restore ExpressionIsAlwaysNull
    // ReSharper restore UnusedVariable
    // ReSharper restore RedundantAssignment
    // ReSharper restore ConvertToConstant.Local
}