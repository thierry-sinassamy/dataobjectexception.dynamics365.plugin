using dataobjectexception.dynamics365.cqrs.registration.Inversion;
using System;

namespace dataobjectexception.dynamics365.cqrs.registration.PluginAssembly
{
    public sealed class AdjustPluginAssemblyCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SolutionName { get; set; }

        //etc todo
        public AdjustPluginAssemblyCommand(Guid id, string name, string solutionName)
        {
            Id = id;
            Name = name;
            SolutionName = solutionName; //etc
        }
    }
}
