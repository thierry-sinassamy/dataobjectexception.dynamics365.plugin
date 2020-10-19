using System.Collections.Generic;
using System.Linq;
using dataobjectexception.dynamics365.plugin.Infrastructure.Inversion;
using dataobjectexception.dynamics365.plugin.Infrastructure.TriggerObject;
using dataobjectexception.dynamics365.plugin.Rule.Account;

namespace dataobjectexception.dynamics365.plugin.Process.Account
{
    public class ManagerProcessAccount : IManagerProcessAccount
    {
        public bool Execute(IContext365<dataobjectexception.dynamics365.Entities.Account> entityDynamics365)
        {
            var rules = new List<IPluginRuleTrigger<dataobjectexception.dynamics365.Entities.Account>>();
                rules.AddRange(new ManagerProcessAccountAggregator().CombineEntityRules(entityDynamics365.ContextPluginExecution)
                .Where(r => r.Message == entityDynamics365.ContextPluginExecution.Message &&
                                                    r.Stage == entityDynamics365.ContextPluginExecution.Stage &&
                                                    r.Synchronous == entityDynamics365.ContextPluginExecution.Synchronous));

            foreach (var rule in rules.Where(rule => rule.ValidateBusinessRule(entityDynamics365)))
            {
                rule.Process.Execute(entityDynamics365); 
            }
            return true;
        }
    }
}
