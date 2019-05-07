using Models;
using System.Collections.Generic;

namespace DataProviders
{
    public interface IDataProvider
    {
        List<PolicyKey> GetPolicyKeys();
    }
}
