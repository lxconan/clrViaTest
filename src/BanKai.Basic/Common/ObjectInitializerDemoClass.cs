namespace BanKai.Basic.Common
{
    public class ObjectInitializerDemoClass
    {
        public ObjectInitializerDemoClass()
        {
        }

        public ObjectInitializerDemoClass(string property1)
        {
            Property1 = property1;
        }

        public string Property1 { get; set; }
        public string Property2 { get; set; }
    }
}