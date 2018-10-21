using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Common.Models
{
    public class CustomerModel
    {
        public string Id { get; set; }

        public string ContractName { get; set; }

        public int OrdersCount { get; set; }
    }
}
