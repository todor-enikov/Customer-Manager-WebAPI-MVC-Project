using CustomerManager.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CustomerManager.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api")]
    public class CustomersController : ApiController
    {
        private readonly ICustomerService customerService;

        public CustomersController(ICustomerService service)
        {
            if (service == null)
            {
                throw new NullReferenceException("Customer service should not be null!");
            }

            this.customerService = service;
        }

        [HttpGet]
        [Route("customers")]
        public IHttpActionResult Customers()
        {
            var includeEntity = "Orders";
            var allCustomers = this.customerService.GetAllIncludeChildEntity(includeEntity)
                                                   .ToList();
            if (allCustomers == null ||
                allCustomers.Count == 0)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            return Ok(allCustomers);
        }

        [HttpGet]
        [Route("customer/{id}")]
        public IHttpActionResult Customer(string id)
        {
            var customerById = this.customerService.GetById(id);
            if (customerById == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            return Ok(customerById);
        }

        [HttpGet]
        [Route("customer/{id}/orders")]
        public IHttpActionResult CustomerOrders(string id)
        {
            var customerOrders = this.customerService.GetOrdersByCustomerId(id)
                                                     .ToList();
            if (customerOrders == null ||
                customerOrders.Count == 0)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            return Ok(customerOrders);
        }
    }
}
