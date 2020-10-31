using dataobjectexception.dynamics365.cqrs.registration.Dispatcher;
using dataobjectexception.dynamics365.cqrs.registration.Infrastructure;
using dataobjectexception.dynamics365.cqrs.registration.Result;
using System;

namespace dataobjectexception.dynamics365.cqrs.registration.Manager
{
    public class FactoryManager
    {
        public object GenerateFactories(ResultValidation resultValidation, IServiceProvider service, Messages messages)
        {
            object factory;
            switch (resultValidation.Tag)
            {
                case EnumTag.Tag_Adjust:
                    factory = new DispatcherAdjustPluginAssembly(service, messages);
                    break;
                case EnumTag.Tag_Register:
                    factory = new DispatcherRegisterPluginAssembly(service, messages);
                    break;
                case EnumTag.Tag_UnRegister:
                    factory = new DispatcherUnRegisterPluginAssembly(service, messages);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(resultValidation.Tag), resultValidation.DisplayName);
            }
            return factory;
        }
    }
}
