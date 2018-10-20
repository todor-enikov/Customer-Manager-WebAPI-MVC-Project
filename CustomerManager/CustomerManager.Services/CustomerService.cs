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

            this.customerRepository = customerRepository;
            this.orderRepository = orderRepository;
        }

        public IEnumerable<Customer> GetAll()
        {
            return this.customerRepository.All();
        }

        public Customer GetById(object id)
        {
            return this.customerRepository.GetById(id);
        }

        public IEnumerable<Order> GetOrdersByCustomerId(object id)
        {
            return this.orderRepository.All()
                                       .Where(x => x.CustomerID.Equals(id.ToString(), StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
