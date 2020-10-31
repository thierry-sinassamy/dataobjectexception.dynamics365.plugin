using dataobjectexception.dynamics365.cqrs.registration.DataContext;
using dataobjectexception.dynamics365.cqrs.registration.Inversion;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using System;

namespace dataobjectexception.dynamics365.cqrs.registration.Repository
{
    public class PluginTypeRepository : Repository<Entities.PluginType>
    {
        public PluginTypeRepository(IDataContext dataContext) : base(dataContext)
        {
        }

        public override Entities.PluginType Find(Guid id)
        {
            return Datacontext.DataContextEntities.Retrieve(Entities.PluginType.EntityLogicalName, id, new ColumnSet() { AllColumns = true }).ToEntity<Entities.PluginType>();
        }

        public override Guid Create(Entities.PluginType entity)
        {
            return Datacontext.DataContextEntities.Create(entity);
        }

        public override OrganizationResponse CreateWithRequest(Entities.PluginType entity)
        {
            var request = new CreateRequest { Target = entity };
            return Datacontext.DataContextEntities.Execute(request);
        }

        public override OrganizationResponse UpdateWithRequest(Entities.PluginType entity)
        {
            var request = new UpdateRequest { Target = entity };
            return Datacontext.DataContextEntities.Execute(request);
        }

        public override OrganizationResponse DeleteWithRequest(Entities.PluginType entity)
        {
            var request = new DeleteRequest { Target = new EntityReference(entity.LogicalName, entity.Id) };
            return Datacontext.DataContextEntities.Execute(request);
        }
    }
}
