﻿using dataobjectexception.dynamics365.crud.registration.Infrastructure;
using dataobjectexception.dynamics365.crud.registration.NonBinaryTree;
using System.Collections.Generic;

namespace dataobjectexception.dynamics365.crud.registration.Level
{
    public class LevelPluginType : GradationStrategy
    {
        public override Root<PluginAssembly> Level(List<string> list)
        {
            //1-Create the array
            GeneratorDynamics365Plugin[] generatorDynamics365Plugin = new GeneratorDynamics365Plugin[3];
            generatorDynamics365Plugin[0] = new GeneratorDynamics365PluginAssemblyRoot();
            generatorDynamics365Plugin[1] = new GeneratorDynamics365PluginAssembly();
            generatorDynamics365Plugin[2] = new GeneratorDynamics365PluginType();

            var pluginAssembly = generatorDynamics365Plugin[0].GenerateObject("PA", "PluginAssembly", EnumLevel.LevelRoot, "PluginAssembly as Root");
            var nodeRoot = new Root<PluginAssembly>(pluginAssembly, "PA", true);

            //2- "PluginAssemblyCreate" coming from parameters : TODO
            var _pluginAssembly = generatorDynamics365Plugin[1].GenerateObject("PAC", "PluginAssemblyCreate", EnumLevel.LevelPluginAssembly, "PluginAssemblyCreate as Child");
            nodeRoot.AddChild(_pluginAssembly, _pluginAssembly.Key, nodeRoot, EnumLevelCount.LevelPluginAssembly);

            //3- "PluginAssemblyCreate" coming from parameters : TODO
            var _pluginType = generatorDynamics365Plugin[2].GenerateObject("PTC", "PluginTypeCreate", EnumLevel.LevelPluginType, "PluginTypeCreate as Child");
            var childrenOfRoot = nodeRoot.Children;

            if (childrenOfRoot.Thing.GetType() == typeof(PluginAssemblyCreate) || childrenOfRoot.Thing.GetType() == typeof(PluginAssemblyUpdate) || childrenOfRoot.Thing.GetType() == typeof(PluginAssemblyDelete))
            {
                childrenOfRoot.AddChild(_pluginType, true, _pluginAssembly.Key, nodeRoot, EnumLevelCount.LevelPluginType);
            }
            
            return nodeRoot;
        }
    }
}