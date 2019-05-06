using System.Collections.Generic;
using Models;

namespace Web.Models
{
    public class IndexViewModel
    {
        public IndexViewModel(List<PolicyKey> keys)
        {
            PolicyKeys = keys;
        }

        public List<PolicyKey> PolicyKeys{ get; set; }
    }
}
