using dataobjectexception.dynamics365.crud.registration.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace dataobjectexception.dynamics365.crud.registration.NonBinaryTree
{
    public class PluginTypeCreate : PluginAssembly
    {
        public PluginTypeCreate(string key, string name, EnumLevel _enumLevel, string description) : base(key, name, _enumLevel, description)
        {
        }
    }

    public class PluginTypeUpdate : PluginAssembly
    {
        public PluginTypeUpdate(string key, string name, EnumLevel _enumLevel, string description) : base(key, name, _enumLevel, description)
        {
        }
    }

    public class PluginTypeDelete : PluginAssembly
    {
        public PluginTypeDelete(string key, string name, EnumLevel _enumLevel, string description) : base(key, name, _enumLevel, description)
        {
        }
    }
}
