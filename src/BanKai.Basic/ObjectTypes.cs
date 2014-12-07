using System;
using System.Collections.Generic;
using BanKai.Basic.Common;
using FluentAssertions;
using Xunit;

namespace BanKai.Basic
{
    // ReSharper disable ConvertToConstant.Local
    // ReSharper disable PossibleInvalidCastException
    public class ObjectTypes
    {
        [Fact]
        public void all_types_are_derived_from_object()
        {
            var stringInstance = "a string";
            var annonymousInstance = new { };
            var valueTypeInstance = 2;

            // change the variable values for the following 3 lines to fix the test.
            const bool isStringInstanceObject = false;
            const bool isAnnonymousInstanceObject = false;
            const bool isValueTypeInstanceObject = false;

            stringInstance.GetType().IsSubclassOf(typeof(object)).Should().Be(isStringInstanceObject);
            annonymousInstance.GetType().IsSubclassOf(typeof(object)).Should().Be(isAnnonymousInstanceObject);
            valueTypeInstance.GetType().IsSubclassOf(typeof(object)).Should().Be(isValueTypeInstanceObject);
        }

        [Fact]
        public void should_cast_to_object_for_any_instance()
        {
            var objectList = new List<object> {"String", 2, new RefTypeClass(2)};

            object itemAtPosition0 = objectList[0];
            object itemAtPosition1 = objectList[1];
            object itemAtPosition2 = objectList[2];

            // change the variable values for the following 3 lines to fix the test.
            Type expectedTypeForItemAtPosition0 = typeof(object);
            Type expectedTypeForItemAtPosition1 = typeof(object);
            Type expectedTypeForItemAtPosition2 = typeof(object);

            itemAtPosition0.GetType().Should().Be(expectedTypeForItemAtPosition0);
            itemAtPosition1.GetType().Should().Be(expectedTypeForItemAtPosition1);
            itemAtPosition2.GetType().Should().Be(expectedTypeForItemAtPosition2);
        }

        [Fact]
        public void should_derived_from_value_type_for_value_type()
        {
            int intObject = 1;
            DateTime dateTimeObject = DateTime.Now;
            var customValueTypeObject = new ValueTypeDemoClass();

            // change the variable values for the following 3 lines to fix the test.
            const bool isIntObjectValueType = false;
            const bool isDateTimeObjectValueType = false;
            const bool isCustomValueTypeObjectValueType = false;

            intObject.GetType()
                .IsSubclassOf(typeof(ValueType)).Should().Be(isIntObjectValueType);
            dateTimeObject.GetType()
                .IsSubclassOf(typeof(ValueType)).Should().Be(isDateTimeObjectValueType);
            customValueTypeObject.GetType()
                .IsSubclassOf(typeof(ValueType)).Should().Be(isCustomValueTypeObjectValueType);
        }

        [Fact]
        public void should_be_sealed_for_value_type()
        {
            var customValueTypeObject = new ValueTypeDemoClass();

            // change the variable value to fix the test.
            const bool isValueTypeSealed = false;

            customValueTypeObject.GetType().IsSealed.Should().Be(isValueTypeSealed);
        }

        [Fact]
        public void should_perform_real_copy_operation_for_value_type()
        {
            var original = new ValueTypeDemoClass();

            ValueTypeDemoClass copy = original;
            bool isSameReference;

            unsafe
            {
                ValueTypeDemoClass* originalPtr = &original;
                ValueTypeDemoClass* copyPtr = &copy;

                isSameReference = originalPtr == copyPtr;
            }

            // change the variable value to fix the test.
            const bool expectedIsSameReference = true;

            isSameReference.Should().Be(expectedIsSameReference);
        }

        [Fact]
        public void should_as_if_nothing_different_occurrs_when_doing_boxing_operation()
        {
            int intObject = 1;
            var boxed = (object) intObject;

            // change the variable values for the following 3 lines to fix the test.
            Type expectedType = typeof(object);
            const bool isBoxedTypeSealed = false;
            const bool isValueType = false;

            boxed.GetType().Should().Be(expectedType);
            boxed.GetType().IsSealed.Should().Be(isBoxedTypeSealed);
            boxed.GetType().IsValueType.Should().Be(isValueType);
        }

        [Fact]
        public void should_make_explicity_cast_when_doing_unboxing_operation()
        {
            int intObject = 1;
            var boxed = (object) intObject;
            long longObject = 0;
            Exception errorWhenCasting = null;

            try
            {
                longObject = (long) boxed;
            }
            catch (Exception error)
            {
                errorWhenCasting = error;
            }

            // change the variable values for the following 3 lines to fix the test.
            const bool isExceptionOccurred = true;
            Type expectedExceptionType = typeof(Exception);
            const long expectedLongObjectValue = 1L;

            (errorWhenCasting == null).Should().Be(isExceptionOccurred);
            errorWhenCasting.GetType().Should().Be(expectedExceptionType);
            longObject.Should().Be(expectedLongObjectValue);
        }

        [Fact]
        public void should_get_most_derived_type_when_call_get_type_method()
        {
            var derivedClassObject = new InheritMemberAccessDemoClass();
            var castedToBaseClass = (InheritMemberAccessDemoBaseClass)derivedClassObject;

            Type type = castedToBaseClass.GetType();

            // change the variable value to fix the test.
            Type expectedType = typeof(InheritMemberAccessDemoBaseClass);

            type.Should().Be(expectedType);
        }

        [Fact]
        public void should_print_object_type_if_no_override_is_available_for_to_string_method()
        {
            var objectWithoutToStringOverride = new RefTypeClass(2);

            // change the variable value to fix the test.
            const string expectedToStringResult = "";

            string toStringResult = objectWithoutToStringOverride.ToString();
            toStringResult.Should().Be(expectedToStringResult);
        }
    }

    // ReSharper restore PossibleInvalidCastException
    // ReSharper restore ConvertToConstant.Local
}