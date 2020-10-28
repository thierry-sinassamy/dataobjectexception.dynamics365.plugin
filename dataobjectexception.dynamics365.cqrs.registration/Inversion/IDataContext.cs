using Microsoft.Xrm.Sdk;

namespace dataobjectexception.dynamics365.cqrs.registration.Inversion
{
    public interface IDataContext
    {
        IOrganizationService DataContextEntities { get; }
    }
}
