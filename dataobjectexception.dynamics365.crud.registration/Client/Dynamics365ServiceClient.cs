using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;

namespace dataobjectexception.dynamics365.crud.registration.Client
{
    public static class Dynamics365ServiceClient
    {
        public static IOrganizationService GetOrganizationService(string connectionstring)
        {
            var connection = new CrmServiceClient(connectionstring);
            connection.OrganizationServiceProxy.Timeout = new TimeSpan(0, 30, 0);
            var service = connection.OrganizationWebProxyClient ?? connection.OrganizationServiceProxy as IOrganizationService;
            return service;
        }
    }
}
