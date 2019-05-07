using Microsoft.Extensions.Logging;
using DataProviders;
using Models;
using System.Collections.Generic;

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
            return _provider.GetPolicyKeys();
        }
    }
}
