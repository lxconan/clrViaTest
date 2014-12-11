using System;
using FluentAssertions;
using Xunit;

namespace BanKai.Basic
{
    // ReSharper disable ConvertToConstant.Local
    // ReSharper disable RedundantAssignment
#pragma warning disable 219

    public class NumberOperations
    {
        [Fact]
        public void should_get_minimum_value_of_a_number_type()
        {
            // change "default(sbyte)" to correct value. You should not explicitly write -128.
            sbyte minimum = default(sbyte);

            minimum.Should().Be(-128);
        }

        [Fact]
        public void should_get_maximum_value_of_a_number_type()
        {
            // change "default(int)" to correct value. You should not explicitly write 2147483647.
            int maximum = default(int);

            maximum.Should().Be(2147483647);
        }

        [Fact]
        public void should_get_correct_type_for_floating_point_number_without_literal()
        {
            // change "typeof(string)" to correct type.
            Type guessTheType = typeof (string);

            1.0.GetType().Should().Be(guessTheType);
            1E3.GetType().Should().Be(guessTheType);
        }

        [Fact]
        public void should_get_correct_type_for_integer_without_literal()
        {
            // change "typeof(string)" to correct type.
            Type guessTheType = typeof (string);

            1.GetType().Should().Be(guessTheType);
            0x123.GetType().Should().Be(guessTheType);
        }

        [Fact]
        public void should_get_correct_type_for_M_literal()
        {
            // change "typeof(string)" to correct type.
            Type guessTheType = typeof (string);

            1M.GetType().Should().Be(guessTheType);
        }

        [Fact]
        public void should_get_correct_type_for_L_literal()
        {
            // change "typeof(string)" to correct type.
            Type guessTheType = typeof (string);

            5L.GetType().Should().Be(guessTheType);
        }

        [Fact]
        public void should_get_correct_type_for_F_literal()
        {
            // change "typeof(string)" to correct type.
            Type guessTheType = typeof (string);

            5F.GetType().Should().Be(guessTheType);
        }

        [Fact]
        public void should_cast_between_numeric_types()
        {
            int originNumber = 12345;
            long longNumber = originNumber;

            // change "default(long)" to correct value.
            const long expectedResult = default(long);

            longNumber.Should().Be(expectedResult);
        }

        [Fact]
        public void should_cast_between_numeric_types_safely()
        {
            int originNumber = 12345;
            var shortNumber = (short) originNumber;

            // change "default(short)" to correct value.
            const short expectedResult = default(short);

            shortNumber.Should().Be(expectedResult);
        }

        [Fact]
        public void should_truncate_value_when_cast_overflow()
        {
            int originNumber = 0x1234;
            var byteNumber = (byte) originNumber;

            // change "default(byte)" to correct value.
            const byte expectedResult = default(byte);

            byteNumber.Should().Be(expectedResult);
        }

        [Fact]
        public void should_never_count_on_integer_floating_number_casting()
        {
            int originalNumber = 100000001;
            float floatingPointNumber = originalNumber;
            var castedBackNumber = (int) floatingPointNumber;

            // change "default(int)" to correct value.
            const int expectedResult = default (int);

            castedBackNumber.Should().Be(expectedResult);
        }

        [Fact]
        public void should_use_fix_point_number_to_do_safe_casting_in_valid_range()
        {
            int originalNumber = 100000001;
            decimal decimalNumber = originalNumber;
            var castedBackNumber = (int)decimalNumber;

            // change "default(int)" to correct value.
            const int expectedResult = default(int);

            castedBackNumber.Should().Be(expectedResult);
        }

        [Fact]
        public void should_return_original_value_using_suffix_incremental()
        {
            int numberToIncrement = 1;
            int suffixIncrementalReturnValue = numberToIncrement++;

            // change "default(int)" to correct value.
            const int expectedResult = default (int);

            suffixIncrementalReturnValue.Should().Be(expectedResult);
        }

        [Fact]
        public void should_return_incremented_value_using_prefix_incremental()
        {
            int numberToIncrement = 1;
            int prefixIncrementalReturnValue = ++numberToIncrement;

            // change "default(int)" to correct value.
            const int expectedResult = default(int);

            prefixIncrementalReturnValue.Should().Be(expectedResult);
        }

        [Fact]
        public void should_throw_exception_if_integer_divided_by_zero()
        {
            int numerator = 1;
            int denominator = 0;

            // change "typeof(ArgumentException)" to correct exception type.
            Type desiredExceptionType = typeof(ArgumentException);

            desiredExceptionType.Should().NotBe(typeof(ArithmeticException));
            desiredExceptionType.Should().NotBe(typeof(SystemException));
            desiredExceptionType.Should().NotBe(typeof(Exception));
            Assert.Throws(desiredExceptionType, () => numerator / denominator);
        }

        [Fact]
        public void should_overflow_sciently_for_integer_operation()
        {
            int minimumValue = int.MinValue;
            --minimumValue;

            // change "default(int)" to correct value.
            const int expectedResult = default(int);

            minimumValue.Should().Be(expectedResult);
        }

        [Fact]
        public void should_throw_on_checked_overflow()
        {
            int minimumValue = int.MinValue;

            // change "typeof(ArgumentException)" to correct exception type.
            Type desiredExceptionType = typeof(ArgumentException);
            
            desiredExceptionType.Should().NotBe(typeof(ArithmeticException));
            desiredExceptionType.Should().NotBe(typeof(SystemException));
            desiredExceptionType.Should().NotBe(typeof(Exception));

            Assert.Throws(desiredExceptionType, () => { checked { --minimumValue; } });
        }

        [Fact]
        public void should_do_complement_operation()
        {
            // change "default(int)" to correct value. You should use Hex representation.
            const int expectedResult = default (int);

            (~0xf).Should().Be(expectedResult);
        }

        [Fact]
        public void should_do_and_operation()
        {
            // change "default(int)" to correct value. You should use Hex representation.
            const int expectedResult = default(int);

            (0xf0 & 0x33).Should().Be(expectedResult);
        }

        [Fact]
        public void should_do_or_operation()
        {
            // change "default(int)" to correct value. You should use Hex representation.
            const int expectedResult = default(int);

            (0xf0 | 0x33).Should().Be(expectedResult);
        }

        [Fact]
        public void should_do_exclusive_or_operation()
        {
            // change "default(int)" to correct value. You should use Hex representation.
            const int expectedResult = default(int);

            (0xff00 ^ 0x0ff0).Should().Be(expectedResult);
        }

        [Fact]
        public void should_do_shift_left_operation()
        {
            // change "default(int)" to correct value. You should use Hex representation.
            const int expectedResult = default(int);

            (0x20 << 2).Should().Be(expectedResult);
        }

        [Fact]
        public void should_do_shift_right_operation()
        {
            // change "default(int)" to correct value. You should use Hex representation.
            const int expectedResult = default(int);

            (0x20 >> 1).Should().Be(expectedResult);
        }

        [Fact]
        public void should_change_type_for_8_and_16_bit_number_arithmetic_operators()
        {
            const short shortNumber = 1;
            const short anotherShortNumber = 1;
            Type arithmeticOperatorResultType = (shortNumber + anotherShortNumber).GetType();

            // change "typeof(short)" to correct type.
            Type expectedResult = typeof(short);

            arithmeticOperatorResultType.Should().Be(expectedResult);
        }

        [Fact]
        public void should_get_infinite_value_when_divide_by_zero_for_floating_point_number()
        {
            const double numerator = 1.0;
            const double denominator = 0.0;

            // change "default(double)" to correct value.
            const double expectedResult = default(double);

            (numerator / denominator).Should().Be(expectedResult);
        }

        [Fact]
        public void should_get_nan_when_doing_certain_operation_for_floating_point_number()
        {
            const double numerator = 0;
            const double denominator = 0;

            const double expectedResult = default(double);

            (numerator / denominator).Should().Be(expectedResult);
        }
    }

#pragma warning restore 219
    // ReSharper restore RedundantAssignment
    // ReSharper restore ConvertToConstant.Local
}