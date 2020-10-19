using dataobjectexception.dynamics365.crud.registration.Infrastructure;
using dataobjectexception.dynamics365.crud.registration.Inversion;
using dataobjectexception.dynamics365.crud.registration.Message;
using dataobjectexception.dynamics365.crud.registration.Result;
using Microsoft.Xrm.Sdk.Client;
using System.Collections.Generic;
using System.Diagnostics;

namespace dataobjectexception.dynamics365.crud.registration.Rule
{
    internal class ValidateRuleProcessingAssemblyUpdateWithChildren : IRule
    {
        [MethodMessage("Exception in the method [RuleProcessingObject] : related to : " + ConstantesRules.RuleProcessingAssemblyUpdateWithChildren)]
        public ResultValidation RuleProcessingObject(OrganizationServiceProxy Service, int Parameter)
        {
            if (!Parameter.Equals(EnumeratorProcessPluginAssembly.ProcessingAssemblyUpdateWithChildren)) return null;
            var result = new ResultValidation
            {
                ObjectValidated = true,
                DisplayName = new StackTrace().GetFrame(0).GetMethod().Name,
                Parameter = EnumeratorProcessPluginAssembly.ProcessingAssemblyUpdateWithChildren,
                KeyValueMessageValidation = new Dictionary<int, string>() { [Parameter] = ConstantesRules.RuleProcessingAssemblyUpdateWithChildren }
            };
            return result;
        }
    }
}
