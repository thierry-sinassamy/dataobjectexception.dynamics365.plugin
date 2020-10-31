using dataobjectexception.dynamics365.cqrs.registration.Factories;
using dataobjectexception.dynamics365.cqrs.registration.Inversion;
using dataobjectexception.dynamics365.cqrs.registration.Result;
using System;

namespace dataobjectexception.dynamics365.cqrs.registration.PluginAssembly
{
    public sealed class AdjustPluginAssemblyCommandHandler : ICommandHandler<AdjustPluginAssemblyCommand>
    {
        private readonly IServiceProvider _serviceProvider;

        public AdjustPluginAssemblyCommandHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Purpose : handle the update of the Plugin Assembly in the D365 Organization
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public ResultValidation Handle(AdjustPluginAssemblyCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
