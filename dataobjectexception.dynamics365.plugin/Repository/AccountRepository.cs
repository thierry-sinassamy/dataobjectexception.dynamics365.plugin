using System;
using dataobjectexception.dynamics365.plugin.Contract;
using dataobjectexception.dynamics365.plugin.Infrastructure.Inversion;
using Microsoft.Xrm.Sdk.Query;

namespace dataobjectexception.dynamics365.plugin.Repository
{
    public class AccountRepository : Dynamics365Repository<dataobjectexception.dynamics365.Entities.Account>
    {
        public AccountRepository(IContext365<dataobjectexception.dynamics365.Entities.Account> contextDynamics365) : base(contextDynamics365)
        {
        }

        public override dataobjectexception.dynamics365.Entities.Account Find(Guid id)
        {
            return ServicesOrganization.Retrieve(dataobjectexception.dynamics365.Entities.Account.EntityLogicalName, id, new ColumnSet() { AllColumns = true}).ToEntity<dataobjectexception.dynamics365.Entities.Account>();
        }
    }
}
