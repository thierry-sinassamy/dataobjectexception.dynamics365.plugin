using dataobjectexception.dynamics365.crud.registration.DataContext;
using dataobjectexception.dynamics365.crud.registration.Inversion;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using System;

namespace dataobjectexception.dynamics365.crud.registration.Repository
{
    public class PluginStepRepository : Repository<Entities.SdkMessageProcessingStep>
    {
        public PluginStepRepository(IDataContext dataContext) : base(dataContext)
        {
        }

        public override Entities.SdkMessageProcessingStep Find(Guid id)
        {
            return Datacontext.DataContextEntities.Retrieve(Entities.SdkMessageProcessingStep.EntityLogicalName, id, new ColumnSet() { AllColumns = true }).ToEntity<Entities.SdkMessageProcessingStep>();
        }

        public override Guid Create(Entities.SdkMessageProcessingStep entity)
        {
            return Datacontext.DataContextEntities.Create(entity);
        }

        public override OrganizationResponse CreateWithRequest(Entities.SdkMessageProcessingStep entity)
        {
            var request = new CreateRequest { Target = entity };
            return Datacontext.DataContextEntities.Execute(request);
        }
    }
}
