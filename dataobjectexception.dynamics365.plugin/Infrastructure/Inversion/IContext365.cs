using System.Collections.Generic;
using Microsoft.Xrm.Sdk;

// ReSharper disable once IdentifierTypo
namespace dataobjectexception.dynamics365.plugin.Infrastructure.Inversion
{
    public interface IContext365<TEntity> where TEntity : Entity
    {
        string ContextName { get; set; }
        IDictionary<object, object> Items { get; set; }
        IContextDynamics365Process ContextProcess { get; set; }
        IContextPluginExecution<TEntity> ContextPluginExecution { get; set; }
        IContextDynamics365Service ContextPluginService { get; set; }
    }
}
