using Models;
using System.Collections.Generic;

namespace DataProviders
{
    public interface IAzureB2CProvider
    {
        List<PolicyKey> GetPolicyKeys();
    }
}
