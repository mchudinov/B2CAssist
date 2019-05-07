using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Models;

namespace DataProviders
{
    public class AzureB2CProvider : BaseDataProvider, IDataProvider
    {
        public AzureB2CProvider(CredentialsAzure credentials, ILogger<AzureB2CProvider> logger = null) : base(logger)
        {
            var azureCredentials = SdkContext.AzureCredentialsFactory.FromServicePrincipal(credentials.ClientId, credentials.Secret, credentials.TenantId, AzureEnvironment.AzureGlobalCloud);

            var restClient = RestClient
                .Configure()
                .WithEnvironment(AzureEnvironment.AzureGlobalCloud)
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                .WithCredentials(azureCredentials)
                .Build();

            //_webSiteManagementClient = new WebSiteManagementClient(restClient)
            //{
            //    SubscriptionId = credentials.SubscriptionId
            //};
        }

        public List<PolicyKey> GetPolicyKeys()
        {
            throw new System.NotImplementedException();
        }
    }
}
