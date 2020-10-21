using dataobjectexception.dynamics365.crud.registration.NonBinaryTree;
using dataobjectexception.dynamics365.crud.registration.Infrastructure;

namespace dataobjectexception.dynamics365.registration
{
    public class Program
    {
        static void Main(string[] args)
        {
            GeneratorDynamics365Plugin[] generatorDynamics365Plugin = new GeneratorDynamics365Plugin[4]; //1-Create the array
            generatorDynamics365Plugin[0] = new GeneratorDynamics365PluginAssembly();
            generatorDynamics365Plugin[1] = new GeneratorDynamics365PluginType();
            generatorDynamics365Plugin[2] = new GeneratorDynamics365PluginStep();
            generatorDynamics365Plugin[3] = new GeneratorDynamics365PluginStepImage();

            var pluginAssembly = generatorDynamics365Plugin[0].GenerateObject("PA", "PluginAssembly", EnumLevel.LevelRoot, "PluginAssembly as Root");
            var nodeRoot = new Root<PluginAssembly>(pluginAssembly, "PA", true);

            var _pluginAssemblyCreate = new PluginAssemblyCreate("PAC", "PluginAssemblyCreate", EnumLevel.LevelPluginAssembly, "PluginAssemblyCreate as Child");
            nodeRoot.AddChild(_pluginAssemblyCreate, _pluginAssemblyCreate.Key, nodeRoot);

            var _pluginTypeCreate = new PluginTypeCreate("PTC", "PluginTypeCreate", EnumLevel.LevelPluginType, "PluginTypeCreate as Child");
            var childrenOfRoot = nodeRoot.Children;

            if(childrenOfRoot.Thing.GetType() == typeof(PluginAssemblyCreate))
            {
                childrenOfRoot.AddChild(_pluginTypeCreate, true, _pluginAssemblyCreate.Key, nodeRoot);
            }

        }
    }
}
