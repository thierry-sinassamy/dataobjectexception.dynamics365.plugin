using dataobjectexception.dynamics365.crud.registration.Infrastructure;
using dataobjectexception.dynamics365.crud.registration.Inversion;
using dataobjectexception.dynamics365.crud.registration.Result;
using Microsoft.Xrm.Sdk.Client;
using System.Collections.Generic;
using System.Diagnostics;

namespace dataobjectexception.dynamics365.crud.registration.Rule
{
    internal class ValidateRuleProcessingAssemblyDeleteWithChildren : IRule
    {
        public ResultValidation RuleProcessingObject(OrganizationServiceProxy Service, int Parameter)
        {
            if (!Parameter.Equals(EnumeratorProcessPluginAssembly.ProcessingAssemblyDeleteWithChildren)) return null;
            var result = new ResultValidation
            {
                ObjectValidated = true,
                DisplayName = new StackTrace().GetFrame(0).GetMethod().Name,
                Parameter = EnumeratorProcessPluginAssembly.ProcessingAssemblyUpdateWithChildren,
                KeyValueMessageValidation = new Dictionary<int, string>() { [Parameter] = ConstantesRules.RuleProcessingAssemblyDeleteWithChildren }
            };
            return result;
        }
    }
}
