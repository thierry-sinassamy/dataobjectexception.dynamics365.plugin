using dataobjectexception.dynamics365.plugin.Infrastructure.Inversion;
using Microsoft.Xrm.Sdk;

// ReSharper disable once IdentifierTypo
namespace dataobjectexception.dynamics365.plugin.Infrastructure.TriggerObject
{
    public interface IPluginRuleTrigger<T> where T : Entity
    {
        string Code { get; }
        string Message { get; }
        int Stage { get; }
        bool Synchronous { get; }

        IDynamics365Process<T> Process { get; }

        bool ValidateBusinessRule(IContext365<T> contextDynamics365);
    }
}
