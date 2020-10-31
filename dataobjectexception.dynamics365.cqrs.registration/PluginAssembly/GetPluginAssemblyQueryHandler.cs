using dataobjectexception.dynamics365.cqrs.registration.Inversion;
using System;
using System.Collections.Generic;

namespace dataobjectexception.dynamics365.cqrs.registration.PluginAssembly
{
    public sealed class GetPluginAssemblyQueryHandler : IQueryHandler<GetPluginAssemblyQuery, List<Entities.PluginAssembly>>
    {
        private readonly IServiceProvider _serviceProvider;

        public GetPluginAssemblyQueryHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Purpose : handle the query of the Plugin Assembly already deployed in the D365 Organization
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public List<Entities.PluginAssembly> Handle(GetPluginAssemblyQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
