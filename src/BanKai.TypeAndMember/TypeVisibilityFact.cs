using System;
using System.Reflection;
using Xunit;

namespace BanKai.TypeAndMember
{
    public class MemberAccessibilibtyFact
    {
        private class Sample
        {
            // ReSharper disable once UnusedField.Compiler
            int field;
        }

        private interface ISample
        {
            int Property { get; }
        }

        [Fact]
        public void the_default_visibility_to_member_is_usually_private()
        {
            Type type = typeof (Sample);
            FieldInfo fieldMember = type.GetField(
                "field", BindingFlags.Instance | BindingFlags.GetField | BindingFlags.NonPublic);

            Assert.NotNull(fieldMember);
            // ReSharper disable once PossibleNullReferenceException
            Assert.True(fieldMember.IsPublic);
        }

        [Fact]
        public void the_default_visibiliby_to_member_of_interface_is_public()
        {
            Type type = typeof(ISample);
            PropertyInfo propertyInfo = type.GetProperty("Property", BindingFlags.NonPublic);

            Assert.NotNull(propertyInfo);
        }
    }
}
