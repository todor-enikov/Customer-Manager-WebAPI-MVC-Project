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

namespace CustomerManager.Tests.MVC.Client.Controllers.CustomersControllerTests
{
    [TestFixture]
    public class CustomerById_Should
    {
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
