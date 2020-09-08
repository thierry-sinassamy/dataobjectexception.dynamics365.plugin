using System;
using dataobjectexception.dynamics365.plugin.Contract;
using dataobjectexception.dynamics365.plugin.Infrastructure.Inversion;
using Microsoft.Xrm.Sdk;

namespace dataobjectexception.dynamics365.plugin.Process.Account
{
    public class ProcessRuleDisplayAccountBusinessRule1PreCreate : IProcessRuleDisplayAccountBusinessRule1
    {
        public IDynamics365Repository<Dataobjectexception.Plugins.Models.Account> AccountRepository { get; set; } //not really need access to the repository 

        public bool Execute(IContext365<Dataobjectexception.Plugins.Models.Account> entityDynamics365)
        {
            if (entityDynamics365.ContextPluginExecution.EntityCurrent.ParentAccountId.Id == Guid.Empty)
                return false;

            entityDynamics365.ContextPluginExecution.EntityCurrent.MarketCap = new Money(0);

            return true;
        }
    }
}
