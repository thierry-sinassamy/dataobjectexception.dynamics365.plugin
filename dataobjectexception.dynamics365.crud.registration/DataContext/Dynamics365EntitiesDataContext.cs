using dataobjectexception.dynamics365.crud.registration.Client;
using dataobjectexception.dynamics365.crud.registration.Inversion;
using Microsoft.Xrm.Sdk;

namespace dataobjectexception.dynamics365.crud.registration.DataContext
{
    public class Dynamics365EntitiesDataContext : IDataContext
    {
        public IOrganizationService DataContextEntities { get; set; }
        public Dynamics365EntitiesDataContext(string connectioString)
        {
            DataContextEntities = Dynamics365ServiceClient.GetOrganizationService(connectioString);
        }
    }
}
