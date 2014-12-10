using System.Collections.Generic;

namespace BanKai.Basic.Common
{
    internal class MulticastDelegateDemoClass
    {
        private readonly List<string> m_trace = new List<string>();

        public void OneMethod()
        {
            m_trace.Add("MulticastDelegateDemoClass.OneMethod() called");
        }

        public void AnotherMethod()
        {
            m_trace.Add("MulticastDelegateDemoClass.AnotherMethod() called");
        }

        public string[] Trace
        {
            get { return m_trace.ToArray(); }
        }
    }
}