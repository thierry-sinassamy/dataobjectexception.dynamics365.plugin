using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using dataobjectexception.dynamics365.plugin.Infrastructure.Inversion;
using Microsoft.Xrm.Sdk;

// ReSharper disable once IdentifierTypo
namespace dataobjectexception.dynamics365.plugin.Infrastructure.ContextObject
{
    public class ContextPluginExecution<T> : IContextPluginExecution<T> where T : Entity, new()
    {
        public string ProcessName { get; set; }
        public IDictionary<object, object> Items { get; set; }
        public string Message { get; set; }
        public bool Synchronous { get; set; }
        public int Stage { get; set; }
        public string OrganizationName { get; set; }
        public Entity EntityInput { get; set; }
        public T EntityCurrent { get; set; }
        public T EntityBefore { get; set; }
        public T EntityAfter { get; set; }
        public Guid? UserId { get; set; }
        public Guid? InitiatorId { get; set; }
        public IServiceContainer ServiceContainer { get; set; }

        public ContextPluginExecution(string processName, IPluginExecutionContext pluginExecutionContextContext)
        {
            ProcessName = processName;
            Message = pluginExecutionContextContext.MessageName;
            Stage = pluginExecutionContextContext.Stage;
            Synchronous = pluginExecutionContextContext.Mode == 0;
            EntityInput = pluginExecutionContextContext.InputParameters["Target"] as Entity;
            EntityCurrent = EntityInput?.ToEntity<T>();
            var instance = Activator.CreateInstance<T>();
            var preEntityImage = GetPreEntityImage(pluginExecutionContextContext, "PreImage"); //instance.LogicalName
            var postEntityImage = GetPostEntityImage(pluginExecutionContextContext, "PostImage"); //instance.LogicalName
            EntityBefore = preEntityImage?.ToEntity<T>();
            EntityAfter = postEntityImage?.ToEntity<T>();
            UserId = pluginExecutionContextContext.UserId;
            InitiatorId = pluginExecutionContextContext.InitiatingUserId;
            OrganizationName = pluginExecutionContextContext.OrganizationName;
        }

        private static Entity GetPreEntityImage(IPluginExecutionContext pluginExecutionContextContext, string imageName)
        {
            if (string.IsNullOrEmpty(imageName) || pluginExecutionContextContext == null || !pluginExecutionContextContext.PreEntityImages.Contains(imageName))
                return null;
            return pluginExecutionContextContext.PreEntityImages[imageName];
        }

        private static Entity GetPostEntityImage(IPluginExecutionContext pluginExecutionContextContext, string imageName)
        {
            if (pluginExecutionContextContext.MessageName == "Delete")
                return null;
            if (string.IsNullOrEmpty(imageName) || !pluginExecutionContextContext.PostEntityImages.Contains(imageName))
                return null;
            return pluginExecutionContextContext.PostEntityImages[imageName];
        }
    }
}
