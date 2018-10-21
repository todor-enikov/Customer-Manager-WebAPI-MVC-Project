using CustomerManager.Rest.Call.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerManager.MVC.Client.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerRestCallService customersService;

        public CustomersController(ICustomerRestCallService service)
        {
            this.customersService = service;
        }

        public ActionResult AllCustomers()
        {
            var allCustomers = this.customersService.GetAllCustomers();
            return View(allCustomers);
        }

        public ActionResult CustomerById(string id)
        {
            var customerById = this.customersService.GetCustomerById(id);
            return View(customerById);
        }
    }
}