using dataobjectexception.dynamics365.crud.registration.NonBinaryTree;
using dataobjectexception.dynamics365.crud.registration.Infrastructure;
using System.Collections.Generic;
using dataobjectexception.dynamics365.crud.registration.Inversion;
using dataobjectexception.dynamics365.crud.registration.Rule;
using dataobjectexception.dynamics365.crud.registration.Result;
using dataobjectexception.dynamics365.crud.registration.Manager;
using System.ComponentModel.Design;
using dataobjectexception.dynamics365.crud.registration.Singleton;
using dataobjectexception.dynamics365.crud.registration.Strategy;
using dataobjectexception.dynamics365.crud.registration.Extensions;

namespace dataobjectexception.dynamics365.registration
{
    public class Program
    {
        /// <summary>
        /// Use strategy pattern to create the Root<PluginAssembly>
        /// Prepare the strategy with the key
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            #region Use strategy pattern to create the Root<PluginAssembly>

            var gradationStrategy = new LevelStrategy();
            var nodeRoot = gradationStrategy.InstanciateStrategy(args.GenerateArguments());

            #endregion

            #region Prepare the strategy with the key

            var pluginAssemblyDictionary = new Dictionary<string, Root<PluginAssembly>>{ { "factoryDictionary", nodeRoot }};
            var rules = new List<IRule>
            {
                new ValidateRuleProcessingAssemblyCreationOnly(),
                new ValidateRuleProcessingAssemblyCreationWithChildren(),
                new ValidateRuleProcessingAssemblyUpdateOnly(),
                new ValidateRuleProcessingAssemblyUpdateWithChildren(),
                new ValidateRuleProcessingAssemblyDeleteOnly(),
                new ValidateRuleProcessingAssemblyDeleteWithChildren()
            };

            var resultValidation = new ResultValidation();
            for (var i = 0; i <= rules.Count - 1; i++)
            {
                resultValidation = rules[i].RuleProcessingObject(pluginAssemblyDictionary);
                if (resultValidation.ObjectValidated && resultValidation.KeyValueMessageValidation != null)
                    break;
            }
            IServiceContainer serviceContainer = ThreadSafeSingleton.GetInstance(ConfigurationConnectionString.GetConnectionStringInitialized("AuthType", "UserName", "Passwod", "Url"));

            #endregion

            #region Execute the factory with the key

            var factory = new FactoryManager();
            var factoryGenerated = factory.GenerateFactories(resultValidation, serviceContainer, pluginAssemblyDictionary);
            factoryGenerated.ProcessRegistration();

            #endregion
        }
    }
}
