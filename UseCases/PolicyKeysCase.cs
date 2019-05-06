using DataProviders;
using Models;
using System;
using System.Collections.Generic;

namespace UseCases
{
    public class PolicyKeysCase : IPolicyKeysCase
    {
        protected IAzureB2CProvider _provider;

        public PolicyKeysCase(IAzureB2CProvider provider)
        {
            IAzureB2CProvider _porvider = provider;
        }

        public List<PolicyKey> GetPolicyKeys()
        {
            return _provider.GetPolicyKeys();
        }
    }
}
