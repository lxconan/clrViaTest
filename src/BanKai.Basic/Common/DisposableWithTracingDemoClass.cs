using System;
using System.Text;

namespace BanKai.Basic.Common
{
    public class DisposableWithTracingDemoClass : IDisposable
    {
        private readonly StringBuilder m_tracer;

        public DisposableWithTracingDemoClass(StringBuilder tracer)
        {
            m_tracer = tracer;
            m_tracer.AppendLine("constructor called.");
        }

        public void Dispose()
        {
            m_tracer.AppendLine("dispose called.");
        }
    }
}