using Microsoft.Xrm.Sdk;

// ReSharper disable once IdentifierTypo
namespace dataobjectexception.dynamics365.plugin.Infrastructure.Inversion
{
    public interface IDynamics365Process<T> where T : Entity
    {
        bool Execute(IContext365<T> entityDynamics365);
    }
}
