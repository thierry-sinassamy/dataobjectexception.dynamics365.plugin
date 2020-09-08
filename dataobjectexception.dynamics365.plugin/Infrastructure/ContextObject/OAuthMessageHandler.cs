﻿using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.InteropServices;
using System.Security;

namespace dataobjectexception.dynamics365.plugin.Infrastructure.ContextObject
{
    public class OAuthMessageHandler : DelegatingHandler
    {
        private AuthenticationHeaderValue authHeader;

        public OAuthMessageHandler(string serviceUrl, string clientId, string redirectUrl, string username, string password,
            HttpMessageHandler innerHandler)
            : base(innerHandler)
        {
            // Obtain the Azure Active Directory Authentication Library (ADAL) authentication context.
            AuthenticationParameters ap = AuthenticationParameters.CreateFromResourceUrlAsync(
                new Uri(serviceUrl + "/api/data/")).Result;
            AuthenticationContext authContext = new AuthenticationContext(ap.Authority, false);
            //Note that an Azure AD access token has finite lifetime, default expiration is 60 minutes.
            Task<AuthenticationResult> authResult;
            if (username != string.Empty && password != string.Empty)
            {

                UserPasswordCredential cred = new UserPasswordCredential(username, password);
                authResult = authContext.AcquireTokenAsync(serviceUrl, clientId, cred);
            }
            else
            {
                //authResult = authContext.AcquireTokenAsync(serviceUrl, clientId, new Uri(redirectUrl), PromptBehavior.Auto);
            }

            //authHeader = new AuthenticationHeaderValue("Bearer", authResult.AccessToken);
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            request.Headers.Authorization = authHeader;
            return base.SendAsync(request, cancellationToken);
        }
    }
}
