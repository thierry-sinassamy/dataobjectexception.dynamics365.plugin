using System.Collections.Generic;
using dataobjectexception.dynamics365.plugin.Infrastructure.Inversion;
using dataobjectexception.dynamics365.plugin.Infrastructure.TriggerObject;

namespace dataobjectexception.dynamics365.plugin.Rule.Account
{
    public class ManagerProcessAccountAggregator : IPluginRuleTriggerAggregator<dataobjectexception.dynamics365.Entities.Account>
    {
        public List<IPluginRuleTrigger<dataobjectexception.dynamics365.Entities.Account>> CombineEntityRules(IContextPluginExecution<dataobjectexception.dynamics365.Entities.Account> contextPluginExecution)
        {
            return new List<IPluginRuleTrigger<dataobjectexception.dynamics365.Entities.Account>>()
            {
                (new RuleDisplayAccountBusinessRulePreCreate())
            };
        }
    }
}
