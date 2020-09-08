using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Net.Http;

// ReSharper disable once IdentifierTypo
namespace dataobjectexception.dynamics365.plugin.Infrastructure.Inversion
{
    public interface IContextDynamics365Service
    {
        string ServiceName { get; set; }
        IDictionary<object, object> Items { get; set; }
        ITracingService TracingService { get; set; }
        IOrganizationServiceFactory OrganizationService { get; set; }
        IOrganizationService OrganizationServiceUser { get; set; }
        IServiceProvider ServiceProvider { get; set; }
        HttpClient OrganizationHttpClient { get; set; }
        Guid UserId { get; set; }
    }
}
