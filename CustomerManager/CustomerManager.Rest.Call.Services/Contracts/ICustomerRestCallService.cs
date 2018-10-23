using CustomerManager.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Rest.Call.Services.Contracts
{
    public interface ICustomerRestCallService
    {
        IEnumerable<CustomerModel> GetAllCustomers();

        CustomerByIdModel GetCustomerById(string id);

        List<OrderModel> GetOrdersByCustomerId(string id);

        IEnumerable<CustomerModel> GetCustomerByContactName(string contactName);
    }
}
