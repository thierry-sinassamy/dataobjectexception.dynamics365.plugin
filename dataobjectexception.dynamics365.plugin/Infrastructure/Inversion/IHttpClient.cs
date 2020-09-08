using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace dataobjectexception.dynamics365.plugin.Infrastructure.Inversion
{
    public interface IHttpClient
    {
        string ConnectionString { get; set; }
        string Password { get; set; }
        string UserName { get; set; }
        string Url { get; set; }
        public HttpClient OrganizationHttpClient { get; set; }
    }
}
