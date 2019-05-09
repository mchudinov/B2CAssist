using System;
using System.Web;

namespace DataProviders
{
    public class AzureADB2CTenant
    {
        public AzureADB2CTenant(string discoveryEndpoint)
        {
            DiscoveryEndpoint = discoveryEndpoint;
            var uri = new Uri(DiscoveryEndpoint);
            Domain = uri.Host;
            PolicySignIn = HttpUtility.ParseQueryString(uri.Query).Get("p");
            TenantOnlyName = GetFirstUriSegment(uri);
            TenantFullName = TenantOnlyName + ".onmicrosoft.com";
            AuthorizationEndpoint = $"https://{Domain}/{TenantFullName}/oauth2/v2.0/authorize?p={PolicySignIn}";
            TokenEndpoint = $"https://{Domain}/{TenantFullName}/oauth2/v2.0/token?p={PolicySignIn}";
        }

        public string AuthorizationEndpoint { get; private set; }
        public string TokenEndpoint { get; private set; }
        public string DiscoveryEndpoint { get; private set; }
        public string Domain { get; private set; }
        public string PolicySignIn { get; private set; }
        public string TenantOnlyName { get; private set; }
        public string TenantFullName { get; private set; }

        private static string GetFirstUriSegment(Uri uri)
        {
            var segment = uri.Segments[1].Split('.')[0];            
            return segment;
        }
    }
}
