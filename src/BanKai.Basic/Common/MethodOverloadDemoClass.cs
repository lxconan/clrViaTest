namespace BanKai.Basic.Common
{
    public class MethodOverloadDemoClass
    {
        public string Foo()
        {
            return "Foo()";
        }

        public string Foo(int a)
        {
            return "Foo(int)";
        }

        public string Foo(object a)
        {
            return "Foo(object)";
        }

        public string Foo(string a)
        {
            return "Foo(string)";
        }
    }
}