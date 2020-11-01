using dataobjectexception.dynamics365.cqrs.registration.Inversion;
using dataobjectexception.dynamics365.Entities;
using System;
using System.Collections.Generic;

namespace dataobjectexception.dynamics365.cqrs.registration.PluginAssembly
{
    public sealed class GetPluginTypeQueryHandler : IQueryHandler<GetPluginTypeQuery, List<Entities.PluginType>>
    {
        private readonly IServiceProvider _serviceProvider;

        public GetPluginTypeQueryHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Purpose : handle the query of the Plugin Type related to the Plugin Assembly in the D365 Organization
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public List<PluginType> Handle(GetPluginTypeQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
