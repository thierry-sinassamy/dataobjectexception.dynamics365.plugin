﻿using dataobjectexception.dynamics365.crud.registration.Infrastructure;

namespace dataobjectexception.dynamics365.crud.registration.NonBinaryTree
{
    public class GeneratorDynamics365PluginAssemblyRoot : GeneratorDynamics365Plugin
    {
        public override PluginAssembly GenerateObject(string key, string name, EnumLevel enumLevel, string description)
        {
            return new PluginAssembly(key, name, enumLevel, description);
        }
    }
}
