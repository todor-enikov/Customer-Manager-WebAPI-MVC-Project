using CustomerManager.Common.Models;
using System.Collections.Generic;

namespace CustomerManager.Services.Contracts
{
    public interface ICustomerService
    {
        IEnumerable<CustomerModel> GetAllIncludeChildEntity(string entity);

        CustomerByIdModel GetById(object id);

        IEnumerable<OrderModel> GetOrdersByCustomerId(object id);
    }
}
