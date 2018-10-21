using CustomerManager.Common.Models;
using CustomerManager.Data.Models;
using CustomerManager.Data.Repositories;
using CustomerManager.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IEfGenericRepository<Customer> customerRepository;
        private readonly IEfGenericRepository<Order> orderRepository;

        public CustomerService(IEfGenericRepository<Customer> customerRepository, IEfGenericRepository<Order> orderRepository)
        {
            if (customerRepository == null)
            {
                throw new ArgumentException("The customer repository should not be null!");
            }

            if (orderRepository == null)
            {
                throw new ArgumentException("The order repository should not be null!");
            }

            this.customerRepository = customerRepository;
            this.orderRepository = orderRepository;
        }

        public IEnumerable<CustomerModel> GetAllIncludeChildEntity(string entity)
        {
            var allCustomers = this.customerRepository.AllIncludeChildEntity(entity);

            var resultAllCustomers = allCustomers.Select(c => new CustomerModel()
            {
                Id = c.CustomerID,
                ContractName = c.ContactName,
                OrdersCount = c.Orders.Count
            });

            return resultAllCustomers;
        }

        public Customer GetById(object id)
        {
            return this.customerRepository.GetById(id);
        }

        public IEnumerable<Order> GetOrdersByCustomerId(object id)
        {
            return this.orderRepository.All()
                                       .Where(x => x.CustomerID.Equals(id.ToString(), StringComparison.InvariantCultureIgnoreCase))
                                       .ToList();
        }
    }
}
