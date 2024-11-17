using AutoFixture;
using GlowingSystem.Core.DataTransferObjects;
using GlowingSystem.Core.ErrorModels;
using GlowingSystem.DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net;
using System.Net.Mime;
using System.Text;

namespace GlowingSystem.IntegrationTests
{
    public class CustomersTests : BaseInitialization, IClassFixture<WebApplicationFactory<Program>>
    {
        public CustomersTests(WebApplicationFactory<Program> app) : base(app) { }
        public async Task<Guid> CreateTestCustomerEntityAsync()
        {
            var testCustomer = _fixture.Build<CustomerEntity>()
                .Without(c => c.Id)
                .With(c => c.CustomerName)
                .Create();

            _dbContext.Customers.Add(testCustomer);
            await _dbContext.SaveChangesAsync();
            _dbContext.ChangeTracker.Clear();

            return testCustomer.Id;
        }

        [Fact]
        public async Task GetCustomers_ShouldReturnOKStatus()
        {
            //Arrange
            await CreateTestCustomerEntityAsync();
            await CreateTestCustomerEntityAsync();
            await CreateTestCustomerEntityAsync();

            //Act
            var response = await _client.GetAsync("api/customers");

            var content = await response.Content.ReadAsStringAsync();

            var customersResponse = JsonConvert.DeserializeObject<List<CustomerDto>>(content);

            var customer = customersResponse?.First();

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(customersResponse);
            Assert.IsType<List<CustomerDto>>(customersResponse);

            Assert.Equal(3, customersResponse.Count);
            Assert.All(customersResponse, customer =>
            {
                Assert.NotNull(customer?.Id);
                Assert.NotEmpty(customer.Id.ToString());
                Assert.NotNull(customer.CustomerName);
                Assert.NotEmpty(customer.CustomerName);
            });
        }

        [Fact]
        public async Task GetCustomerById_ShouldReturnOkStatus()
        {
            //Arrange
            Guid customerId = await CreateTestCustomerEntityAsync();

            //Act
            var response = await _client.GetAsync($"api/customers/{customerId}");

            var content = await response.Content.ReadAsStringAsync();
            var customerResponse = JsonConvert.DeserializeObject<CustomerDto>(content);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.IsType<CustomerDto>(customerResponse);
            Assert.Equal(customerId, customerResponse.Id);
            Assert.NotNull(customerResponse.CustomerName);
            Assert.NotEmpty(customerResponse.CustomerName);
        }

        [Fact]
        public async Task CreateCustomer_ShouldReturnCreatedAtRouteStatusAndNewCustomerId()
        {
            //Arrange
            var customerForCreateDto = _fixture.Build<CustomerForCreateDto>()
                .With(c => c.CustomerName, "Test customer")
                .Create();

            var jsonRequest = JsonConvert.SerializeObject(customerForCreateDto);
            var requestContent = new StringContent(jsonRequest, Encoding.UTF8, MediaTypeNames.Application.Json);

            //Act
            var response = await _client.PostAsync("api/customers", requestContent);
            var responseContent = await response.Content.ReadAsStringAsync();
            var CreatedCustomerGuid = JsonConvert.DeserializeObject<Guid>(responseContent);

            var createdCustomer = await _dbContext.Customers.FindAsync(CreatedCustomerGuid);

            //Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.NotEqual(Guid.Empty, CreatedCustomerGuid);

            Assert.NotNull(response.Headers.Location);
            Assert.Contains($"/api/Customers/{createdCustomer?.Id}", response.Headers.Location.AbsolutePath.ToString());
            Assert.Contains(createdCustomer.Id.ToString(), response.Headers.Location.ToString());

            Assert.NotNull(createdCustomer);
            Assert.Equal(customerForCreateDto.CustomerName, createdCustomer.CustomerName);
        }

        [Fact]
        public async Task UpdateCustomer_ShouldReturnNoContentStatus()
        {
            //Arrange
            var customerId = await CreateTestCustomerEntityAsync();

            var customerBeforeUpdate = await _dbContext.Customers.FindAsync(customerId);
            var customerNameBeforeUpdate = customerBeforeUpdate.CustomerName;

            var customerForUpdateDto = _fixture.Build<CustomerForUpdateDto>()
                .With(c => c.CustomerName, "Test customer")
                .Create();

            var jsonRequest = JsonConvert.SerializeObject(customerForUpdateDto);
            var requestContent = new StringContent(jsonRequest, Encoding.UTF8, MediaTypeNames.Application.Json);

            //Act
            var response = await _client.PutAsync($"api/customers/{customerId}", requestContent);

            var customerAfterUpdate = await _dbContext.Customers.AsNoTracking().FirstOrDefaultAsync(c => c.Id.Equals(customerId));

            //Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
            Assert.NotEqual(customerNameBeforeUpdate, customerAfterUpdate?.CustomerName);
            Assert.Equal(customerBeforeUpdate?.Id, customerAfterUpdate?.Id);
        }

        [Fact]
        public async Task UpdateCustomer_ShouldReturnNotFoundStatus()
        {
            //Arrange
            Guid fakeId = Guid.NewGuid();
            var customerForUpdateDto = _fixture.Build<CustomerForUpdateDto>()
                .With(c => c.CustomerName, "Test customer")
                .Create();

            var jsonRequest = JsonConvert.SerializeObject(customerForUpdateDto);
            var requestContent = new StringContent(jsonRequest, Encoding.UTF8, MediaTypeNames.Application.Json);

            //Act
            var response = await _client.PutAsync($"api/customers/{fakeId}", requestContent);

            var content = await response.Content.ReadAsStringAsync();
            var errorDetails = JsonConvert.DeserializeObject<ErrorDetails>(content);

            //Assert
            Assert.NotNull(errorDetails);
            Assert.Equal(StatusCodes.Status404NotFound, errorDetails.StatusCode);
            Assert.Equal($"Customer with ID: {fakeId} was not found.", errorDetails.Message);
        }

        [Fact]
        public async Task DeleteCustomer_ShouldReturnNoContentStatus()
        {
            //Arrange
            var customerId = await CreateTestCustomerEntityAsync();

            //Act
            var response = await _client.DeleteAsync($"api/customers/{customerId}");

            var deletedCustomer = await _dbContext.Customers.FirstOrDefaultAsync(c => c.Id.Equals(customerId));
            //Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
            Assert.Null(deletedCustomer);
        }

        [Fact]
        public async Task DeleteCustomer_ShouldReturnNotFoundStatus()
        {
            //Arrange
            Guid fakeId = Guid.NewGuid();

            //Act
            var response = await _client.DeleteAsync($"api/customers/{fakeId}");

            var content = await response.Content.ReadAsStringAsync();
            var errorDetails = JsonConvert.DeserializeObject<ErrorDetails>(content);

            //Assert
            Assert.NotNull(errorDetails);
            Assert.Equal(StatusCodes.Status404NotFound, errorDetails.StatusCode);
            Assert.Equal($"Customer with ID: {fakeId} was not found.", errorDetails.Message);
        }

        [Fact]
        public async Task GetCustomerById_ShouldReturnNotFoundStatus()
        {
            //Arrange
            Guid fakeId = Guid.NewGuid();

            //Act
            var response = await _client.GetAsync($"api/customers/{fakeId}");

            var content = await response.Content.ReadAsStringAsync();
            var errorDetails = JsonConvert.DeserializeObject<ErrorDetails>(content);

            //Assert
            Assert.NotNull(errorDetails);
            Assert.Equal(StatusCodes.Status404NotFound, errorDetails.StatusCode);
            Assert.Equal($"Customer with ID: {fakeId} was not found.", errorDetails.Message);
        }
    }
}
