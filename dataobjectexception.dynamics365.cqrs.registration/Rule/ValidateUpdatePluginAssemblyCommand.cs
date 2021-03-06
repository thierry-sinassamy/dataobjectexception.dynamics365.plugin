﻿using dataobjectexception.dynamics365.cqrs.registration.Infrastructure;
using dataobjectexception.dynamics365.cqrs.registration.Inversion;
using dataobjectexception.dynamics365.cqrs.registration.Result;
using System.Diagnostics;

namespace dataobjectexception.dynamics365.cqrs.registration.Rule
{
    internal class ValidateUpdatePluginAssemblyCommand : IRule
    {
        public ResultValidation RuleProcessingCommand(EnumeratorCommand enumeratorCommand)
        {
            if (EnumeratorCommand.AdjustPluginAssemblyCommand != enumeratorCommand)
                return null;

            var result = new ResultValidation
            {
                ObjectValidated = true,
                DisplayName = new StackTrace().GetFrame(0).GetMethod().Name,
                Command = EnumeratorCommand.AdjustPluginAssemblyCommand,               
                Tag = EnumTag.Tag_Adjust,
                ProcessValidated = true
            };
            return result;
        }
    }
}
