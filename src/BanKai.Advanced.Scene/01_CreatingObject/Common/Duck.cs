using System.Text;

namespace BanKai.Advanced.Scene._01_CreatingObject.Common
{
    internal class Duck
    {
        private readonly string m_name;
        private readonly IFlyBehavior m_flyBehavior;
        private readonly IQuackBehavior m_quackBehavior;

        public Duck(string name, IFlyBehavior flyBehavior, IQuackBehavior quackBehavior)
        {
            m_name = name;
            m_flyBehavior = flyBehavior;
            m_quackBehavior = quackBehavior;
        }

        public override string ToString()
        {
            return new StringBuilder()
                .Append(m_name)
                .Append(' ')
                .Append(m_flyBehavior.CanFly ? "can fly. " : "cannot fly. ")
                .Append("And when it quacks, it says ")
                .Append(m_quackBehavior.QuackContent)
                .Append(". ")
                .ToString();
        }
    }
}