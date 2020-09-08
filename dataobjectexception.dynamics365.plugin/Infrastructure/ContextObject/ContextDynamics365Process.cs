using System.Collections.Generic;
using System.ComponentModel.Design;
using dataobjectexception.dynamics365.plugin.Infrastructure.Inversion;

// ReSharper disable once IdentifierTypo
namespace dataobjectexception.dynamics365.plugin.Infrastructure.ContextObject
{
    public class ContextDynamics365Process : IContextDynamics365Process
    {
        public string ProcessName { get; set; }
        public IDictionary<object, object> Items { get; set; }
        public IServiceContainer ServiceContainer { get; set; }

        public ContextDynamics365Process(string processName)
        {
            ProcessName = processName;
            Items = new Dictionary<object, object>();
        }

        public ContextDynamics365Process(string processName, IDictionary<object, object> items)
            : this(processName)
        {
            Items = items;
        }
        
        public ContextDynamics365Process(string processName, IServiceContainer serviceContainer)
            : this(processName)
        {
            ServiceContainer = serviceContainer;
        }
    }
}
