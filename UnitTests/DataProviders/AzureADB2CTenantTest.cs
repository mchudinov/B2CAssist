using DataProviders;
using Xunit;

namespace UnitTests.DataProviders
{
    public class AzureADB2CTenantTest
    {
        [Fact]
        public void TestAzureADB2CTenant()
        {
            var tenant = new AzureADB2CTenant("https://fmdclientsandbox.b2clogin.com/fmdclientsandbox.onmicrosoft.com/v2.0/.well-known/openid-configuration?p=B2C_1A_SignIn");
            Assert.True(string.Compare("B2C_1A_SignIn", tenant.PolicySignIn, true) == 0);
            Assert.True(string.Compare("fmdclientsandbox", tenant.TenantOnlyName, true) == 0);
            Assert.True(string.Compare("fmdclientsandbox.b2clogin.com", tenant.Domain, true) == 0);
            Assert.True(string.Compare("fmdclientsandbox.onmicrosoft.com", tenant.TenantFullName, true) == 0);
            Assert.True(string.Compare("https://fmdclientsandbox.b2clogin.com/fmdclientsandbox.onmicrosoft.com/oauth2/v2.0/authorize?p=b2c_1a_signin", tenant.AuthorizationEndpoint, true) == 0);
            Assert.True(string.Compare("https://fmdclientsandbox.b2clogin.com/fmdclientsandbox.onmicrosoft.com/oauth2/v2.0/token?p=b2c_1a_signin", tenant.TokenEndpoint, true) == 0);
        }
    }
}
