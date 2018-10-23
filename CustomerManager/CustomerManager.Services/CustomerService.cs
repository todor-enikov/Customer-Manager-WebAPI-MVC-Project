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
                ContactName = c.ContactName,
                OrdersCount = c.Orders.Count
            });

            return resultAllCustomers;
        }

        public CustomerByIdModel GetById(object id)
        {
            var customerById = this.customerRepository.GetById(id);

            var resultCustomerById = new CustomerByIdModel()
            {
                ContactName = customerById.ContactName,
                ContactTitle = customerById.ContactTitle,
                CompanyName = customerById.CompanyName,
                City = customerById.City,
                Country = customerById.Country,
                Address = customerById.Address,
                Fax = customerById.Fax,
                Phone = customerById.Phone,
                PostalCode = customerById.PostalCode,
                Region = customerById.Region
            };

            return resultCustomerById;
        }

        public IEnumerable<OrderModel> GetOrdersByCustomerId(object id)
        {

            var ordersByCustomerId = this.orderRepository.All()
                                         .Where(x => x.CustomerID.Equals(id.ToString(), StringComparison.InvariantCultureIgnoreCase))
                                         .ToList();

            var resultOrdersByCustomerId = ordersByCustomerId.Select(o => new OrderModel()
            {
                ProductsCount = o.Order_Details.Count(),
                Total = o.Order_Details.Sum(t => (t.Quantity * t.UnitPrice) - (t.Quantity * t.UnitPrice * (decimal)t.Discount)),
                IsProductInProduction = o.Order_Details.Any(isInP => isInP.Product.Discontinued),
                IsThereEnoughUnitsInStock = o.Order_Details.Any(isUnit => isUnit.Product.UnitsInStock > isUnit.Product.UnitsOnOrder)
            }).ToList();

            return resultOrdersByCustomerId;
        }
    }
}
