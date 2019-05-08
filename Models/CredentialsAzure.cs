﻿namespace Models
{
    public class CredentialsAzure
    {
        public string TenantName { get; set; }
        public string TenantId { get; set; }
        public string ClientId { get; set; }
        public string Secret { get; set; }
        public string SubscriptionId { get; set; }
        public string RedirectURI { get; set; }
    }
}
