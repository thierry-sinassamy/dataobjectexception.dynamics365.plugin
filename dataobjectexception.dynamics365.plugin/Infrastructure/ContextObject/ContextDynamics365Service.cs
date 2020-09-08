using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using dataobjectexception.dynamics365.plugin.Infrastructure.Inversion;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;

// ReSharper disable once IdentifierTypo
namespace dataobjectexception.dynamics365.plugin.Infrastructure.ContextObject
{
    public class ContextDynamics365Service : IContextDynamics365Service
    {
        public string ServiceName { get; set; }
        public IDictionary<object, object> Items { get; set; }
        public ITracingService TracingService { get; set; }
        public IOrganizationServiceFactory OrganizationService { get; set; }
        public IOrganizationService OrganizationServiceUser { get; set; }
        public IServiceProvider ServiceProvider { get; set; }
        public HttpClient OrganizationHttpClient { get; set; }

        public Guid UserId { get; set; }

        public ContextDynamics365Service(string serviceName, IPluginExecutionContext pluginContext, IServiceProvider serviceProvider)
        {
            ServiceName = serviceName;
            Items = new Dictionary<object, object>();

            UserId = ((IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext))).UserId;
            TracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
            OrganizationService = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            OrganizationServiceUser = ((IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory)))
                .CreateOrganizationService(((IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext))).UserId);

            OrganizationHttpClient = GetHttpClient("connectionString", "clientId", "redirectUrl", "version");
        }

        public static HttpClient GetHttpClient(string connectionString, string clientId, string redirectUrl, string version)
        {
            var url = GetParameterValueFromConnectionString(connectionString, "Url");
            var username = GetParameterValueFromConnectionString(connectionString, "Username");
            var password = GetParameterValueFromConnectionString(connectionString, "Password");
            try
            {
                HttpMessageHandler messageHandler = new OAuthMessageHandler(url, clientId, redirectUrl, username, password,
                    new HttpClientHandler());

                var httpClient = new System.Net.Http.HttpClient(messageHandler)
                {
                    BaseAddress = new Uri($"{url}/api/data/{version}/"),

                    Timeout = new TimeSpan(0, 2, 0)  //2 minutes
                };

                return httpClient;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string GetParameterValueFromConnectionString(string connectionString, string parameter)
        {
            try
            {
                return connectionString.Split(';').FirstOrDefault(s => s.Trim().StartsWith(parameter))?.Split('=')[1];
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
