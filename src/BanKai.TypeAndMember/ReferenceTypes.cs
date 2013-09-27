using System;
using Xunit;

namespace BanKai.TypeAndMember
{
    public class ReferenceTypes
    {
        private struct PleaseCorrectIt1
        {
        }

        private class PleaseCorrectIt2
        {
        }

        [Fact]
        public void reference_types_are_declared_with_class()
        {
            var type = typeof(PleaseCorrectIt1);
            Assert.True(IsReferenceType(type));
        }

        [Fact]
        public void value_types_are_declared_with_struct()
        {
            var type = typeof(PleaseCorrectIt2);
            Assert.True(type.IsValueType);
        }

        private enum MyEnum
        {
        }

        [Fact]
        public void enum_are_also_value_types()
        {
            Assert.False(typeof(MyEnum).IsValueType);
        }

        private class MyReferenceType
        {
        }

        [Fact]
        public void the_reference_type_instance_you_hold_is_just_a_reference()
        {
            var reference = new MyReferenceType();
            var anotherStorage = reference;

            Assert.False(ReferenceEquals(reference, anotherStorage));
        }

        private struct MyValueType
        {
            public int InternalValue { get; set; }
        }

        [Fact]
        public void the_value_type_instance_you_hold_is_the_whole_allocation_and_will_be_deeply_copied()
        {
            // ReSharper disable UseObjectOrCollectionInitializer
            var valueType = new MyValueType();
            // ReSharper restore UseObjectOrCollectionInitializer
            valueType.InternalValue = 1;
            var anotherStorage = valueType;
            anotherStorage.InternalValue = 2;

            Assert.Equal(2, valueType.InternalValue);
            Assert.Equal(1, anotherStorage.InternalValue);
        }

        private static bool IsReferenceType(Type type)
        {
            return !type.IsValueType;
        }
    }
}
