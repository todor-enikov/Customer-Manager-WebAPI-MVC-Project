using CustomerManager.Common.Models;
using CustomerManager.MVC.Client.Controllers;
using CustomerManager.Rest.Call.Services.Contracts;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Web.Mvc;
using TestStack.FluentMVCTesting;

namespace CustomerManager.Tests.MVC.Client.Controllers.CustomersControllerTests
{
    [TestFixture]
    public class CustomerById_Should
    {
        [Test]
        public void BeNull()
        {
            // Arrange
            var service = new Mock<ICustomerRestCallService>();
            CustomersController controller = new CustomersController(service.Object);
            string customerId = "ALFKI";

            // Act
            ViewResult result = controller.CustomerById(customerId) as ViewResult;

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void NotBeNull()
        {
            // Arrange
            string customerId = "ALFKI";
            var ordersByCustomerId = new List<OrderModel>()
            {
               new OrderModel()
               {
                   ProductsCount = 5,
                   Total = 300,
                   IsProductInProduction = true,
                   IsThereEnoughUnitsInStock = false
               },
               new OrderModel()
               {
                   ProductsCount = 2,
                   Total = 30,
                   IsProductInProduction = false,
                   IsThereEnoughUnitsInStock = true
               },
            };

            var customerById = new CustomerByIdModel()
            {
                Address = "test address",
                City = "test city",
                ContactName = "test contact name",
                ContactTitle = "test contact title",
                CompanyName = "test company name",
                Country = "test country",
                Fax = "test fax",
                Phone = "test phone",
                PostalCode = "test postal",
                Region = "test region",
                Orders = ordersByCustomerId
            };

            var service = new Mock<ICustomerRestCallService>();
            service.Setup(x => x.GetCustomerById(customerId)).Returns(customerById);
            service.Setup(x => x.GetOrdersByCustomerId(customerId)).Returns(ordersByCustomerId);
            CustomersController controller = new CustomersController(service.Object);

            // Act
            ViewResult result = controller.CustomerById(customerId) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void ReturnViewWithExpectedModel_OnCustomerByIdAction()
        {
            // Arrange
            string customerId = "ALFKI";
            var ordersByCustomerId = new List<OrderModel>()
            {
               new OrderModel()
               {
                   ProductsCount = 5,
                   Total = 300,
                   IsProductInProduction = true,
                   IsThereEnoughUnitsInStock = false
               },
               new OrderModel()
               {
                   ProductsCount = 2,
                   Total = 30,
                   IsProductInProduction = false,
                   IsThereEnoughUnitsInStock = true
               },
            };

            var customerById = new CustomerByIdModel()
            {
                Address = "test address",
                City = "test city",
                ContactName = "test contact name",
                ContactTitle = "test contact title",
                CompanyName = "test company name",
                Country = "test country",
                Fax = "test fax",
                Phone = "test phone",
                PostalCode = "test postal",
                Region = "test region",
                Orders = ordersByCustomerId
            };

            var service = new Mock<ICustomerRestCallService>();
            service.Setup(x => x.GetCustomerById(customerId)).Returns(customerById);
            service.Setup(x => x.GetOrdersByCustomerId(customerId)).Returns(ordersByCustomerId);
            CustomersController controller = new CustomersController(service.Object);

            // Act & Arrange
            controller
                       .WithCallTo(c => c.CustomerById(customerId))
                       .ShouldRenderDefaultView();
        }

        [Test]
        public void RedirectToRoute_OnCustomerByIdAction_IfGetOrdersByCustomerId_IsNotSet()
        {
            // Arrange
            string customerId = "ALFKI";
            var service = new Mock<ICustomerRestCallService>();
            service.Setup(x => x.GetCustomerById(customerId)).Verifiable();
            CustomersController controller = new CustomersController(service.Object);

            // Act & Arrange
            controller
                       .WithCallTo(c => c.CustomerById(customerId))
                       .ShouldRedirectToRoute("");
        }

        [Test]
        public void RedirectToRoute_OnCustomerByIdAction_IfGetCustomerById_IsNotSet()
        {
            // Arrange
            string customerId = "ALFKI";
            var service = new Mock<ICustomerRestCallService>();
            service.Setup(x => x.GetOrdersByCustomerId(customerId)).Verifiable();
            CustomersController controller = new CustomersController(service.Object);

            // Act & Arrange
            controller
                       .WithCallTo(c => c.CustomerById(customerId))
                       .ShouldRedirectToRoute("");
        }
    }
}
