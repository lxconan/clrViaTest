using System.Collections.Generic;

namespace BanKai.Basic.Common
{
    internal class DelegateSubtractionDemoClass
    {
        private readonly List<string> m_trace = new List<string>();

        public void A()
        {
            m_trace.Add("A");
        }

        public void B()
        {
            m_trace.Add("B");
        }

        public void C()
        {
            m_trace.Add("C");
        }

        public override string ToString()
        {
            return string.Join(",", m_trace.ToArray());
        }
    }
}