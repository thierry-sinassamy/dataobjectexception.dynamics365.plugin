using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using dataobjectexception.dynamics365.plugin.Infrastructure.ContextObject;
using dataobjectexception.dynamics365.plugin.Infrastructure.Injection;
using Microsoft.Xrm.Sdk;

namespace dataobjectexception.dynamics365.plugin.Plugin.Account
{
    public class AccountPlugin : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null) { throw new ArgumentNullException(nameof(serviceProvider)); }

            ServiceContainer serviceContainer = null;
            try
            {
                var localPluginContext =
                    InitializationPlugins.InitializeContextPluginExecutionAccountPreCreate(serviceProvider);
                if (localPluginContext == null) return;
                var serviceOrganizationContext =
                    InitializationPlugins.InitialiserServicesOrganizationAccount(serviceProvider);
                if (serviceOrganizationContext == null) return;

                serviceContainer = IocContainer.Instance;

                var items = new Dictionary<object, object>();
                var serviceContextContainer =
                    InitializationPlugins.InitialiserServicesContainer(serviceContainer, serviceOrganizationContext);
                if (serviceContextContainer == null) return;

                var localContext365 = new Context365<Dataobjectexception.Plugins.Models.Account>("",
                    serviceContextContainer, serviceOrganizationContext, localPluginContext, items);

                InitializationPlugins.StartProcessTransactionAccount(serviceContainer, localContext365);
            }
            catch (StackOverflowException soe)
            {
                throw new StackOverflowException($"Error [StackOverflowException] in AccountPlugin - [execute] method : {soe.Message}");
            }
            catch(TimeoutException te)
            {
                throw new TimeoutException($"Error [TimeoutException] in AccountPlugin - [execute] method : {te.Message}");
            }
            catch (Exception e)
            {
                throw new InvalidPluginExecutionException($"Error in AccountPlugin - [execute] method : {e.Message}");
            }
            finally
            {
                serviceContainer?.Dispose();
            }
        }
    }
}
