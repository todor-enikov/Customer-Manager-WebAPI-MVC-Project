using CustomerManager.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CustomerManager.WebAPI.Controllers
{
    [RoutePrefix("api")]
    public class CustomersController : ApiController
    {
        private readonly ICustomerService customerService;

        public CustomersController(ICustomerService service)
        {
            this.customerService = service;
        }

        [HttpGet]
        [Route("customers")]
        public IHttpActionResult Customers()
        {
            var allCustomers = this.customerService.GetAll()
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
