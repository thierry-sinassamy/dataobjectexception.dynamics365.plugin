using dataobjectexception.dynamics365.crud.registration.Infrastructure;
using dataobjectexception.dynamics365.crud.registration.Inversion;
using dataobjectexception.dynamics365.crud.registration.NonBinaryTree;
using dataobjectexception.dynamics365.crud.registration.Result;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace dataobjectexception.dynamics365.crud.registration.Rule
{
    internal class ValidateRuleProcessingAssemblyDeleteWithChildren : IRule
    {
        public ResultValidation RuleProcessingObject(Dictionary<string, Root<PluginAssembly>> processingAssembly)
        {
            if (processingAssembly == null) return null;
            var typePluginAssembly = processingAssembly.FirstOrDefault().Value;
            if (typePluginAssembly.Children.GetType() == typeof(PluginAssemblyUpdate) || typePluginAssembly.Children.GetType() == typeof(PluginAssemblyCreate))
                return null;
            if (typePluginAssembly.Children.GetType() == typeof(PluginAssemblyDelete) || typePluginAssembly.Children.NextChild == null) //delete without children
                return null;

            var result = new ResultValidation
            {
                ObjectValidated = true,
                DisplayName = new StackTrace().GetFrame(0).GetMethod().Name,
                Parameter = EnumeratorProcessPluginAssembly.ProcessingAssemblyDeleteWithChildren,
                KeyValueMessageValidation = new Dictionary<int, string>() { [processingAssembly.Count] = ConstantesRules.RuleProcessingAssemblyDeleteWithChildren }
            };
            return result;
        }
    }
}
