using Models;
using DataProviders;
using Xunit;

namespace UnitTests
{
    public class AzureB2CProviderTest
    {
        private static readonly CredentialsAzure credentials = new CredentialsAzure
        {
            TenantId = "17f8330f-a4d6-4ef9-b661-8b2aefc4e1ca",
            ClientId = "f29c5b16-299a-4016-af82-75cb67e47495",
            Secret = "mQnVjMp04R4UJb+wi2NhRKxhRw9pzF4Z081tPPyznPQ=",
            SubscriptionId = "957e8e87-4448-46ba-bc0f-5406c18fcc5a"
        };

        [Fact]
        public void TestGetPolicyKeys()
        {
            var provider = new AzureB2CProvider(credentials);
            var temp = provider.GetPolicyKeys();
            Assert.True(temp.Count > 0);
        }
    }
}
