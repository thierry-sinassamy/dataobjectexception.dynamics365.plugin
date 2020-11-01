using dataobjectexception.dynamics365.cqrs.registration.Inversion;
using System;
using System.Collections.Generic;

namespace dataobjectexception.dynamics365.cqrs.registration.PluginAssembly
{
    public sealed class GetPluginTypeQuery : IQuery<List<Entities.PluginType>>
    {
        public Guid Id { get; }
        public string Name { get; }
        public Guid PluginAssemblyId { get; }
        public Guid SolutionId { get; }

        public GetPluginTypeQuery(Guid id, string name, Guid pluginAssemblyId, Guid solutionId)
        {
            Id = id;
            Name = name;
            PluginAssemblyId = pluginAssemblyId;
            SolutionId = solutionId;
        }
    }
}
