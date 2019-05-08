namespace DataProviders
{
    public class AzureADB2C
    {
        public AzureADB2C(string baseURL, string userFlow)
        {
            BaseURL = baseURL;
            UserFlow = userFlow;
            //MetadataEndpoint = metadataEndpoint;

        }

        public string AuthorizationEndpoint { get; private set; }
        public string TokenEndpoint { get; private set; }
        public string MetadataEndpoint { get; private set; }
        public string BaseURL { get; private set; }
        public string UserFlow { get; private set; }
    }
}
