using dataobjectexception.dynamics365.cqrs.registration.Inversion;
using dataobjectexception.dynamics365.cqrs.registration.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace dataobjectexception.dynamics365.cqrs.registration.PluginAssembly
{
    public sealed class RegisterPluginAssemblyCommandHandler : ICommandHandler<RegisterPluginAssemblyCommand>
    {
        private readonly IServiceProvider _serviceProvider;

        public RegisterPluginAssemblyCommandHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ResultValidation Handle(RegisterPluginAssemblyCommand command)
        {            
            throw new NotImplementedException();//todo

            //comprend le service container avec tous les types de services

            //PluginAssembly.Name = command.Name, etc...
        }
    }
}
