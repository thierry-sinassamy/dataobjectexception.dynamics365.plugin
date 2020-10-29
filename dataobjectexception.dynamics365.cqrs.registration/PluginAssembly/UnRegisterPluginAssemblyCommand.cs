using dataobjectexception.dynamics365.cqrs.registration.Inversion;
using System;
using System.Collections.Generic;
using System.Text;

namespace dataobjectexception.dynamics365.cqrs.registration.PluginAssembly
{
    public sealed class UnRegisterPluginAssemblyCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SolutionName { get; set; }

        //etc todo
        public UnRegisterPluginAssemblyCommand(Guid id, string name, string solutionName)
        {
            Id = id;
            Name = name;
            SolutionName = solutionName; //etc
        }
    }
}
