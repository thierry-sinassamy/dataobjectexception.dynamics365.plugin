using dataobjectexception.dynamics365.cqrs.registration.Infrastructure;
using dataobjectexception.dynamics365.cqrs.registration.Inversion;
using dataobjectexception.dynamics365.cqrs.registration.Result;
using System.Diagnostics;

namespace dataobjectexception.dynamics365.cqrs.registration.Rule
{
    internal class ValidateDeletePluginAssemblyCommand : IRule
    {
        public ResultValidation RuleProcessingCommand(EnumeratorCommand enumeratorCommand)
        {
            if (EnumeratorCommand.UnregisterPluginAssemblyCommand != enumeratorCommand)
                return null;

            var result = new ResultValidation
            {
                ObjectValidated = true,
                DisplayName = new StackTrace().GetFrame(0).GetMethod().Name,
                Command = EnumeratorCommand.UnregisterPluginAssemblyCommand,
                Tag = EnumTag.Tag_UnRegister,
                ProcessValidated = true
            };
            return result;
        }
    }
}
