namespace BanKai.Basic.Common
{
    internal interface IMoveable
    {
        void MoveTo(int x, int y);
        string WhereAmI { get; }
    }

    internal interface ITalkable
    {
        string Talk();
    }

    internal class Duck : IMoveable, ITalkable
    {
        private int m_x;
        private int m_y;

        public void MoveTo(int x, int y)
        {
            m_x = x;
            m_y = y;
        }

        public string WhereAmI
        {
            get { return string.Format("You are at ({0}, {1})", m_x, m_y); }
        }

        public string Talk()
        {
            return "Ga, ga, ...";
        }
    }
}