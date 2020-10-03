using System;
using Dataobjectexception.Plugins.Models;
using dataobjectexception.dynamics365.plugin.Contract;
using dataobjectexception.dynamics365.plugin.Infrastructure.Inversion;
using Microsoft.Xrm.Sdk.Query;

namespace dataobjectexception.dynamics365.plugin.Repository
{
    public class AccountRepository : Dynamics365Repository<Account>
    {
        public AccountRepository(IContext365<Account> contextDynamics365) : base(contextDynamics365)
        {
        }

        public override Account Find(Guid id)
        {
            return ServicesOrganization.Retrieve(Account.EntityLogicalName, id, new ColumnSet() { AllColumns = true}).ToEntity<Account>();
        }
    }
}
