using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Models;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using RestSharp;
using RestSharp.Authenticators;
using System;

namespace DataProviders
{
    public class AzureB2CProvider : BaseDataProvider, IDataProvider
    {
        private static readonly RestSharp.RestClient _restClient = new RestSharp.RestClient();
        private static AzureADB2CTenant _azureADB2C;
        private const string AzureB2CAPIBaseUrl = "https://main.b2cadmin.ext.azure.com/api";

        public AzureB2CProvider(CredentialsAzure credentials, string discoveryEndpoint, ILogger<AzureB2CProvider> logger = null) : base(logger)
        {
            //var azureCredentials = SdkContext.AzureCredentialsFactory.FromServicePrincipal(credentials.ClientId, credentials.Secret, credentials.TenantId, AzureEnvironment.AzureGlobalCloud);

            _azureADB2C = new AzureADB2CTenant(discoveryEndpoint);
            //_restClient = new RestSharp.RestClient(_azureADB2C.);
            //_azureADB2C = new AzureADB2C(credentials.);

            var authorizationCode = GetAuthorizationCode(credentials, _azureADB2C);

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

        private static string GetAuthorizationCode(CredentialsAzure credentials, AzureADB2CTenant tenant)
        {
            var guid = Guid.NewGuid().ToString();
            var request = new RestRequest(tenant.AuthorizationEndpoint, Method.GET);
            //request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            //request.AddHeader("Accept", "application/json");
            request.AddParameter("client_id", credentials.ClientId);
            request.AddParameter("response_type","code");
            request.AddParameter("redirect_uri", credentials.RedirectURI);
            request.AddParameter("response_mode","query");
            request.AddParameter("scope", "openid");
            request.AddParameter("state", guid);
            //request.AddParameter("p", tenant.PolicySignIn);
            IRestResponse response = _restClient.Execute(request);
            var content = response.Content;
            return content;
        }
    }
}
