using System;
using BanKai.Advanced.Scene._01_CreatingObject.Common;
using Xunit;

namespace BanKai.Advanced.Scene._01_CreatingObject
{
    public class CreatingObjectUsingFactory
    {
        private class DuckFactory
        {
            public Duck Create(string duckType)
            {
                // However, things are most likely to be changed in the future.
                // So using new operator is not easy to maintain. (e.g. If the 
                // creating operation changed, we have to update all the 
                // new operations.) Instead, we can use factory method to 
                // create an object.
                //
                // Requirement: implement Create(string) method and returns
                // correct instance according to duckType passed. You can only
                // write your implementation in DuckFactory.Create(string)
                // method. No 3rd party library is allowed to import here.

                throw new NotImplementedException(
                    "Please delete this statement and add your implementation here.");
            }
        }

        private readonly DuckFactory m_duckFactory = new DuckFactory();

        [Fact]
        public void Run()
        {
            CheckRedHeadDuck();
            CheckModelDuck();
        }

        private void CheckRedHeadDuck()
        {
            Duck redHeadDuck = m_duckFactory.Create("Red Head Duck");

            const string expectedMessage =
                "Red Head Duck can fly. And when it quacks, it says Squeak. ";
            Assert.Equal(expectedMessage, redHeadDuck.ToString());
        }

        private void CheckModelDuck()
        {
            Duck modelDuck = m_duckFactory.Create("Model Duck");

            const string expectedMessage =
                "Model Duck cannot fly. And when it quacks, it says Quack. ";
            Assert.Equal(expectedMessage, modelDuck.ToString());
        }
    }
}