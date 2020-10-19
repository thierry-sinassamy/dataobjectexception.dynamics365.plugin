using dataobjectexception.dynamics365.crud.registration.Inversion;
using dataobjectexception.dynamics365.crud.registration.Message;
using dataobjectexception.dynamics365.crud.registration.Result;
using Microsoft.Xrm.Sdk.Client;
using dataobjectexception.dynamics365.crud.registration.Infrastructure;
using System.Diagnostics;
using System.Collections.Generic;

namespace dataobjectexception.dynamics365.crud.registration.Rule
{
    internal class ValidateRuleProcessingAssemblyUpdateOnly : IRule
    {
        [MethodMessage("Exception in the method [RuleProcessingObject] : related to : " + ConstantesRules.RuleProcessingAssemblyUpdateOnly)]
        public ResultValidation RuleProcessingObject(OrganizationServiceProxy Service, int Parameter)
        {
            if (!Parameter.Equals(EnumeratorProcessPluginAssembly.ProcessingAssemblyUpdateOnly)) return null;
            var result = new ResultValidation
            {
                ObjectValidated = true,
                DisplayName = new StackTrace().GetFrame(0).GetMethod().Name,
                Parameter = EnumeratorProcessPluginAssembly.ProcessingAssemblyUpdateOnly,
                KeyValueMessageValidation = new Dictionary<int, string>() { [Parameter] = ConstantesRules.RuleProcessingAssemblyUpdateOnly }
            };
            return result;
        }
    }
}
