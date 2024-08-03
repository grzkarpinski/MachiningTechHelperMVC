using MachiningTechHelperApi.Controllers;
using MachiningTechelperMVC.Application.Interfaces;
using MachiningTechelperMVC.Application.ViewModels.SimpleCalculator;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace MachiningTechHelperMVC.Tests.UITests.API
{
    public class SimpleCalculatorControllerTests
    {
        private readonly Mock<ISimpleCalculatorLogic> _mockCalculatorLogic;
        private readonly SimpleCalculatorController _controller;

        public SimpleCalculatorControllerTests()
        {
            _mockCalculatorLogic = new Mock<ISimpleCalculatorLogic>();
            _controller = new SimpleCalculatorController(_mockCalculatorLogic.Object);
        }

        [Fact]
        public void Index_Get_ReturnsOkResult_WithEmptyModel()
        {
            // Act
            var result = _controller.Index();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<SimpleCalculatorVm>(okResult.Value);
            Assert.NotNull(returnValue);
        }

        [Fact]
        public void Index_Post_InvalidModel_ReturnsBadRequest()
        {
            // Arrange
            _controller.ModelState.AddModelError("Error", "Invalid model");

            // Act
            var result = _controller.Index(new SimpleCalculatorVm());

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }
    }
}
