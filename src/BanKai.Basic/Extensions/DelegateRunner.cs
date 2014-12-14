using System;

namespace BanKai.Basic.Extensions
{
    internal static class DelegateRunner
    {
        public static Exception RunAndGetUnhandledException(this Action action)
        {
            try
            {
                action();
            }
            catch (Exception error)
            {
                return error;
            }

            return null;
        }
    }
}