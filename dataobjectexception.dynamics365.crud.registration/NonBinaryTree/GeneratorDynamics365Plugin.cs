using dataobjectexception.dynamics365.crud.registration.Infrastructure;

namespace dataobjectexception.dynamics365.crud.registration.NonBinaryTree
{
    public abstract class GeneratorDynamics365Plugin
    {
        public abstract PluginAssembly GenerateObject(string key, string name, EnumLevel enumLevel, string description);
    }
}
