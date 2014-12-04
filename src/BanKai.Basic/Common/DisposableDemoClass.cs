using System;

namespace BanKai.Basic.Common
{
    public class DisposableDemoClass : IDisposable
    {
        public DisposableDemoClass()
        {
            IsDisposed = false;
        }

        public bool IsDisposed { get; set; }

        public void Dispose()
        {
            IsDisposed = true;
        }
    }
}