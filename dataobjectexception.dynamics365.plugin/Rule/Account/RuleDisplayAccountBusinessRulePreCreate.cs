using System;
using System.Collections.Generic;
using System.Text;
using dataobjectexception.dynamics365.plugin.Contract;
using dataobjectexception.dynamics365.plugin.Infrastructure;
using dataobjectexception.dynamics365.plugin.Infrastructure.Inversion;
using dataobjectexception.dynamics365.plugin.Infrastructure.TriggerObject;
using dataobjectexception.dynamics365.plugin.Process.Account;

namespace dataobjectexception.dynamics365.plugin.Rule.Account
{
    public class RuleDisplayAccountBusinessRulePreCreate : IPluginRuleTrigger<Dataobjectexception.Plugins.Models.Account>
    {
        private IProcessRuleDisplayAccountBusinessRule1 _process;
        public string Code { get; }
        public string Message => MessageName.Creation;
        public int Stage => PipelineStage.PreOperation;
        public bool Synchronous => true;
        public IDynamics365Process<Dataobjectexception.Plugins.Models.Account> Process { get; }


        public bool ValidateBusinessRule(IContext365<Dataobjectexception.Plugins.Models.Account> contextDynamics365)
        {
            if (!contextDynamics365.ContextPluginExecution.EntityCurrent.AccountId.HasValue)
                return false;

            _process = new ProcessRuleDisplayAccountBusinessRule1PreCreate
            {
                AccountRepository = (IDynamics365Repository<Dataobjectexception.Plugins.Models.Account>)contextDynamics365
                                                .ContextProcess.ServiceContainer
                                                .GetService(typeof(IDynamics365Repository<Dataobjectexception.Plugins.Models.Account>)),
            };

            return true;
        }
    }
}
