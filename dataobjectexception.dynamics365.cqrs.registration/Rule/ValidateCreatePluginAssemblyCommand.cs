using dataobjectexception.dynamics365.cqrs.registration.Infrastructure;
using dataobjectexception.dynamics365.cqrs.registration.Inversion;
using dataobjectexception.dynamics365.cqrs.registration.Result;
using System.Diagnostics;

namespace dataobjectexception.dynamics365.cqrs.registration.Rule
{
    internal class ValidateCreatePluginAssemblyCommand : IRule
    {
        public ResultValidation RuleProcessingCommand(EnumeratorCommand enumeratorCommand)
        {
            if (EnumeratorCommand.RegisterPluginAssemblyCommand != enumeratorCommand)
                return null;

            var result = new ResultValidation
            {
                ObjectValidated = true,
                DisplayName = new StackTrace().GetFrame(0).GetMethod().Name,
                Command = EnumeratorCommand.RegisterPluginAssemblyCommand,
                Tag = EnumTag.Tag_Register,
                ProcessValidated = true
            };
            return result;
        }
    }
}
