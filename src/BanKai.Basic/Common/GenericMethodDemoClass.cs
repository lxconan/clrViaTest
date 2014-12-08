namespace BanKai.Basic.Common
{
    internal class GenericMethodDemoClass
    {
        public static string ResolvableGenericMethod<T>(T arg)
        {
            return string.Format("ResolvableGenericMethod(T) called. T is {0}", typeof(T).Name);
        }

        public static string NotResolvableGenericMethod<T>()
        {
            return string.Format("NotResolvableGenericMethod() called. T is {0}", typeof(T).Name);
        }
    }
}