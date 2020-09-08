using System.Collections.Generic;
using dataobjectexception.dynamics365.plugin.Infrastructure.Inversion;
using Microsoft.Xrm.Sdk;

// ReSharper disable once IdentifierTypo
namespace dataobjectexception.dynamics365.plugin.Infrastructure.ContextObject
{
    public class Context365<T> : IContext365<T> where T : Entity
    {
        public string ContextName { get; set; }
        public IDictionary<object, object> Items { get; set; }
        public IContextDynamics365Process ContextProcess { get; set; }
        public IContextPluginExecution<T> ContextPluginExecution { get; set; }
        public IContextDynamics365Service ContextPluginService { get; set; }

        public Context365(string contextName)
        {
            ContextName = contextName;
        }

        public Context365(string contextName, IDictionary<object, object> items)
            : this(contextName)
        {
            Items = items;
        }

        public Context365(string contextName, IContextDynamics365Process contextProcess, IContextDynamics365Service contextPluginService, IContextPluginExecution<T> contextPluginExecution, IDictionary<object, object> items)
            : this(contextName)
        {
            ContextName = contextName;
            Items = items;
            ContextProcess = contextProcess;
            ContextPluginExecution = contextPluginExecution;
            ContextPluginService = contextPluginService;
        }
    }
}
