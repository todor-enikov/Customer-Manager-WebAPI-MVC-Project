using CustomerManager.Common.Models;
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
        IEnumerable<CustomerModel> GetAllIncludeChildEntity(string entity);

        CustomerByIdModel GetById(object id);

        IEnumerable<OrderModel> GetOrdersByCustomerId(object id);
    }
}
