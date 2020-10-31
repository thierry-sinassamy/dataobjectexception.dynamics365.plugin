using dataobjectexception.dynamics365.cqrs.registration.DataContext;
using dataobjectexception.dynamics365.cqrs.registration.Inversion;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using System;

namespace dataobjectexception.dynamics365.cqrs.registration.Repository
{
    public class PluginAssemblyRepository : Repository<Entities.PluginAssembly>
    {
        public PluginAssemblyRepository(IDataContext dataContext) : base(dataContext)
        {
        }

        public override Entities.PluginAssembly Find(Guid id)
        {
            return Datacontext.DataContextEntities.Retrieve(Entities.PluginAssembly.EntityLogicalName, id, new ColumnSet() { AllColumns = true }).ToEntity<Entities.PluginAssembly>();
        }

        public override Guid Create(Entities.PluginAssembly entity)
        {
            return Datacontext.DataContextEntities.Create(entity);
        }

        public override OrganizationResponse CreateWithRequest(Entities.PluginAssembly entity)
        {
            var request = new CreateRequest { Target = entity };
            return Datacontext.DataContextEntities.Execute(request);
        }

        public override OrganizationResponse UpdateWithRequest(Entities.PluginAssembly entity)
        {
            var request = new UpdateRequest { Target = entity };
            return Datacontext.DataContextEntities.Execute(request);
        }

        public override OrganizationResponse DeleteWithRequest(Entities.PluginAssembly entity)
        {
            var request = new DeleteRequest { Target = new EntityReference(entity.LogicalName, entity.Id) };
            return Datacontext.DataContextEntities.Execute(request);
        }
    }
}
