using System.Linq;
using System.Reflection;
using FluentAssertions;
using Xunit;

namespace BanKai.TypeAndMember
{
    public class OperatorOverloadMethodFact
    {
        public sealed class OpSample1
        {
            public int Value;

            public OpSample1(int value)
            {
                Value = value;
            }

            public static OpSample1 operator +(OpSample1 a, OpSample1 b)
            {
                return new OpSample1(a.Value + b.Value);
            }
        }

        [Fact]
        public void op_overload_method_is_just_a_method_with_predefined_name()
        {
            var type = typeof (OpSample1);
            MethodInfo memberInfos = type.GetMethod(
                "op_Addition", BindingFlags.Static | BindingFlags.InvokeMethod | BindingFlags.Public);
            var result = (OpSample1)memberInfos.Invoke(null, new object[] {new OpSample1(1), new OpSample1(5)});
            result.Value.Should().Be(default(int));
        } 
    }
}