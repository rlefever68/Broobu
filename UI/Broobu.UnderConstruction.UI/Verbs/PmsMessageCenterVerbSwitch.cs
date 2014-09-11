using Pms.Shell.UI;
using Pms.Shell.UI.Verbs;

namespace Pms.MessageCenter.UI.Verbs
{
    public class PmsMessageCenterVerbSwitch : VerbSwitchBase
    {

        public class Verb
        {
            public const string Flash = "Flash";
        }

        public PmsMessageCenterVerbSwitch(IPlugin plugin) 
            : base(plugin)
        {
        }

        /// <summary>
        /// Creates the verb processor.
        /// </summary>
        /// <param name="verb">The verb.</param>
        /// <returns></returns>
        protected override IVerbProcessor CreateVerbProcessor(string verb)
        {
            switch(verb)
            {
                case Verb.Flash:
                    {
                        return new FlashVerbProcessor();
                    }
                default:
                    {
                        return base.CreateVerbProcessor(verb);
                    }
            }
        }

    }
}