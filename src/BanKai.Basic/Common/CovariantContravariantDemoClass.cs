namespace BanKai.Basic.Common
{
    internal interface ICovariantGetDemo<out T>
    {
        T Get();
    }

    internal interface IContravariantSetDemo<in T>
    {
        void Put(T value);
    }

    internal class CovariantContravariantDemoClass<T> : 
        ICovariantGetDemo<T>, IContravariantSetDemo<T>
    {
        private T m_value;

        public CovariantContravariantDemoClass(T value)
        {
            m_value = value;
        }

        public T Get()
        {
            return m_value;
        }

        public void Put(T value)
        {
            m_value = value;
        }
    }
}