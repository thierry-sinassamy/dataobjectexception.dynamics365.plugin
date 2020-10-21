using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using dataobjectexception.dynamics365.plugin.Infrastructure.ContextObject;
using dataobjectexception.dynamics365.plugin.Infrastructure.Injection;
using dataobjectexception.dynamics365.plugin.Registration;
using Microsoft.Xrm.Sdk;
using dataobjectexception.dynamics365.Entities;
using static dataobjectexception.dynamics365.plugin.Registration.D365RegistrationPluginAttribute;

namespace dataobjectexception.dynamics365.plugin.Plugin.Account
{
    [D365RegistrationPlugin(MessageNameEnum.Update, Entities.Account.EntityLogicalName, "accountnumber", "dataobjectexception.dynamics365.account.preupdate",
                            ExecutionModeEnum.Synchronous, StageEnum.PreOperation, 1, IsolationModeEnum.Sandbox,
                            Image1Type = ImageTypeEnum.PreImage, Image1Name = "PreImage", Image1EntityAliasName = "PreImage", Image1Attributes = "name, accountnumber")]
    [D365RegistrationPlugin(MessageNameEnum.Update, Entities.Account.EntityLogicalName,"name, accountnumber", "dataobjectexception.dynamics365.account.postupdate", 
                            ExecutionModeEnum.Synchronous, StageEnum.PostOperation, 1, IsolationModeEnum.Sandbox, 
                            Image1Type = ImageTypeEnum.PreImage, Image1Name = "PreImage", Image1EntityAliasName = "PreImage", Image1Attributes = "...",
                            Image2Type = ImageTypeEnum.PostImage, Image2Name = "PostImage", Image2EntityAliasName = "PostImage", Image2Attributes = "...")]
    public class AccountPlugin : IPlugin
    {       
        public void Execute(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null) { throw new ArgumentNullException(nameof(serviceProvider)); }

            ServiceContainer serviceContainer = null;
            try
            {
                var localPluginContext = InitializationPlugins.InitializeContextPluginExecutionAccountPreCreate(serviceProvider);
                if (localPluginContext == null) return;
                var serviceOrganizationContext = InitializationPlugins.InitialiserServicesOrganizationAccount(serviceProvider);
                if (serviceOrganizationContext == null) return;

                serviceContainer = IocContainer.Instance;

                var items = new Dictionary<object, object>();
                var serviceContextContainer = InitializationPlugins.InitialiserServicesContainer(serviceContainer, serviceOrganizationContext);
                if (serviceContextContainer == null) return;

                var localContext365 = new Context365<Entities.Account>("", serviceContextContainer, serviceOrganizationContext, localPluginContext, items);

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
