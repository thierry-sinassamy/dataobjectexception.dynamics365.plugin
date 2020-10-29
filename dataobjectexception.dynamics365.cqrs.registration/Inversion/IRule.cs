using dataobjectexception.dynamics365.cqrs.registration.Infrastructure;
using dataobjectexception.dynamics365.cqrs.registration.Result;

namespace dataobjectexception.dynamics365.cqrs.registration.Inversion
{
    public interface IRule
    {
        ResultValidation RuleProcessingCommand(EnumeratorCommand enumeratorCommand);
    }
}
