using Microsoft.Xrm.Sdk;

namespace dataobjectexception.dynamics365.crud.registration.Inversion
{
    public interface IDataContext
    {
        IOrganizationService DataContextEntities { get; }
    }
}
