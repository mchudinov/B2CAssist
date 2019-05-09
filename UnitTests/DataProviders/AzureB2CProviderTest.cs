using Models;
using DataProviders;
using Xunit;

namespace UnitTests.DataProviders
{
    public class AzureB2CProviderTest
    {
        private static readonly CredentialsAzure credentials = new CredentialsAzure
        {
            TenantId = "2263fb1b-1249-4245-a174-cb9d518d7ce3",
            ClientId = "7b0bebfc-7d9a-4d63-83ee-5afef5f28c05",
            Secret = "{~rj59P3k5>7torn4dR&77{8",
            SubscriptionId = "80ae895c-6440-4748-a188-ea60b1ab5be7",
            RedirectURI = "https://B2CAssist"
        };

        [Fact]
        public void TestGetPolicyKeys()
        {
            var provider = new AzureB2CProvider(credentials, "https://fmdclientsandbox.b2clogin.com/fmdclientsandbox.onmicrosoft.com/v2.0/.well-known/openid-configuration?p=B2C_1A_SignIn");
            var temp = provider.GetPolicyKeys();
            Assert.True(temp.Count > 0);
        }

        //[Fact]
        //public void TestAzureB2CProvider()
        //{
        //    var provider = new AzureB2CProvider(credentials, "https://fmdclientsandbox.b2clogin.com/fmdclientsandbox.onmicrosoft.com/v2.0/.well-known/openid-configuration?p=B2C_1A_SignIn");
        //    var temp = provider.GetPolicyKeys();
        //    Assert.True(temp.Count > 0);
        //}
    }
}
