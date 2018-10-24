using CustomerManager.MVC.Client.Controllers;
using CustomerManager.Rest.Call.Services.Contracts;
using Moq;
using NUnit.Framework;
using System.Web.Mvc;
using TestStack.FluentMVCTesting;

namespace CustomerManager.Tests.MVC.Client.Controllers.CustomersControllerTests
{
    [TestFixture]
    public class Search_Should
    {
        [Test]
        public void NotBeNull()
        {
            // Arrange
            var service = new Mock<ICustomerRestCallService>();
            CustomersController controller = new CustomersController(service.Object);
            string searchTerm = "TestName";

            // Act
            ViewResult result = controller.Search(searchTerm) as ViewResult;

            // Assert

            Assert.IsNotNull(result);
        }

        [Test]
        public void ReturnViewWithExpectedModel_OnSearchAction()
        {
            // Arrange
            var service = new Mock<ICustomerRestCallService>();
            CustomersController controller = new CustomersController(service.Object);
            string searchTerm = "TestName";

            // Act & Arrange
            controller
                       .WithCallTo(c => c.Search(searchTerm))
                       .ShouldRenderView("AllCustomers");
        }
    }
}
