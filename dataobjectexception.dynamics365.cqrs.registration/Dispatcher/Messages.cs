using System;
using System.Linq;

namespace dataobjectexception.dynamics365.cqrs.registration.Dispatcher
{
    public sealed class Messages
    {
        private readonly IServiceProvider _serviceProvider;

        public Messages(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

       //todo
    }
}
