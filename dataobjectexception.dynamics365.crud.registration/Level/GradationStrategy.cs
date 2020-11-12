using dataobjectexception.dynamics365.crud.registration.NonBinaryTree;
using System.Collections.Generic;

namespace dataobjectexception.dynamics365.crud.registration.Level
{
    public abstract class GradationStrategy
    {
        public abstract Root<PluginAssembly> Level(List<string> list); //change to consolearguments
    }
}
