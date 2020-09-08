using System.Collections.Generic;
using dataobjectexception.dynamics365.plugin.Infrastructure.Inversion;
using dataobjectexception.dynamics365.plugin.Infrastructure.TriggerObject;

namespace dataobjectexception.dynamics365.plugin.Rule.Account
{
    public class ManagerProcessAccountAggregator : IPluginRuleTriggerAggregator<Dataobjectexception.Plugins.Models.Account>
    {
        public List<IPluginRuleTrigger<Dataobjectexception.Plugins.Models.Account>> CombineEntityRules(IContextPluginExecution<Dataobjectexception.Plugins.Models.Account> contextPluginExecution)
        {
            return new List<IPluginRuleTrigger<Dataobjectexception.Plugins.Models.Account>>()
            {
                (new RuleDisplayAccountBusinessRulePreCreate())
            };
        }
    }
}
