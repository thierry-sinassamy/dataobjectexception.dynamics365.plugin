using dataobjectexception.dynamics365.crud.registration.Infrastructure;

namespace dataobjectexception.dynamics365.crud.registration.NonBinaryTree
{
    public interface IPluginAssembly
    {
        public string Key { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public EnumLevel EnumeratorLevel { get; set; }
    }
}
