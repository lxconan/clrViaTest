using Xunit;

namespace BanKai.TypeAndMember
{
    public class ReferenceTypeConstructorFact
    {
        private class CtorSample
        {
            public int Value { get; private set; }

            private CtorSample()
            {
                Value = 2;
            }

            public CtorSample(int value) : this()
            {
                Value *= value;
            }

            public CtorSample(int value1, int value2)
            {
                Value *= (value1 + value2);
            }
        }

        [Fact]
        public void calling_this_means_to_call_certain_ctor_of_current_type()
        {
            var ctorSample = new CtorSample(3);
            Assert.Equal(0, ctorSample.Value);
        }

        [Fact]
        public void calling_parameterless_ctor_of_current_type_is_not_a_default_behavior()
        {
            var ctorSample = new CtorSample(3, 4);
            Assert.Equal(14, ctorSample.Value);
        }

        private class CtorSkipSample
        {
            public static int StaticValue { get; private set; }
            public int InstanceValue { get; private set; }

            static CtorSkipSample()
            {
                StaticValue = 1;
            }

            public CtorSkipSample()
            {
                ++StaticValue;
                InstanceValue = 5;
            }

            public CtorSkipSample MemberWiseCloneTest()
            {
                return (CtorSkipSample)MemberwiseClone();
            }
        }

        [Fact]
        public void using_member_wise_clone_will_not_call_ctor()
        {
            var ctorSkipSample = new CtorSkipSample();
            Assert.Equal(0, CtorSkipSample.StaticValue);
            Assert.Equal(0, ctorSkipSample.InstanceValue);

            var anotherCtorSkipSample = ctorSkipSample.MemberWiseCloneTest();
            Assert.Equal(0, CtorSkipSample.StaticValue);
            Assert.Equal(0, anotherCtorSkipSample.InstanceValue);
        }
    }
}