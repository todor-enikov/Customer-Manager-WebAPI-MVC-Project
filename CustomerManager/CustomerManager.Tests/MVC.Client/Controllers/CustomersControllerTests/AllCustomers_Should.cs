using CustomerManager.MVC.Client.Controllers;
using CustomerManager.Rest.Call.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CustomerManager.Tests.MVC.Client.Controllers.Tests
{
    [TestFixture]
    public class AllCustomers_Should
    {
        [Test]
        public void ThrowNullReferenceException_WhenICustomerRestCallService_IsNull()
        {
            // Arrange
            ICustomerRestCallService service = null;

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => new CustomersController(service));
        }

        [Test]
        public void ThrowNullReferenceException_WithExpectedMessage()
        {
            // Arrange
            ICustomerRestCallService service = null;

            // Act
            var expectedMessage = Assert.Throws<NullReferenceException>(() => new CustomersController(service));

            // Assert
            Assert.IsTrue(expectedMessage.Message.Contains("should not be null"));
        }

        [Test]
        public void NotBeNull()
        {
            // Arrange
            var service = new Mock<ICustomerRestCallService>();
            CustomersController controller = new CustomersController(service.Object);

            // Act
            ViewResult result = controller.AllCustomers() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
