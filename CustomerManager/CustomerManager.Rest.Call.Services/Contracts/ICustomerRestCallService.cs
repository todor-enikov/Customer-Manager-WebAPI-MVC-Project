using CustomerManager.Common.Models;
using System.Collections.Generic;

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
