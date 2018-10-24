using CustomerManager.Common.Models;
using CustomerManager.Services.Contracts;
using CustomerManager.WebAPI.Controllers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;

namespace CustomerManager.Tests.WebApi.Controllers.CustomersControllerTests
{
    [TestFixture]
    public class Customers_Should
    {
        [Test]
        public void ThrowNullReferenceException_WhenICustomerRestCallService_IsNull()
        {
            // Arrange
            ICustomerService service = null;

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => new CustomersController(service));
        }

        [Test]
        public void ThrowNullReferenceException_WithExpectedMessage()
        {
            // Arrange
            ICustomerService service = null;

            // Act
            var expectedMessage = Assert.Throws<NullReferenceException>(() => new CustomersController(service));

            // Assert
            Assert.IsTrue(expectedMessage.Message.Contains("should not be null"));
        }

        [Test]
        public void NotBeNull()
        {
            // Arrange
            var service = new Mock<ICustomerService>();
            CustomersController controller = new CustomersController(service.Object);

            // Act
            IHttpActionResult result = controller.Customers() as IHttpActionResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void ReturnOkNegotiatedContentResult()
        {
            // Arrange
            string entity = "Orders";
            var allCustomers = new List<CustomerModel>()
            {
                new CustomerModel()
                {
                    ContactName = "batka",
                    OrdersCount = 5,
                },
                 new CustomerModel()
                {
                    ContactName = "golqma batka",
                    OrdersCount = 15,
                }
            };
            var service = new Mock<ICustomerService>();
            service.Setup(x => x.GetAllIncludeChildEntity(entity)).Returns(allCustomers);
            CustomersController controller = new CustomersController(service.Object);

            // Act
            var result = controller.Customers() as OkNegotiatedContentResult<List<CustomerModel>>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(allCustomers[0].OrdersCount, result.Content[0].OrdersCount);
            Assert.AreEqual(allCustomers[0].ContactName, result.Content[0].ContactName);
            Assert.AreEqual(allCustomers[1].OrdersCount, result.Content[1].OrdersCount);
            Assert.AreEqual(allCustomers[1].ContactName, result.Content[1].ContactName);
        }

        [Test]
        public void ReturnNoContentStatusCode()
        {
            // Arrange
            var service = new Mock<ICustomerService>();
            CustomersController controller = new CustomersController(service.Object);

            // Act
            var result = controller.Customers() as StatusCodeResult;

            // Assert
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }
    }
}
