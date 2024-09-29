using Microsoft.AspNetCore.Mvc;
using Moq;
using TestableAPI.Controllers;
using TestableAPI.Models;
using TestableAPI.Repositories;
using TestableAPI.Services;
using Xunit;

namespace TestableAPI.UnitTests
{
    public class EmployeesControllerTests
    {
        private readonly Mock<ICrudRepository<Employee>> mockRepository;
        private readonly EmployeesController controller;
        public EmployeesControllerTests()
        {
            mockRepository = new Mock<ICrudRepository<Employee>>();
            controller = new EmployeesController(new CrudService<Employee>(mockRepository.Object));
        }

        [Fact]
        public async Task GetAsync_ReturnsOKResult_WithListOfEmployees()
        {
            var employee = new Employee { Id = 1, Name = "Kondwani Hara", Designation = "Programmer" };
            var employees = new List<Employee>() { employee };
            mockRepository.Setup(repository => repository.ReadAllAsync()).ReturnsAsync(employees);
            

            var result = await controller.GetAsync();
            
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnEntities = Assert.IsType<List<Employee>>(okResult.Value);
            Assert.Single(returnEntities);
        }
        [Fact]
        public async Task GetAsync_ReturnsOkResult_WithEmployee()
        {
            var employee = new Employee { Id = 1, Name = "Kondwani Hara", Designation = "Programmer" };
            mockRepository.Setup(repository => repository.ReadByIdAsync(1)).ReturnsAsync(employee);
            var result = await controller.GetAsync(1);
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedEmployee = Assert.IsType<Employee>(okResult.Value);
            Assert.Equal(employee.Id, returnedEmployee.Id);
        }
        [Fact]
        public async Task PostAsync_ReturnsOkResult_WithEmployee()
        {
            var employee = new Employee { Id = 1, Name = "Kondwani Hara", Designation = "Programmer" };
            mockRepository.Setup(repository => repository.CreateAsync(employee)).ReturnsAsync(employee);

            var result = await controller.PostAsync(employee);
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedEmployee = Assert.IsType<Employee>(okResult.Value);
            Assert.Equal(employee.Id, returnedEmployee.Id);
        }

        [Fact]
        public async Task PutAsync_ReturnsNoContentResult()
        {
            var employee = new Employee { Id = 1, Name = "Kondwani Hara", Designation = "Programmer" };
            mockRepository.Setup(repository => repository.UpdateAsync(employee)).Returns(Task.CompletedTask);

            var result = await controller.PutAsync(1,employee);
            var noContentResult = Assert.IsType<NoContentResult>(result);
        }
        [Fact] async Task DeleteAsync_ReturnsNoContentResult()
        {
            var employee = new Employee { Id = 1, Name = "Kondwani Hara", Designation = "Programmer" };
            mockRepository.Setup(repository => repository.ReadByIdAsync(1)).ReturnsAsync(employee);
            mockRepository.Setup(repository => repository.DeleteAsync(1)).Returns(Task.CompletedTask);

            var result = await controller.DeleteAsync(1);
            var noContentResult = Assert.IsType<NoContentResult>(result);
        }
    }
}
