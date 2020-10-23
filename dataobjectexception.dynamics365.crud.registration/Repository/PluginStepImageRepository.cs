using dataobjectexception.dynamics365.crud.registration.DataContext;
using dataobjectexception.dynamics365.crud.registration.Inversion;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using System;

namespace dataobjectexception.dynamics365.crud.registration.Repository
{
    public class PluginStepImageRepository : Repository<Entities.SdkMessageProcessingStepImage>
    {
        public PluginStepImageRepository(IDataContext dataContext) : base(dataContext)
        {
        }

        public override Entities.SdkMessageProcessingStepImage Find(Guid id)
        {
            return Datacontext.DataContextEntities.Retrieve(Entities.SdkMessageProcessingStepImage.EntityLogicalName, id, new ColumnSet() { AllColumns = true }).ToEntity<Entities.SdkMessageProcessingStepImage>();
        }

        public override Guid Create(Entities.SdkMessageProcessingStepImage entity)
        {
            return Datacontext.DataContextEntities.Create(entity);
        }

        public override OrganizationResponse CreateWithRequest(Entities.SdkMessageProcessingStepImage entity)
        {
            var request = new CreateRequest { Target = entity };
            return Datacontext.DataContextEntities.Execute(request);
        }
    }
}
