using dataobjectexception.dynamics365.crud.registration.DataContext;
using dataobjectexception.dynamics365.crud.registration.Inversion;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using System;

namespace dataobjectexception.dynamics365.crud.registration.Repository
{
    public class PluginAssemblyRepository : Repository<dataobjectexception.dynamics365.Entities.PluginAssembly>
    {
        public PluginAssemblyRepository(IDataContext dataContext) : base(dataContext)
        {
        }

        public override dataobjectexception.dynamics365.Entities.PluginAssembly Find(Guid id)
        {
            return Datacontext.DataContextEntities.Retrieve(dataobjectexception.dynamics365.Entities.Account.EntityLogicalName, id, new ColumnSet() { AllColumns = true }).ToEntity<dataobjectexception.dynamics365.Entities.PluginAssembly>();
        }

        public override Guid Create(dataobjectexception.dynamics365.Entities.PluginAssembly entity)
        {
            return Datacontext.DataContextEntities.Create(entity);
        }

        public override OrganizationResponse CreateWithRequest(dataobjectexception.dynamics365.Entities.PluginAssembly entity)
        {
            var request = new CreateRequest { Target = entity };
            return Datacontext.DataContextEntities.Execute(request);
        }
    }
}
