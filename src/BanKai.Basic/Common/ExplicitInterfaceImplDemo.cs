namespace BanKai.Basic.Common
{
    internal interface ITextStream
    {
        string Read();
        void Write(string text);
    }

    internal class ReadOnlyStream : ITextStream
    {
        private string m_storage = "This is the result";

        public string Read()
        {
            return m_storage;
        }

        void ITextStream.Write(string text)
        {
            m_storage = text;
        }
    }
}