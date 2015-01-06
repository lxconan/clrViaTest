using System;
using System.Collections.Generic;
using BanKai.Advanced.Scene._01_CreatingObject.Common;
using Xunit;

namespace BanKai.Advanced.Scene._01_CreatingObject
{
    // Okay, from this practice. You can add your implementation in
    // this file scope. But you cannot modify testing related source
    // code. Besides, please modify existed source code as few as
    // possible.
    //
    // We have implemented a pretty container with registration and
    // resolving functions. Now we want to control the lifetime 
    // of the created object. A lifetime controller is another object.
    // When the lifetime controller object is disposed, all objects
    // resolved by it will be disposed (if they implement IDisposable).
    // We can discover that the lifetime controller is the proper
    // type to resolve object and the container is just a definition
    // holder, so we just remove the resolve method from the container.
    //
    // Requirement: Implement life time object support.

    public class SupportLifetimeControlForCreatedObjects
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

                return Equals((TypeContext)obj);
            }

            public override int GetHashCode()
            {
                return m_type.GetHashCode();
            }
        }

        private interface ILifetimeObject : IDisposable
        {
            T Resolve<T>(string hint = null);
        }

        private class LifetimeObject : ILifetimeObject
        {
            private readonly IDictionary<TypeContext, Delegate> m_creatingLogicDefinitions;

            public LifetimeObject(IDictionary<TypeContext, Delegate> creatingLogicDefinitions)
            {
                m_creatingLogicDefinitions = creatingLogicDefinitions;
            }

            public T Resolve<T>(string hint)
            {
                throw new NotImplementedException(
                    "Delete this line and add your implmenetation");
            }

            public void Dispose()
            {
                throw new NotImplementedException(
                    "Delete this line and add your implmenetation");
            }
        }

        private class Container
        {
            private readonly Dictionary<TypeContext, Delegate> m_creatingLogics
                = new Dictionary<TypeContext, Delegate>();

            public void Register<T>(Func<ILifetimeObject, T> howToCreateMe, string hint = null)
            {
                m_creatingLogics.Add(new TypeContext(typeof (T), hint), howToCreateMe);
            }

            public ILifetimeObject CreateLifetimeObject()
            {
                return new LifetimeObject(m_creatingLogics);
            }
        }

        private class TestingObject : IDisposable
        {
            public bool IsDisposed { get; private set; }

            public void Dispose()
            {
                IsDisposed = true;
            }
        }

        [Fact]
        public void Run()
        {
            CheckLifetimeObject();
            RegressionCheckInjection();
        }

        private void RegressionCheckInjection()
        {
            var containerBuilder = new Container();
            containerBuilder.Register(
                c => new Duck("Red Head Duck", c.Resolve<Fly>(), c.Resolve<Squeak>()),
                "Red Head Duck");
            containerBuilder.Register(c => new Fly());
            containerBuilder.Register(c => new Squeak());
            containerBuilder.Register(c => new TestingObject());

            ILifetimeObject container = containerBuilder.CreateLifetimeObject();
            var duck = container.Resolve<Duck>("Red Head Duck");

            const string expectedMessage =
                "Red Head Duck can fly. And when it quacks, it says Squeak. ";
            Assert.Equal(expectedMessage, duck.ToString());
        }

        private static void CheckLifetimeObject()
        {
            var container = new Container();
            container.Register(c => new TestingObject());

            ILifetimeObject lifetimeObject = container.CreateLifetimeObject();
            var disposable = lifetimeObject.Resolve<TestingObject>();

            lifetimeObject.Dispose();

            Assert.True(disposable.IsDisposed);
        }
    }
}