namespace BanKai.Basic.Common
{
    public class CustomizePropertyDemoClass
    {
        private string m_name;

        public string Name
        {
            get { return "Your Name Is " + m_name; }
            set { m_name = value; }
        } 
    }
}