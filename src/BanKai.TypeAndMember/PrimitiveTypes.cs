using System;
using Xunit;

namespace BanKai.TypeAndMember
{
    public class PrimitiveTypes
    {
        [Fact]
        public void primitive_types_is_actually_a_collection_of_alias()
        {
            Assert.NotEqual(typeof(sbyte), typeof(SByte));
            Assert.NotEqual(typeof(byte), typeof(Byte));
            Assert.NotEqual(typeof(short), typeof(Int16));
            Assert.NotEqual(typeof(ushort), typeof(UInt16));
            Assert.NotEqual(typeof(int), typeof(Int32));
            Assert.NotEqual(typeof(uint), typeof(UInt32));
            Assert.NotEqual(typeof(long), typeof(Int64));
            Assert.NotEqual(typeof(ulong), typeof(UInt64));
            Assert.NotEqual(typeof(char), typeof(Char));
            Assert.NotEqual(typeof(float), typeof(Single));
            Assert.NotEqual(typeof(bool), typeof(Boolean));
            Assert.NotEqual(typeof(decimal), typeof(Decimal));
            Assert.NotEqual(typeof(string), typeof(String));
            Assert.NotEqual(typeof(object), typeof(Object));
        }
    }
}