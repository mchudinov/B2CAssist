using Models;
using System.Collections.Generic;

namespace UseCases
{
    public interface IPolicyKeysCase
    {
        List<PolicyKey> GetPolicyKeys();
    }
}
