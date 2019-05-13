using Microsoft.Extensions.Logging;
using DataProviders;
using Models;
using System.Collections.Generic;
using System;

namespace UseCases
{
    public class PolicyKeysCase : BaseUseCase, IPolicyKeysCase
    {
        protected IDataProvider _provider;

        public PolicyKeysCase(IDataProvider provider, ILogger<PolicyKeysCase> logger = null) : base(logger)
        {
            _provider = provider;
        }

        public List<PolicyKey> GetPolicyKeys()
        {
            var keys = _provider.GetPolicyKeys();
            foreach (var key in keys)
            {
                key.ExpirationDateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(key.ExpirationTimestamp);
                key.ExpirationSeconds = (long)(key.ExpirationDateTimeOffset - key.CreatedDateTimeOffset).TotalSeconds;
            }
            return keys;
        }
    }
}
