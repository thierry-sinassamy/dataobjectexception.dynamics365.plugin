using dataobjectexception.dynamics365.cqrs.registration.Inversion;
using System;
using System.Collections.Generic;

namespace dataobjectexception.dynamics365.cqrs.registration.PluginAssembly
{
    public sealed class GetPluginStepImageQuery : IQuery<List<Entities.SdkMessageProcessingStepImage>>
    {
        public Guid Id { get; }
        public string Name { get; }
        public Guid PluginStepId { get; }

        public GetPluginStepImageQuery(Guid id, string name, Guid pluginStepId)
        {
            Id = id;
            Name = name;
            PluginStepId = pluginStepId;
        }
    }
}
