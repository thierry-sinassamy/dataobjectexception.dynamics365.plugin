using System;
using System.Collections.Generic;
using System.Text;
using dataobjectexception.dynamics365.plugin.Contract;
using dataobjectexception.dynamics365.plugin.Infrastructure.Inversion;
using Dataobjectexception.Plugins.Models;

namespace dataobjectexception.dynamics365.plugin.Repository
{
    public class AccountRepository : Dynamics365Repository<Account>
    {
        public AccountRepository(IContextDynamics365Service contextDynamics365Service) : base(contextDynamics365Service)
        {
        }

        public override Account Find(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
