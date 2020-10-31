using dataobjectexception.dynamics365.cqrs.registration.Inversion;
using System.Collections.Generic;

namespace dataobjectexception.dynamics365.cqrs.registration.PluginAssembly
{
    public sealed class GetPluginAssemblyQuery : IQuery<List<Entities.PluginAssembly>>
    {
        public string Name { get; }

        public GetPluginAssemblyQuery(string name)
        {
            Name = name;
        }
    }
}
