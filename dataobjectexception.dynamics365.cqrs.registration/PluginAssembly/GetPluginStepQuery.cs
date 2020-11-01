using dataobjectexception.dynamics365.cqrs.registration.Inversion;
using System;
using System.Collections.Generic;

namespace dataobjectexception.dynamics365.cqrs.registration.PluginAssembly
{
    public sealed class GetPluginStepQuery : IQuery<List<Entities.SdkMessageProcessingStep>>
    {
        public Guid Id { get; }
        public string Name { get; }
        public Guid PluginTypeId { get; }

        public GetPluginStepQuery(Guid id, string name, Guid pluginTypeId)
        {
            Id = id;
            Name = name;
            PluginTypeId = pluginTypeId;
        }
    }
}
