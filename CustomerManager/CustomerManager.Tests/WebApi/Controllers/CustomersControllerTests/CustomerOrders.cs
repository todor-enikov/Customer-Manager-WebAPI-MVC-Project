using CustomerManager.Common.Models;
using CustomerManager.Services.Contracts;
using CustomerManager.WebAPI.Controllers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace CustomerManager.Tests.WebApi.Controllers.CustomersControllerTests
{
    [TestFixture]
    public class CustomerOrders
    {
        [Test]
        public void NotBeNull()
        {
            // Arrange
            var service = new Mock<ICustomerService>();
            CustomersController controller = new CustomersController(service.Object);
            string customerId = "ALFKI";

            // Act
            IHttpActionResult result = controller.CustomerOrders(customerId) as IHttpActionResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void ReturnOkNegotiatedContentResult()
        {
            // Arrange
            string customerId = "ALFKI";
            var ordersByCustomerId = new List<OrderModel>()
            {
                new OrderModel()
                {
                    ProductsCount = 50,
                    Total = 300,
                    IsProductInProduction = true,
                    IsThereEnoughUnitsInStock = false,
                },
                new OrderModel()
                {
                    ProductsCount = 30,
                    Total = 20,
                    IsProductInProduction = false,
                    IsThereEnoughUnitsInStock = true,
                }
            };
            var service = new Mock<ICustomerService>();
            service.Setup(x => x.GetOrdersByCustomerId(customerId)).Returns(ordersByCustomerId);
            CustomersController controller = new CustomersController(service.Object);

            // Act
            var result = controller.CustomerOrders(customerId) as OkNegotiatedContentResult<List<OrderModel>>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(ordersByCustomerId[0].IsProductInProduction, result.Content[0].IsProductInProduction);
            Assert.AreEqual(ordersByCustomerId[0].IsThereEnoughUnitsInStock, result.Content[0].IsThereEnoughUnitsInStock);
            Assert.AreEqual(ordersByCustomerId[0].ProductsCount, result.Content[0].ProductsCount);
            Assert.AreEqual(ordersByCustomerId[0].Total, result.Content[0].Total);
            Assert.AreEqual(ordersByCustomerId[1].IsProductInProduction, result.Content[1].IsProductInProduction);
            Assert.AreEqual(ordersByCustomerId[1].IsThereEnoughUnitsInStock, result.Content[1].IsThereEnoughUnitsInStock);
            Assert.AreEqual(ordersByCustomerId[1].ProductsCount, result.Content[1].ProductsCount);
            Assert.AreEqual(ordersByCustomerId[1].Total, result.Content[1].Total);
        }

        [Test]
        public void ReturnNoContentStatusCode()
        {
            // Arrange
            string customerId = "ALFKI";
            var service = new Mock<ICustomerService>();
            CustomersController controller = new CustomersController(service.Object);

            // Act
            var result = controller.CustomerOrders(customerId) as StatusCodeResult;

            // Assert
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }
    }
}
