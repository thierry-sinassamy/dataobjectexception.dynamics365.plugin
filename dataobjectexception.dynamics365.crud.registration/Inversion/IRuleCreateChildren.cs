using dataobjectexception.dynamics365.crud.registration.NonBinaryTree;
using dataobjectexception.dynamics365.crud.registration.Result;
using System.Collections.Generic;

namespace dataobjectexception.dynamics365.crud.registration.Inversion
{
    public interface IRuleCreateChildren
    {
        ResultValidation RuleProcessingObjectChildren(Dictionary<string, Root<PluginAssembly>> processingAssembly);
    }
}
