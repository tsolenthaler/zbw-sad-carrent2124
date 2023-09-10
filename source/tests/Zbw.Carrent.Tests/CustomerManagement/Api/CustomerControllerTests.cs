namespace Zbw.Carrent.Tests.CustomerManagement.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FluentAssertions;
    using Moq;
    using Zbw.Carrent.CustomerManagement.Api;
    using Zbw.Carrent.CustomerManagement.Api.Models;
    using Zbw.Carrent.CustomerManagement.Domain;

    public class CustomerControllerTests
    {
        [Fact]
        public void Create_WhenNoRepository_ThenThrow()
        {
            Action act = () => new CustomerController(null);

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Post_Should_CreateCustomer()
        {
            // Arrange
            var customerid = Guid.NewGuid();
            var customerRepositoryMock = new Mock<ICustomerRepository>();
            var customerController = new CustomerController(customerRepositoryMock.Object);
            var customerRequest = new CustomerRequest(customerid, "123", "Test", "Test", "Test");

            // Act
            var result = customerController.Post(customerRequest);

            // Assert
            result.Should().BeEquivalentTo(new CustomerResponse(customerid, "123", "Test", null));
            //customerRepositoryMock.Verify(x => x.Add(It.Is<Customer>(c => c.Id == customerid && c.CustomerNr == "123" && c.Name == "Test")), Times.Once);
        }
    }


}
