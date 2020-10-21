using dataobjectexception.dynamics365.crud.registration.Infrastructure;

namespace dataobjectexception.dynamics365.crud.registration.NonBinaryTree
{
    public class PluginAssembly : IPluginAssembly
    {
        public string Key { get ; set ; }
        public string Description { get; set; }
        public string Name { get; set; }
        public EnumLevel EnumeratorLevel { get; set; }

        public PluginAssembly(string key, string name, EnumLevel _enumLevel, string description)
        {
            Key = key;
            Name = name;
            EnumeratorLevel = _enumLevel;
            Description = description;
        }
    }

    public class PluginAssemblyCreate : PluginAssembly
    {
        public PluginAssemblyCreate(string key, string name, EnumLevel _enumLevel, string description) : base(key, name, _enumLevel, description)
        {
            Key = key;
            Name = name;
            EnumeratorLevel = _enumLevel;
            Description = description;
        }
    }

    public class PluginAssemblyUpdate : PluginAssembly
    {
        public PluginAssemblyUpdate(string key, string name, EnumLevel _enumLevel, string description) : base(key, name, _enumLevel, description)
        {
            Key = key;
            Name = name;
            EnumeratorLevel = _enumLevel;
            Description = description;
        }
    }

    public class PluginAssemblyDelete : PluginAssembly
    {
        public PluginAssemblyDelete(string key, string name, EnumLevel _enumLevel, string description) : base(key, name, _enumLevel, description)
        {
            Key = key;
            Name = name;
            EnumeratorLevel = _enumLevel;
            Description = description;
        }
    }
}
