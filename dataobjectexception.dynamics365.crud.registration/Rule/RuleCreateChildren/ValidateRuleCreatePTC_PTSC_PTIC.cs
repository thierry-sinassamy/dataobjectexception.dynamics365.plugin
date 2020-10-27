using dataobjectexception.dynamics365.crud.registration.Infrastructure;
using dataobjectexception.dynamics365.crud.registration.Inversion;
using dataobjectexception.dynamics365.crud.registration.NonBinaryTree;
using dataobjectexception.dynamics365.crud.registration.Result;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace dataobjectexception.dynamics365.crud.registration.Rule.RuleCreateChildren
{
    internal class ValidateRuleCreatePTC_PTSC_PTIC : IRuleCreateChildren
    {
        public ResultValidation RuleProcessingObjectChildren(Dictionary<string, Root<PluginAssembly>> processingAssembly)
        {
            if (processingAssembly == null) return null;
            var typePluginAssembly = processingAssembly.FirstOrDefault().Value;
            
            if (typePluginAssembly.Children.LevelCount > 0 && typePluginAssembly.Children?.NextChild?.LevelCount > 0 && typePluginAssembly.Children?.NextChild?.NextChild?.LevelCount > 0
                                && typePluginAssembly.Children?.NextChild?.NextChild?.NextChild?.LevelCount > 0) {

                var result = new ResultValidation
                {
                    ObjectValidated = true,
                    DisplayName = new StackTrace().GetFrame(0).GetMethod().Name,
                    Parameter = EnumeratorProcessPluginAssembly.ProcessingAssemblyCreationWithChildren,
                    KeyValueMessageValidation = new Dictionary<int, string>() { [processingAssembly.Count] = ConstantesRules.RuleProcessingAssemblyCreationWithChildren },                    
                    TagCreate = EnumTagCreation.Tag_PTC_PTSC_PTIC
                };
                return result;
            }
            return null;          
        }
    }
}
