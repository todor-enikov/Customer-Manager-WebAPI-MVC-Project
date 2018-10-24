using CustomerManager.Rest.Call.Services.Contracts;
using System;
using System.Linq;
using System.Web.Mvc;

namespace CustomerManager.MVC.Client.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerRestCallService customersService;

        public CustomersController(ICustomerRestCallService service)
        {
            if (service == null)
            {
                throw new NullReferenceException("Customer service should not be null!");
            }

            this.customersService = service;
        }

        public ActionResult AllCustomers()
        {
            var allCustomers = this.customersService.GetAllCustomers();

            if (allCustomers == null)
            {
                return RedirectToAction("Error");
            }

            return View(allCustomers);
        }

        public ActionResult CustomerById(string id)
        {
            var customerById = this.customersService.GetCustomerById(id);
            var ordersByCustomerId = this.customersService.GetOrdersByCustomerId(id);

            if (customerById == null ||
                ordersByCustomerId == null)
            {
                return RedirectToAction("Error");
            }

            customerById.Orders = this.customersService.GetOrdersByCustomerId(id);

            return View(customerById);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(string search)
        {
            var customerByContactName = this.customersService
                                            .GetCustomerByContactName(search.Trim())
                                            .ToList();

            return View("AllCustomers", customerByContactName);
        }
    }
}