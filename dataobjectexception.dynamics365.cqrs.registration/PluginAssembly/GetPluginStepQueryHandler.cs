using dataobjectexception.dynamics365.cqrs.registration.Inversion;
using dataobjectexception.dynamics365.Entities;
using System;
using System.Collections.Generic;

namespace dataobjectexception.dynamics365.cqrs.registration.PluginAssembly
{
    public sealed class GetPluginStepQueryHandler : IQueryHandler<GetPluginStepQuery, List<Entities.SdkMessageProcessingStep>>
    {
        private readonly IServiceProvider _serviceProvider;

        public GetPluginStepQueryHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Purpose : handle the query of the Plugin Step related to the Plugin Type in the D365 Organization
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public List<SdkMessageProcessingStep> Handle(GetPluginStepQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
