using dataobjectexception.dynamics365.crud.registration.Infrastructure;
using dataobjectexception.dynamics365.crud.registration.Inversion;
using dataobjectexception.dynamics365.crud.registration.NonBinaryTree;
using dataobjectexception.dynamics365.crud.registration.Result;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace dataobjectexception.dynamics365.crud.registration.Rule.RuleUpdateChildren
{
    internal class ValidateRuleUpdatePTU : IRuleUpdateChildren
    {
        public ResultValidation RuleProcessingObjectChildren(Dictionary<string, Root<PluginAssembly>> processingAssembly)
        {
            if (processingAssembly == null) return null;
            var typePluginAssembly = processingAssembly.FirstOrDefault().Value;

            if (typePluginAssembly.Children.LevelCount > 0 && typePluginAssembly.Children?.NextChild == null)
            {
                var result = new ResultValidation
                {
                    ObjectValidated = true,
                    DisplayName = new StackTrace().GetFrame(0).GetMethod().Name,
                    Parameter = EnumeratorProcessPluginAssembly.ProcessingAssemblyUpdateWithChildren,
                    KeyValueMessageValidation = new Dictionary<int, string>() { [processingAssembly.Count] = ConstantesRules.RuleProcessingAssemblyUpdateWithChildren },
                    TagUpdate = EnumTagUpdate.Tag_PTU
                };
                return result;
            }
            return null;
        }
    }
}
