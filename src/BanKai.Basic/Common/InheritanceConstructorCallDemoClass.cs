using System.Text;

namespace BanKai.Basic.Common
{
    internal abstract class InheritanceConstructorCallDemoClassBase
    {
        protected readonly StringBuilder m_messageBuffer = new StringBuilder();

        public string ConstructorCallMessage
        {
            get { return m_messageBuffer.ToString(); }
        }

        protected InheritanceConstructorCallDemoClassBase()
        {
            m_messageBuffer.AppendLine("InheritanceConstructorCallDemoClassBase::Ctor()");
        }

        protected InheritanceConstructorCallDemoClassBase(int arg)
        {
            m_messageBuffer.AppendLine("InheritanceConstructorCallDemoClassBase::Ctor(int)");
        }
    }

    internal class InheritanceConstructorCallDemoClass
        : InheritanceConstructorCallDemoClassBase
    {
        public InheritanceConstructorCallDemoClass()
        {
            m_messageBuffer.AppendLine("InheritanceConstructorCallDemoClass::Ctor()");      
        }

        public InheritanceConstructorCallDemoClass(int arg)
        {
            m_messageBuffer.AppendLine("InheritanceConstructorCallDemoClass::Ctor(int)");
        }

        public InheritanceConstructorCallDemoClass(string arg)
            : base(int.Parse(arg))
        {
            m_messageBuffer.AppendLine("InheritanceConstructorCallDemoClass::Ctor(string)");
        }

        public InheritanceConstructorCallDemoClass(int intArg, string strArg)
            : this(intArg)
        {
            m_messageBuffer.AppendLine("InheritanceConstructorCallDemoClass::Ctor(int, string)");
        }
    }
}