using System;
using System.Collections.Generic;
using BanKai.Advanced.Scene._01_CreatingObject.Common;
using Xunit;

namespace BanKai.Advanced.Scene._01_CreatingObject
{
    public class IsolateDefinitionAndCreatingLogic
    {
        private class TypeContext : IEquatable<TypeContext>
        {
            private readonly Type m_type;
            private readonly string m_hint;

            public TypeContext(Type type, string hint = null)
            {
                m_type = type;
                m_hint = hint;
            }

            public bool Equals(TypeContext other)
            {
                return m_type == other.m_type &&
                    m_hint == other.m_hint;
            }

            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                {
                    return false;
                }

                return Equals((TypeContext) obj);
            }

            public override int GetHashCode()
            {
                return m_type.GetHashCode();
            }
        }

        private class Container
        {
            private readonly Dictionary<TypeContext, Delegate> m_creatingLogics
                = new Dictionary<TypeContext, Delegate>();

            public void Register<T>(Func<Container, T> howToCreateMe, string hint = null)
            {
                // Writing all the creating logic in Resolve<T>(string) is not 
                // a good idea. Because we have to update the method everytime
                // a new type is introduced. To solve this problem, we create a
                // new method named Register() to isolate creating logic definition
                // and creating operation.
                //
                // Requirement: please read existed code carefully and complete
                // Register<T>() method. You can only write your implementation in
                // Register<T>() method and cannot modify any existed source
                // code. No 3rd party library is allowed to import here.
                
                throw new NotImplementedException("Delete this line and add your implmenetation");
            }

            public T Resolve<T>(string hint = null)
            {
                Func<Container, T> creatingLogic;
                    
                try
                {
                    creatingLogic =
                        (Func<Container, T>) m_creatingLogics[new TypeContext(typeof (T), hint)];
                }
                catch (KeyNotFoundException error)
                {
                    string message = string.Format(
                        "Cannot resolve type {0}. Are you missing a registration logic?",
                        typeof (T).FullName);

                    throw new KeyNotFoundException(message, error);
                }

                return creatingLogic(this);
            }
        }

        private readonly Container m_container = new Container();

        [Fact]
        public void Run()
        {
            m_container.Register(c => new Fly());
            m_container.Register(c => new NoFly());
            m_container.Register(c => new Quack());
            m_container.Register(c => new Squeak());
            m_container.Register(
                c => new Duck("Red Head Duck", c.Resolve<Fly>(), c.Resolve<Squeak>()),
                "Red Head Duck");
            m_container.Register(
                c => new Duck("Model Duck", c.Resolve<NoFly>(), c.Resolve<Quack>()),
                "Model Duck");

            CheckRedHeadDuck();
            CheckModelDuck();
        }

        private void CheckRedHeadDuck()
        {
            var redHeadDuck = m_container.Resolve<Duck>("Red Head Duck");

            const string expectedMessage =
                "Red Head Duck can fly. And when it quacks, it says Squeak. ";
            Assert.Equal(expectedMessage, redHeadDuck.ToString());
        }

        private void CheckModelDuck()
        {
            var modelDuck = m_container.Resolve<Duck>("Model Duck");

            const string expectedMessage =
                "Model Duck cannot fly. And when it quacks, it says Quack. ";
            Assert.Equal(expectedMessage, modelDuck.ToString());
        }
    }
}