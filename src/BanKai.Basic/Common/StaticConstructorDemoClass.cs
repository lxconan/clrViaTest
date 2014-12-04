namespace BanKai.Basic.Common
{
    // ReSharper disable FieldCanBeMadeReadOnly.Local

    public class StaticConstructorDemoClass
    {
        private static string s_staticField;

        static StaticConstructorDemoClass()
        {
            s_staticField = "You are so cute!";
        }

        public static string StaticField
        {
            get { return s_staticField; }
        }
    }

    // ReSharper restore FieldCanBeMadeReadOnly.Local
}