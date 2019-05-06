using DataProviders;
using Models;
using System.Collections.Generic;

namespace UseCases
{
    public class PolicyKeysCase : IPolicyKeysCase
    {
        protected IDataProvider _provider;

        public PolicyKeysCase(IDataProvider provider)
        {
            IDataProvider _porvider = provider;
        }

        public List<PolicyKey> GetPolicyKeys()
        {
            return _provider.GetPolicyKeys();
        }
    }
}
