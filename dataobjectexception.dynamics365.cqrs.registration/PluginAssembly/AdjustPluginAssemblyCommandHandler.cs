﻿using dataobjectexception.dynamics365.cqrs.registration.Inversion;
using dataobjectexception.dynamics365.cqrs.registration.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace dataobjectexception.dynamics365.cqrs.registration.PluginAssembly
{
    public sealed class AdjustPluginAssemblyCommandHandler : ICommandHandler<AdjustPluginAssemblyCommand>
    {
        public ResultValidation Handle(AdjustPluginAssemblyCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
