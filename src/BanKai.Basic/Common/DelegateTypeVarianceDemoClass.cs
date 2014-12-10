namespace BanKai.Basic.Common
{
    internal class DelegateTypeVarianceDemoClass
    {
        public string ReturnsMoreSpecificType()
        {
            return "Hello";
        }

        public string InputMoreGeneralType(object obj)
        {
            return obj.ToString();
        }
    }
}