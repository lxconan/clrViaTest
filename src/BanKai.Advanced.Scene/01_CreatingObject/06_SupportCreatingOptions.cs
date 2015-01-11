using System;
using System.Collections.Generic;
using BanKai.Advanced.Scene._01_CreatingObject.Common;
using Xunit;

namespace BanKai.Advanced.Scene._01_CreatingObject
{
    // You can see how code begins from a simple new operator to this
    // sort of mess. In this practice. You can still add your 
    // implementation in file scope. But you cannot modify testing 
    // related source code. Besides, please modify existed source code 
    // as few as possible.
    //
    // Now the universal factory becomes more and more functional.
    // In this practice, we would like to add more control on object
    // creating. We want to resolve the same object if we define 
    // the object instantiating type as singleton. 
    // 
    // You may have notice that the name of the universal factory class 
    // has been changed. That's because since the factory is only used for 
    // defining creating logic, we rename it from UniversalFactory to 
    // ContainerBuilder.
    //
    // Requirement: Implement pre-call creation and singleton creation,
    // and pass the test.

    public class SupportCreatingOptions
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
            private readonly IDictionary<TypeContext, CreatingOptions> m_creatingLogicDefinitions;
            private readonly List<IDisposable> m_disposingTable = new List<IDisposable>();

            public LifetimeObject(IDictionary<TypeContext, CreatingOptions> creatingLogicDefinitions)
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
                foreach (var disposable in m_disposingTable)
                {
                    disposable.Dispose();
                }

                m_disposingTable.Clear();
            }
        }

        private enum InstantiateMethod
        {
            PreCall = 0,
            Singleton = 1
        }

        private class CreatingOptions
        {
            public CreatingOptions(Delegate howToCreate, InstantiateMethod instantiateMethod)
            {
                m_howToCreate = howToCreate;
                InstantiateMethod = instantiateMethod;
            }

            public InstantiateMethod InstantiateMethod { get; private set; }
            private readonly Delegate m_howToCreate;

            public T Create<T>(ILifetimeObject lifetimeObject)
            {
                var creatingDelegate = (Func<ILifetimeObject, T>) m_howToCreate;
                return creatingDelegate(lifetimeObject);
            }

            public void AsSingleton()
            {
                InstantiateMethod = InstantiateMethod.Singleton;
            }
        }

        private class ContainerBuilder
        {
            private readonly Dictionary<TypeContext, CreatingOptions> m_creatingLogics
                = new Dictionary<TypeContext, CreatingOptions>();

            public CreatingOptions Register<T>(Func<ILifetimeObject, T> howToCreateMe, string hint = null)
            {
                var creatingOptions = new CreatingOptions(howToCreateMe, InstantiateMethod.PreCall);
                m_creatingLogics.Add(
                    new TypeContext(typeof (T), hint),
                    creatingOptions);

                return creatingOptions;
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
            CheckSingletonCreating();
            CheckPrecallCreating();
            RegressionCheckInjection();
            RegressionCheckLifetimeControl();
        }

        private static void RegressionCheckLifetimeControl()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Register(c => new TestingObject());

            ILifetimeObject container = containerBuilder.CreateLifetimeObject();

            var testingObject = container.Resolve<TestingObject>();
            container.Dispose();

            Assert.True(testingObject.IsDisposed);
        }

        private static void RegressionCheckInjection()
        {
            var containerBuilder = new ContainerBuilder();
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

        private void CheckPrecallCreating()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Register(c => new Fly());

            ILifetimeObject lifetimeObject = containerBuilder.CreateLifetimeObject();

            var flyObject = lifetimeObject.Resolve<Fly>();
            var differentObject = lifetimeObject.Resolve<Fly>();

            Assert.NotSame(flyObject, differentObject);
        }

        private void CheckSingletonCreating()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Register(c => new TestingObject()).AsSingleton();

            ILifetimeObject lifetimeObject = containerBuilder.CreateLifetimeObject();

            var testingObject = lifetimeObject.Resolve<TestingObject>();
            var theSameObject = lifetimeObject.Resolve<TestingObject>();

            Assert.Same(testingObject, theSameObject);
        }
    }
}