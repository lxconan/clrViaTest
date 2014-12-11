using System;
using BanKai.Basic.Common;
using FluentAssertions;
using Xunit;

namespace BanKai.Basic
{
    // ReSharper disable EqualExpressionComparison

    public class Enums
    {
        [Fact]
        public void should_be_able_to_compare_enums()
        {
            const bool bottomEqualsLeft = BorderSide.Bottom == BorderSide.Left;
            const bool rightEqualsRight = BorderSide.Right == BorderSide.Right;

            // change the variable value for following 2 lines to fix the test.
            const bool expectedResultForBottomEqualsLeft = true;
            const bool expectedResultForRightEqualsRight = false;

            bottomEqualsLeft.Should().Be(expectedResultForBottomEqualsLeft);
            rightEqualsRight.Should().Be(expectedResultForRightEqualsRight);
        }

        [Fact]
        public void should_increase_the_integer_automatically()
        {
            // change the variable value for following 4 lines to fix the test.
            const int leftValue = int.MinValue;
            const int rightValue = int.MinValue;
            const int topValue = int.MinValue;
            const int bottomValue = int.MinValue;

            ((BorderSide) leftValue == BorderSide.Left).Should().BeTrue();
            ((BorderSide) rightValue == BorderSide.Right).Should().BeTrue();
            ((BorderSide) topValue == BorderSide.Top).Should().BeTrue();
            ((BorderSide) bottomValue == BorderSide.Bottom).Should().BeTrue();
        }

        [Fact]
        public void should_specify_explicity_integer_value_for_each_member()
        {
            // change the variable value for following 4 lines to fix the test.
            const int leftValue = int.MinValue;
            const int rightValue = int.MinValue;
            const int topValue = int.MinValue;
            const int bottomValue = int.MinValue;

            ((BorderSideExplicity)leftValue == BorderSideExplicity.Left).Should().BeTrue();
            ((BorderSideExplicity)rightValue == BorderSideExplicity.Right).Should().BeTrue();
            ((BorderSideExplicity)topValue == BorderSideExplicity.Top).Should().BeTrue();
            ((BorderSideExplicity)bottomValue == BorderSideExplicity.Bottom).Should().BeTrue();
        }

        [Fact]
        public void should_only_compare_values()
        {
            const bool differentDeclareWithSameValueCompareResult = 
                BorderSideExplicity.Left == BorderSideExplicity.LeftEquivalent;

            // change the variable value to fix the test.
            const bool expectedCompareResult = false;

            differentDeclareWithSameValueCompareResult.Should().Be(expectedCompareResult);
        }

        [Fact]
        public void should_increase_the_integer_according_to_layout()
        {
            // change the variable value for following 4 lines to fix the test.
            const int leftValue = int.MinValue;
            const int rightValue = int.MinValue;
            const int topValue = int.MinValue;
            const int bottomValue = int.MinValue;

            ((BorderSideLayout)leftValue == BorderSideLayout.Left).Should().BeTrue();
            ((BorderSideLayout)rightValue == BorderSideLayout.Right).Should().BeTrue();
            ((BorderSideLayout)topValue == BorderSideLayout.Top).Should().BeTrue();
            ((BorderSideLayout)bottomValue == BorderSideLayout.Bottom).Should().BeTrue();
        }

        [Fact]
        public void should_be_able_to_parse_enum_by_name()
        {
            var parsedBottomEnumValue = (BorderSide)Enum.Parse(typeof(BorderSide), "Bottom");

            // change the variable value to fix the test.
            const BorderSide expectedEnumValue = BorderSide.Left;

            parsedBottomEnumValue.Should().Be(expectedEnumValue);
        }

        [Fact]
        public void should_be_able_to_parse_enum_by_value()
        {
            var parsedBottomEnumValue = (BorderSide)Enum.Parse(typeof(BorderSide), "3");

            // change the variable value to fix the test.
            const BorderSide expectedEnumValue = BorderSide.Left;

            parsedBottomEnumValue.Should().Be(expectedEnumValue);            
        }

        [Fact]
        public void should_declare_flag_when_enum_values_can_be_combined()
        {
            const BorderSideFlag leftAndRight = BorderSideFlag.LeftAndRight;

            const bool includeLeft = (leftAndRight & BorderSideFlag.Left) != 0;
            
            // change the variable value to fix the test.
            const bool expectedIncludeLeft = false;

            includeLeft.Should().Be(expectedIncludeLeft);
        }
    }

    // ReSharper restore EqualExpressionComparison
}