using System;
using System.ComponentModel.Design;
using dataobjectexception.dynamics365.plugin.Contract;
using dataobjectexception.dynamics365.plugin.Infrastructure.ContextObject;
using dataobjectexception.dynamics365.plugin.Infrastructure.Inversion;
using dataobjectexception.dynamics365.plugin.Process.Account;
using Microsoft.Xrm.Sdk;

namespace dataobjectexception.dynamics365.plugin.Plugin
{
    public static class InitializationPlugins
    {
        #region Account

        public static IContextPluginExecution<Dataobjectexception.Plugins.Models.Account> InitializeContextPluginExecutionAccountPreCreate(IServiceProvider serviceProvider)
        {
            var pluginExecutionContext = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));

            var validInputParameters = (pluginExecutionContext.InputParameters.Contains("Target") && (pluginExecutionContext.InputParameters["Target"] is Entity))
                                  || ((pluginExecutionContext.InputParameters.Contains("EntityMoniker") && (pluginExecutionContext.InputParameters["EntityMoniker"] is Entity)));

            if (validInputParameters == false) { return null; }

            var contextPluginExecution = new ContextPluginExecution<Dataobjectexception.Plugins.Models.Account>("", pluginExecutionContext);
            return contextPluginExecution;
        }

        public static IContextDynamics365Service InitialiserServicesOrganizationAccount(IServiceProvider serviceProvider)
        {
            var pluginExecutionContext = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            var contextDynamics365Service = new ContextDynamics365Service("", pluginExecutionContext, serviceProvider);
            return contextDynamics365Service;
        }

        public static IContextDynamics365Process InitialiserServicesContainer(IServiceContainer serviceContainer, IContextDynamics365Service contextDynamics365Service)
        {
            //Repository
            if ((IDynamics365Repository<Dataobjectexception.Plugins.Models.Account>)serviceContainer.GetService(typeof(IDynamics365Repository<Dataobjectexception.Plugins.Models.Account>)) == null)
                
            //Manager
            if ((IManagerProcessAccount)serviceContainer.GetService(typeof(IManagerProcessAccount)) == null)
                serviceContainer.AddService(typeof(IManagerProcessAccount), new ManagerProcessAccount());

            var contexteProcessus = new ContextDynamics365Process("", serviceContainer);
            return contexteProcessus;
        }

        public static void StartProcessTransactionAccount(IServiceContainer serviceContainer, IContext365<Dataobjectexception.Plugins.Models.Account> contexteGlobal)
        {
            var process = (IManagerProcessAccount)serviceContainer.GetService(typeof(IManagerProcessAccount));
            var processExecuted = process.Execute(contexteGlobal);
        }

        #endregion
    }
}
