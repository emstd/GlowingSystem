using AutoFixture;
using GlowingSystem.Core.DataTransferObjects;
using GlowingSystem.Core.ErrorModels;
using GlowingSystem.Core.ErrorModels.Exceptions;
using GlowingSystem.Core.Models;
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
    public class ContractorsTests : BaseInitialization, IClassFixture<WebApplicationFactory<Program>>
    {
        public ContractorsTests(WebApplicationFactory<Program> app) : base(app) { }
        public async Task<Guid> CreateTestContractorEntityAsync()
        {
            var testContractor = _fixture.Build<ContractorEntity>()
                .Without(c => c.Id)
                .With(c => c.ContractorName)
                .Create();

            _dbContext.Contractors.Add(testContractor);
            await _dbContext.SaveChangesAsync();
            _dbContext.ChangeTracker.Clear();

            return testContractor.Id;
        }

        [Fact]
        public async Task GetContractors_ShouldReturnOKStatus()
        {
            //Arrange
            await CreateTestContractorEntityAsync();
            await CreateTestContractorEntityAsync();
            await CreateTestContractorEntityAsync();

            //Act
            var response = await _client.GetAsync("api/contractors");

            var content = await response.Content.ReadAsStringAsync();

            var contractorsResponse = JsonConvert.DeserializeObject<List<ContractorDto>>(content);

            var contractor = contractorsResponse?.First();

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(contractorsResponse);
            Assert.IsType<List<ContractorDto>>(contractorsResponse);

            Assert.Equal(3, contractorsResponse.Count);
            Assert.All(contractorsResponse, contractor =>
            {
                Assert.NotNull(contractor?.Id);
                Assert.NotEmpty(contractor.Id.ToString());
                Assert.NotNull(contractor.ContractorName);
                Assert.NotEmpty(contractor.ContractorName);
            });
        }

        [Fact]
        public async Task GetContractorById_ShouldReturnOkStatus()
        {
            //Arrange
            Guid contractorId = await CreateTestContractorEntityAsync();

            //Act
            var response = await _client.GetAsync($"api/contractors/{contractorId}");

            var content = await response.Content.ReadAsStringAsync();
            var contractorResponse = JsonConvert.DeserializeObject<ContractorDto>(content);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.IsType<ContractorDto>(contractorResponse);
            Assert.Equal(contractorId, contractorResponse.Id);
            Assert.NotNull(contractorResponse.ContractorName);
            Assert.NotEmpty(contractorResponse.ContractorName);
        }

        [Fact]
        public async Task CreateContractor_ShouldReturnCreatedAtRouteStatusAndNewContractorId()
        {
            //Arrange
            var contractorForCreateDto = _fixture.Build<ContractorForCreateDto>()
                .With(c => c.ContractorName, "Test contractor")
                .Create();

            var jsonRequest = JsonConvert.SerializeObject(contractorForCreateDto);
            var requestContent = new StringContent(jsonRequest, Encoding.UTF8, MediaTypeNames.Application.Json);

            //Act
            var response = await _client.PostAsync("api/contractors", requestContent);
            var responseContent = await response.Content.ReadAsStringAsync();
            var CreatedContractorGuid = JsonConvert.DeserializeObject<Guid>(responseContent);

            var createdContractor = await _dbContext.Contractors.FindAsync(CreatedContractorGuid);

            //Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.NotEqual(Guid.Empty, CreatedContractorGuid);

            Assert.NotNull(response.Headers.Location);
            Assert.Contains($"/api/Contractors/{createdContractor?.Id}", response.Headers.Location.AbsolutePath.ToString());
            Assert.Contains(createdContractor.Id.ToString(), response.Headers.Location.ToString());

            Assert.NotNull(createdContractor);
            Assert.Equal(contractorForCreateDto.ContractorName, createdContractor.ContractorName);
        }

        [Fact]
        public async Task UpdateContractor_ShouldReturnNoContentStatus()
        {
            //Arrange
            var contractorId = await CreateTestContractorEntityAsync();

            var contractorBeforeUpdate = await _dbContext.Contractors.FindAsync(contractorId);
            var contractorNameBeforeUpdate = contractorBeforeUpdate?.ContractorName;

            var contractorForUpdateDto = _fixture.Build<ContractorForUpdateDto>()
                .With(c => c.ContractorName, "Test contractor")
                .Create();

            var jsonRequest = JsonConvert.SerializeObject(contractorForUpdateDto);
            var requestContent = new StringContent(jsonRequest, Encoding.UTF8, MediaTypeNames.Application.Json);

            //Act
            var response = await _client.PutAsync($"api/contractors/{contractorId}", requestContent);

            var contractorAfterUpdate = await _dbContext.Contractors.AsNoTracking().FirstOrDefaultAsync(c => c.Id.Equals(contractorId));

            //Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
            Assert.NotEqual(contractorNameBeforeUpdate, contractorAfterUpdate?.ContractorName);
            Assert.Equal(contractorBeforeUpdate?.Id, contractorAfterUpdate?.Id);
        }

        [Fact]
        public async Task UpdateContractor_ShouldReturnNotFoundStatus()
        {
            //Arrange
            Guid fakeId = Guid.NewGuid();
            var contractorForUpdateDto = _fixture.Build<ContractorForUpdateDto>()
                .With(c => c.ContractorName, "Test contractor")
                .Create();

            var jsonRequest = JsonConvert.SerializeObject(contractorForUpdateDto);
            var requestContent = new StringContent(jsonRequest, Encoding.UTF8, MediaTypeNames.Application.Json);

            //Act
            var response = await _client.PutAsync($"api/contractors/{fakeId}", requestContent);

            var content = await response.Content.ReadAsStringAsync();
            var errorDetails = JsonConvert.DeserializeObject<ErrorDetails>(content);

            //Assert
            Assert.NotNull(errorDetails);
            Assert.Equal(StatusCodes.Status404NotFound, errorDetails.StatusCode);
            Assert.Equal($"Contractor with ID: {fakeId} was not found.", errorDetails.Message);
        }

        [Fact]
        public async Task DeleteContractor_ShouldReturnNoContentStatus()
        {
            //Arrange
            var contractorId = await CreateTestContractorEntityAsync();

            //Act
            var response = await _client.DeleteAsync($"api/contractors/{contractorId}");

            var deletedContractor = await _dbContext.Contractors.FirstOrDefaultAsync(c => c.Id.Equals(contractorId));
            //Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
            Assert.Null(deletedContractor);
        }

        [Fact]
        public async Task DeleteContractor_ShouldReturnNotFoundStatus()
        {
            //Arrange
            Guid fakeId = Guid.NewGuid();

            //Act
            var response = await _client.DeleteAsync($"api/contractors/{fakeId}");

            var content = await response.Content.ReadAsStringAsync();
            var errorDetails = JsonConvert.DeserializeObject<ErrorDetails>(content);

            //Assert
            Assert.NotNull(errorDetails);
            Assert.Equal(StatusCodes.Status404NotFound, errorDetails.StatusCode);
            Assert.Equal($"Contractor with ID: {fakeId} was not found.", errorDetails.Message);
        }

        [Fact]
        public async Task GetContractorById_ShouldReturnNotFoundStatus()
        {
            //Arrange
            Guid fakeId = Guid.NewGuid();

            //Act
            var response = await _client.GetAsync($"api/contractors/{fakeId}");

            var content = await response.Content.ReadAsStringAsync();
            var errorDetails = JsonConvert.DeserializeObject<ErrorDetails>(content);

            //Assert
            Assert.NotNull(errorDetails);
            Assert.Equal(StatusCodes.Status404NotFound, errorDetails.StatusCode);
            Assert.Equal($"Contractor with ID: {fakeId} was not found.", errorDetails.Message);
        }
    }
}
