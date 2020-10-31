using dataobjectexception.dynamics365.cqrs.registration.Dispatcher;
using dataobjectexception.dynamics365.cqrs.registration.Factories;
using System;


namespace dataobjectexception.dynamics365.cqrs.registration.Manager
{
    public class DispatcherUnRegisterPluginAssembly : Factory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Messages _messages;

        public DispatcherUnRegisterPluginAssembly(IServiceProvider serviceProvider, Messages messages)
        {
            _serviceProvider = serviceProvider;
            _messages = messages;
        }

        public override void ProcessCommand()
        {
            //todo call _messages.Dispatch(new AdjustPluginAssemblyCommand(id));
        }
    }
}
