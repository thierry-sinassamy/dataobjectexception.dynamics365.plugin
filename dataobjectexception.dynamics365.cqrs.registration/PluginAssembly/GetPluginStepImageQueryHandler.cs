using dataobjectexception.dynamics365.cqrs.registration.Inversion;
using dataobjectexception.dynamics365.Entities;
using System;
using System.Collections.Generic;

namespace dataobjectexception.dynamics365.cqrs.registration.PluginAssembly
{
    public sealed class GetPluginStepImageQueryHandler : IQueryHandler<GetPluginStepImageQuery, List<Entities.SdkMessageProcessingStepImage>>
    {
        private readonly IServiceProvider _serviceProvider;

        public GetPluginStepImageQueryHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public List<SdkMessageProcessingStepImage> Handle(GetPluginStepImageQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
