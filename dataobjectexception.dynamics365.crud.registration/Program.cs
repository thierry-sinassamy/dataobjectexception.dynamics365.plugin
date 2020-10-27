using dataobjectexception.dynamics365.crud.registration.NonBinaryTree;
using dataobjectexception.dynamics365.crud.registration.Infrastructure;
using System.Collections.Generic;
using dataobjectexception.dynamics365.crud.registration.Inversion;
using dataobjectexception.dynamics365.crud.registration.Rule;
using dataobjectexception.dynamics365.crud.registration.Result;
using dataobjectexception.dynamics365.crud.registration.Manager;
using System.ComponentModel.Design;
using dataobjectexception.dynamics365.crud.registration.Singleton;

namespace dataobjectexception.dynamics365.registration
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region Generate the pattern

            //use strategy pattern to create the Root<PluginAssembly>

            GeneratorDynamics365Plugin[] generatorDynamics365Plugin = new GeneratorDynamics365Plugin[5]; //1-Create the array
            generatorDynamics365Plugin[0] = new GeneratorDynamics365PluginAssemblyRoot();
            generatorDynamics365Plugin[1] = new GeneratorDynamics365PluginAssembly();
            generatorDynamics365Plugin[2] = new GeneratorDynamics365PluginType();
            generatorDynamics365Plugin[3] = new GeneratorDynamics365PluginStep();
            generatorDynamics365Plugin[4] = new GeneratorDynamics365PluginStepImage();

            var pluginAssembly = generatorDynamics365Plugin[0].GenerateObject("PA", "PluginAssembly", EnumLevel.LevelRoot, "PluginAssembly as Root");            
            var nodeRoot = new Root<PluginAssembly>(pluginAssembly, "PA", true);

            var _pluginAssemblyCreate = generatorDynamics365Plugin[1].GenerateObject("PAC", "PluginAssemblyCreate", EnumLevel.LevelPluginAssembly, "PluginAssemblyCreate as Child");
            nodeRoot.AddChild(_pluginAssemblyCreate, _pluginAssemblyCreate.Key, nodeRoot, EnumLevelCount.LevelPluginAssembly);
            var childrenOfRoot = nodeRoot.Children;

            var _pluginTypeCreate = generatorDynamics365Plugin[2].GenerateObject("PTC", "PluginTypeCreate", EnumLevel.LevelPluginType, "PluginTypeCreate as Child");           

            if(childrenOfRoot.Thing.GetType() == typeof(PluginAssemblyCreate))
            {
                childrenOfRoot.AddChild(_pluginTypeCreate, true, _pluginAssemblyCreate.Key, nodeRoot, EnumLevelCount.LevelPluginType);

                var _pluginTypeStepCreate = generatorDynamics365Plugin[3].GenerateObject("PTSC", "PluginTypeStepCreate", EnumLevel.LevelPluginStep, "PluginTypeStepCreate as Child");

                if(childrenOfRoot.NextChild.Thing.GetType() == typeof(PluginTypeCreate))
                {
                    childrenOfRoot.NextChild.AddChild(_pluginTypeStepCreate, true, _pluginTypeCreate.Key, nodeRoot, EnumLevelCount.LevelPluginStep);

                    var _pluginTypeStepImage = generatorDynamics365Plugin[4].GenerateObject("PTSIC", "PluginTypeStepImageCreate", EnumLevel.LevelPluginStepImage, "PluginTypeStepImageCreate as Child");

                    if(childrenOfRoot.NextChild.NextChild.Thing.GetType() == typeof(PluginTypeStepCreate))
                    {
                        childrenOfRoot.NextChild.NextChild.AddChild(_pluginTypeStepImage, true, _pluginTypeStepCreate.Key, nodeRoot, EnumLevelCount.LevelPluginStepImage);
                    }
                }
            }

            #endregion

            //Prepare the strategy with the key
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
                        
            var factory = new FactoryManager();
            var factoryGenerated = factory.GenerateFactories(resultValidation, serviceContainer, pluginAssemblyDictionary);
            factoryGenerated.ProcessRegistration();
        }
    }
}
