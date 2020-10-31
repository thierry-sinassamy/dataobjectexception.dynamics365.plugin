using dataobjectexception.dynamics365.cqrs.registration.Inversion;
using dataobjectexception.dynamics365.cqrs.registration.Result;
using System;

namespace dataobjectexception.dynamics365.cqrs.registration.PluginAssembly
{
    public sealed class UnRegisterPluginAssemblyCommandHandler : ICommandHandler<UnRegisterPluginAssemblyCommand>
    {
        private readonly IServiceProvider _serviceProvider;

        public UnRegisterPluginAssemblyCommandHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Purpose : handle the delete of the Plugin Assembly in the D365 Organization
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public ResultValidation Handle(UnRegisterPluginAssemblyCommand command)
        {            
            throw new NotImplementedException();
        }
    }
}
