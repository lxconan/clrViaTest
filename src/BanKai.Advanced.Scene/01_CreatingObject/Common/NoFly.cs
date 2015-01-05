namespace BanKai.Advanced.Scene._01_CreatingObject.Common
{
    internal class NoFly : IFlyBehavior
    {
        public bool CanFly
        {
            get { return false; }
        }
    }
}