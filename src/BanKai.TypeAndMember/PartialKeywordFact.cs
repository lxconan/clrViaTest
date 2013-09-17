using System;
using Xunit;
using Xunit.Extensions;

namespace BanKai.TypeAndMember
{
    internal partial class PartialClassSample
    {
        public void Hello() { }
    }

    partial class PartialClassSample
    {
        public void Greeting() { }
    }

    internal partial interface IPartialInterfaceSample
    {
        void Hello();
    }

    partial interface IPartialInterfaceSample
    {
        void Greeting();
    }

    internal partial struct PartialStructSample
    {
        public void Hello() { }
    }

    partial struct PartialStructSample
    {
        public void Greeting() { }
    }

    public class PartialKeywordFact
    {
        [Theory]
        [InlineData(typeof(PartialClassSample))]
        [InlineData(typeof(IPartialInterfaceSample))]
        [InlineData(typeof(PartialStructSample))]
        public void the_partial_key_word_combines_definitions_for_same_type(Type type)
        {
            Assert.Null(type.GetMethod("Hello"));
            Assert.Null(type.GetMethod("Greeting"));
        }
    }
}