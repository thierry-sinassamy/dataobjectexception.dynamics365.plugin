using System.Collections.Generic;
using System.ComponentModel.Design;

// ReSharper disable once IdentifierTypo
namespace dataobjectexception.dynamics365.plugin.Infrastructure.Inversion
{
    public interface IContextDynamics365Process
    {
        string ProcessName { get; set; }
        IDictionary<object, object> Items { get; set; }
        IServiceContainer ServiceContainer { get; set; }
    }
}
