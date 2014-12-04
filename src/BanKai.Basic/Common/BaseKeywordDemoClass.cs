namespace BanKai.Basic.Common
{
    // ReSharper disable RedundantBaseQualifier

    internal abstract class BaseKeywordDemoClassBase
    {
        protected string Ending
        {
            get { return "."; }
        }

        public virtual string Name
        {
            get { return "BaseClass"; }
        }
    }

    internal class BaseKeywordDemoClass : BaseKeywordDemoClassBase
    {
        public override string Name
        {
            get { return base.Name + "'s derived class" + base.Ending; }
        }
    }

    // ReSharper restore RedundantBaseQualifier
}