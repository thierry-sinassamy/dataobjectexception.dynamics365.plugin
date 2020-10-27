using dataobjectexception.dynamics365.crud.registration.Infrastructure;
using dataobjectexception.dynamics365.crud.registration.Inversion;
using dataobjectexception.dynamics365.crud.registration.Message;
using dataobjectexception.dynamics365.crud.registration.NonBinaryTree;
using dataobjectexception.dynamics365.crud.registration.Result;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace dataobjectexception.dynamics365.crud.registration.Rule
{
    internal class ValidateRuleProcessingAssemblyCreationWithChildren : IRule
    {
        [MethodMessage("Exception in the method [RuleProcessingObject] : related to : " + ConstantesRules.RuleProcessingAssemblyCreationWithChildren)]
        public ResultValidation RuleProcessingObject(Dictionary<string, Root<PluginAssembly>> processingAssembly)
        {
            if (processingAssembly == null) return null;
            var typePluginAssembly = processingAssembly.FirstOrDefault().Value;
            if (typePluginAssembly.Children.GetType() == typeof(PluginAssemblyUpdate) || typePluginAssembly.Children.GetType() == typeof(PluginAssemblyDelete))
                return null;
            if (typePluginAssembly.Children.GetType() == typeof(PluginAssemblyCreate) || typePluginAssembly.Children.NextChild == null) //create without children
                return null;

            var incrementedLevel = 0;
                if (typePluginAssembly.Children.LevelCount > 0) { incrementedLevel++; }
                if(typePluginAssembly.Children?.NextChild?.LevelCount > 0) { incrementedLevel++; }
                if(typePluginAssembly.Children?.NextChild?.NextChild?.LevelCount > 0) { incrementedLevel++; }
                if (typePluginAssembly.Children?.NextChild?.NextChild?.NextChild?.LevelCount > 0) { incrementedLevel++; }
           
            var result = new ResultValidation
            {
                ObjectValidated = true,
                DisplayName = new StackTrace().GetFrame(0).GetMethod().Name,
                Parameter = EnumeratorProcessPluginAssembly.ProcessingAssemblyCreationWithChildren,
                KeyValueMessageValidation = new Dictionary<int, string>() { [processingAssembly.Count] = ConstantesRules.RuleProcessingAssemblyCreationWithChildren },
                LevelCount = incrementedLevel
            };
            return result;
        }
    }
}
