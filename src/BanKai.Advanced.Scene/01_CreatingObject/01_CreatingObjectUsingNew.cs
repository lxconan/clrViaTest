using System;
using BanKai.Advanced.Scene._01_CreatingObject.Common;
using Xunit;

namespace BanKai.Advanced.Scene._01_CreatingObject
{
    public class CreatingObjectUsingNew
    {
        internal Duck CreateRedHeadDuck()
        {
            // There is only one way to create object in C# -- the new operator.
            // In this practice, I would like to create a "Red Head Duck"
            // instance.
            //
            // Requirement: Please create a "Red Head Duck" instance using new
            // operator. You can only write your implementation in 
            // CreateRedHeadDuck() method.
            //
            // You cannot add any 3rd party library into the project.
            // 
            // Hint: The duck is composited with different behaviors. And the 
            // desired behavior is defined in Run() method. 

            throw new NotImplementedException();
        }

        [Fact]
        public void Run()
        {
            Duck readHeadDuck = CreateRedHeadDuck();

            const string expectedMessage =
                "Red Head Duck can fly. And when it quacks, it says Squeak. ";
            Assert.Equal(expectedMessage, readHeadDuck.ToString());
        }
    }
}