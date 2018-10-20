using CustomerManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Services.Contracts
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAll();

        Customer GetById(object id);

        IEnumerable<Order> GetOrdersByCustomerId(object id);
    }
}
