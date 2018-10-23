using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Common.Models
{
    public class OrderModel
    {
        public decimal Total { get; set; }

        public int ProductsCount { get; set; }

        public bool IsProductInProduction { get; set; }

        public bool IsThereEnoughUnitsInStock { get; set; }
    }
}
