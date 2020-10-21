using dataobjectexception.dynamics365.crud.registration.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace dataobjectexception.dynamics365.crud.registration.NonBinaryTree
{
    public class PluginTypeStepCreate : PluginAssembly
    {
        public PluginTypeStepCreate(string key, string name, EnumLevel _enumLevel, string description) : base(key, name, _enumLevel, description)
        {
        }
    }

    public class PluginTypeStepUpdate : PluginAssembly
    {
        public PluginTypeStepUpdate(string key, string name, EnumLevel _enumLevel, string description) : base(key, name, _enumLevel, description)
        {
        }
    }

    public class PluginTypeStepDelete : PluginAssembly
    {
        public PluginTypeStepDelete(string key, string name, EnumLevel _enumLevel, string description) : base(key, name, _enumLevel, description)
        {
        }
    }
}
