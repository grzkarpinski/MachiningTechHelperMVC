using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MachiningTechelperMVC.Application.Interfaces;
using MachiningTechelperMVC.Application.ViewModels.SimpleCalculator;
using MachiningTechHelperMVC.Web.Controllers;

namespace MachiningTechHelperMVC.Tests.Controllers
{
    public class SimpleCalculatorControllerTests
    {
        private readonly Mock<ISimpleCalculatorLogic> _mockCalculatorLogic;
        private readonly Mock<ILogger<SimpleCalculatorController>> _mockLogger;
        private readonly SimpleCalculatorController _controller;

        public SimpleCalculatorControllerTests()
        {
            _mockCalculatorLogic = new Mock<ISimpleCalculatorLogic>();
            _mockLogger = new Mock<ILogger<SimpleCalculatorController>>();
            _controller = new SimpleCalculatorController(
                _mockCalculatorLogic.Object,
                _mockLogger.Object
            );
        }

        [Fact]
        public void Index_Get_ReturnsViewResult_WithSimpleCalculatorVm()
        {
            // Act
            var result = _controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<SimpleCalculatorVm>(viewResult.Model);
        }

        [Fact]
        public void Index_Post_InvalidModel_ReturnsViewResult_WithModel()
        {
            // Arrange
            _controller.ModelState.AddModelError("Error", "Model error");
            var model = new SimpleCalculatorVm();

            // Act
            var result = _controller.Index(model);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Index", viewResult.ViewName);
            Assert.Same(model, viewResult.Model);
        }

        [Fact]
        public void Result_Get_ReturnsViewResult()
        {
            // Act
            var result = _controller.Result();

            // Assert
            Assert.IsType<ViewResult>(result);
        }
    }
}