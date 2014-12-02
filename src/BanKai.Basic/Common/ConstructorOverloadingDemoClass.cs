using System.Text;

namespace BanKai.Basic.Common
{
    public class ConstructorOverloadingDemoClass
    {
        private readonly StringBuilder m_reportBuilder = new StringBuilder();

        public ConstructorOverloadingDemoClass()
        {
            m_reportBuilder.AppendLine("Ctor()");
        }

        public ConstructorOverloadingDemoClass(string arg) 
            : this()
        {
            m_reportBuilder.AppendLine("Ctor(string)");
        }

        public string ConstructorCallSequence
        {
            get { return m_reportBuilder.ToString(); }
        }
    }
}