using dataobjectexception.dynamics365.cqrs.registration.Infrastructure;
using dataobjectexception.dynamics365.cqrs.registration.Inversion;
using dataobjectexception.dynamics365.cqrs.registration.Result;
using System;

namespace dataobjectexception.dynamics365.cqrs.registration.Rule
{
    public class ValidateUpdatePluginAssemblyCommand : IRule
    {
        public ResultValidation RuleProcessingCommand(EnumeratorCommand enumeratorCommand)
        {
            throw new NotImplementedException();//todo
        }
    }
}
