using System;
using System.Diagnostics;
using System.Reflection;
using FluentAssertions;
using Xunit;

namespace BanKai.TypeAndMember
{
    public class TypeConstructorFact
    {
        // ReSharper disable ClassNeverInstantiated.Local
        private sealed class TypeCtorSample1
        // ReSharper restore ClassNeverInstantiated.Local
        {
            public static readonly int Number;

            static TypeCtorSample1()
            {
                Number = 5;
            }
        } 

        [Fact]
        public void type_ctor_will_be_called_when_type_is_referenced()
        {
            TypeCtorSample1.Number.Should().Be(default(int));
        }
    
        // ReSharper disable UnusedMember.Local
        private sealed class TypeCtorSample2
        // ReSharper restore UnusedMember.Local
        {
            // ReSharper disable MemberCanBePrivate.Local
            // ReSharper disable NotAccessedField.Local
            public static readonly int Number;
            // ReSharper restore NotAccessedField.Local
            // ReSharper restore MemberCanBePrivate.Local

            static TypeCtorSample2()
            {
                Number = 6;
            }
        }

        [Fact]
        public void type_ctor_will_be_called_when_type_is_referenced_by_reflection()
        {
            Type type = Type.GetType("BanKai.TypeAndMember.TypeConstructorFact+TypeCtorSample2");
            Debug.Assert(type != null);
            FieldInfo numberField = type.GetField(
                "Number", BindingFlags.Public | BindingFlags.Static | BindingFlags.GetField);

            Debug.Assert(numberField != null);
            var value = (int) numberField.GetValue(null);
            value.Should().Be(default(int));
        }
    }
}