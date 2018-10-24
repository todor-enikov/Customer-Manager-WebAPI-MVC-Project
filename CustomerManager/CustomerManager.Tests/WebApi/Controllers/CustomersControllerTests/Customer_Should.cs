using CustomerManager.Common.Models;
using CustomerManager.Services.Contracts;
using CustomerManager.WebAPI.Controllers;
using Moq;
using NUnit.Framework;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;

namespace CustomerManager.Tests.WebApi.Controllers.CustomersControllerTests
{
    [TestFixture]
    public class Customer_Should
    {
        [Test]
        public void NotBeNull()
        {
            // Arrange
            var service = new Mock<ICustomerService>();
            CustomersController controller = new CustomersController(service.Object);
            string customerId = "ALFKI";

            // Act
            IHttpActionResult result = controller.Customer(customerId) as IHttpActionResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void ReturnOkNegotiatedContentResult()
        {
            // Arrange
            string customerId = "ALFKI";
            var customerByIdModel = new CustomerByIdModel()
            {
                ContactName = "batka",
                City = "Burgas",
                Address = "test address",
                PostalCode = "8000"
            };
            var service = new Mock<ICustomerService>();
            service.Setup(x => x.GetById(customerId)).Returns(customerByIdModel);
            CustomersController controller = new CustomersController(service.Object);

            // Act
            var result = controller.Customer(customerId) as OkNegotiatedContentResult<CustomerByIdModel>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(customerByIdModel.ContactName, result.Content.ContactName);
            Assert.AreEqual(customerByIdModel.City, result.Content.City);
            Assert.AreEqual(customerByIdModel.Address, result.Content.Address);
            Assert.AreEqual(customerByIdModel.PostalCode, result.Content.PostalCode);
        }

        [Test]
        public void ReturnNoContentStatusCode()
        {
            // Arrange
            string customerId = "ALFKI";
            var service = new Mock<ICustomerService>();
            CustomersController controller = new CustomersController(service.Object);

            // Act
            var result = controller.Customer(customerId) as StatusCodeResult;

            // Assert
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }
    }
}
