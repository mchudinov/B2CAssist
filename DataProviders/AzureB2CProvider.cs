using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Models;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using RestSharp;
using RestSharp.Authenticators;

namespace DataProviders
{
    public class AzureB2CProvider : BaseDataProvider, IDataProvider
    {
        public AzureB2CProvider(CredentialsAzure credentials, ILogger<AzureB2CProvider> logger = null) : base(logger)
        {
            var azureCredentials = SdkContext.AzureCredentialsFactory.FromServicePrincipal(credentials.ClientId, credentials.Secret, credentials.TenantId, AzureEnvironment.AzureGlobalCloud);

            //var restClient = RestClient
            //    .Configure()
            //    .WithEnvironment(AzureEnvironment.AzureGlobalCloud)
            //    .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
            //    .WithCredentials(azureCredentials)
            //    .Build();
            
            //_webSiteManagementClient = new WebSiteManagementClient(restClient)
            //{
            //    SubscriptionId = credentials.SubscriptionId
            //};
        }

        public List<PolicyKey> GetPolicyKeys()
        {
            throw new System.NotImplementedException();
        }

        private string GetAuthorizationCode(AzureCredentials credentials, string tenantName)
        {
            var client = new RestSharp.RestClient($"https://{tenantName}.b2clogin.com");
            client.Authenticator = new RestSharp.Authenticators.OAuth2AuthorizationRequestHeaderAuthenticator();

            var request = new RestRequest($"/{tenantName}.onmicrosoft.com/oauth2/v2.0/authorize", Method.GET);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Accept", "application/json");
            request.AddParameter("client_id", credentials.ClientId);
            request.AddParameter("response_type","code");
            request.AddParameter("redirect_uri","http://B2CAccess");
            request.AddParameter("response_mode","query");
            request.AddParameter("scope", "openid");
            request.AddParameter("p", "b2c_1_sign_up");
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            return content;
        }
    }
}
