using System;
using BanKai.Advanced.Scene._01_CreatingObject.Common;
using Xunit;

namespace BanKai.Advanced.Scene._01_CreatingObject
{
    public class ChangeTheSignatureOfTheFactory
    {
        private class UniversalFactory
        {
            public T Resolve<T>(string hint = null)
            {
                if (typeof (T).Name == "Duck")
                {
                    if (hint == "Red Head Duck")
                    {
                        return (T)(object)new Duck(hint, Resolve<Fly>(), Resolve<Squeak>());
                    }

                    if (hint == "Model Duck")
                    {
                        return (T) (object) new Duck(hint, Resolve<NoFly>(), Resolve<Quack>());
                    }

                    throw new NotSupportedException("Cannot find any matched type.");
                }
                
                // Although using a factory is convenient. You are still using
                // new to create IFlyBehavior and IQuackBehavior implementations.
                // We would like to use the same way to creating those objects.
                // We do not want to create hundreds of thousands of Factories
                // because there are so many types to create. So we would like
                // to create a universal Factroy.
                //
                // Requirement: complete Resolve<T>(string) method and returns
                // correct instance. You can only write your implementation in
                // Resolve<T>(string) method and cannot modify any existed source
                // code. No 3rd party library is allowed to import here.

                throw new NotImplementedException(
                    "Please delete this statement and add your implementation here.");
            }
        }

        private readonly UniversalFactory m_universalFactory = new UniversalFactory();

        [Fact]
        public void Run()
        {
            CheckRedHeadDuck();
            CheckModelDuck();
        }

        private void CheckRedHeadDuck()
        {
            var redHeadDuck = m_universalFactory.Resolve<Duck>("Red Head Duck");

            const string expectedMessage =
                "Red Head Duck can fly. And when it quacks, it says Squeak. ";
            Assert.Equal(expectedMessage, redHeadDuck.ToString());
        }

        private void CheckModelDuck()
        {
            var modelDuck = m_universalFactory.Resolve<Duck>("Model Duck");

            const string expectedMessage =
                "Model Duck cannot fly. And when it quacks, it says Quack. ";
            Assert.Equal(expectedMessage, modelDuck.ToString());
        }
    }
}