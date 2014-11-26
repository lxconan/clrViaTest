using System;
using FluentAssertions;
using Xunit;

namespace BanKai.Basic
{
    public class NumberOperations
    {
        [Fact]
        public void change_specified_line_to_get_the_min_value_of_sbyte()
        {
            // change the line below
            sbyte minimum = default(sbyte);

            minimum.Should().Be(-128);
        }

        [Fact]
        public void change_specified_line_to_get_the_max_value_of_int()
        {
            // change the line below
            int maximum = default(int);

            maximum.Should().Be(2147483647);
        }

        [Fact]
        public void change_specified_line_to_correct_the_type_of_double_literal()
        {
            // change the line below
            Type guessTheType = typeof (string);

            1.0.GetType().Should().Be(guessTheType);
            1E3.GetType().Should().Be(guessTheType);
        }

        [Fact]
        public void change_specified_line_to_correct_the_type_of_int_literal()
        {
            // change the line below
            Type guessTheType = typeof (string);

            1.GetType().Should().Be(guessTheType);
            0x123.GetType().Should().Be(guessTheType);
        }

        [Fact]
        public void change_specified_line_to_correct_the_type_of_decimal_literal()
        {
            // change the line below
            Type guessTheType = typeof (string);

            1M.GetType().Should().Be(guessTheType);
        }

        [Fact]
        public void change_specified_line_to_correct_the_type_of_long_literal()
        {
            // change the line below
            Type guessTheType = typeof (string);

            5L.GetType().Should().Be(guessTheType);
        }

        [Fact]
        public void change_specified_line_to_correct_the_type_of_float_literal()
        {
            // change the line below
            Type guessTheType = typeof (string);

            5F.GetType().Should().Be(guessTheType);
        }
    }
}