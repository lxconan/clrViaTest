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
                // So using new operator is not easy to maintain. Instead, we
                // can use factory method to create object.
                //
                // Requirement: implement Create(string) method and returns
                // correct instance according to duckType passed. You can only
                // write your implementation in DuckFactory.Create(string)
                // method. No 3rd party library is allowed to import here.

                throw new NotImplementedException();
            }
        }

        private readonly DuckFactory m_duckFactory = new DuckFactory();

        internal Duck CreateRedHeadDuck()
        {
            return m_duckFactory.Create("Red Head Duck");
        }

        internal Duck CreateModelDuck()
        {
            return m_duckFactory.Create("Model Duck");
        }

        [Fact]
        public void Run()
        {
            CheckRedHeadDuck();
            CheckModelDuck();
        }

        private void CheckRedHeadDuck()
        {
            Duck readHeadDuck = CreateRedHeadDuck();

            const string expectedMessage =
                "Red Head Duck can fly. And when it quacks, it says Squeak. ";
            Assert.Equal(expectedMessage, readHeadDuck.ToString());
        }

        private void CheckModelDuck()
        {
            Duck readHeadDuck = CreateModelDuck();

            const string expectedMessage =
                "Model Duck cannot fly. And when it quacks, it says Quack. ";
            Assert.Equal(expectedMessage, readHeadDuck.ToString());
        }
    }
}