using MachiningTechelperMVC.Application.Interfaces;
using MachiningTechelperMVC.Application.ViewModels.CostEstimation;
using MachiningTechHelperMVC.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace MachiningTechHelperMVC.Tests.Controllers
{
    public class CostEstimationControllerTests
    {
        private readonly Mock<ICostEstimationLogic> _costEstimationLogicMock;
        private readonly Mock<ILogger<CostEstimationController>> _loggerMock;
        private readonly CostEstimationController _controller;

        public CostEstimationControllerTests()
        {
            _costEstimationLogicMock = new Mock<ICostEstimationLogic>();
            _loggerMock = new Mock<ILogger<CostEstimationController>>();

            _controller = new CostEstimationController(
                _costEstimationLogicMock.Object,
                _loggerMock.Object
            );
        }

        [Fact]
        public void Index_Post_ReturnsViewResult_WithSameModel_WhenModelStateIsInvalid()
        {
            // Arrange
            var model = new CostEstimationVm();
            _controller.ModelState.AddModelError("TestError", "Test error");

            // Act
            var result = _controller.Index(model);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Index", viewResult.ViewName);
            Assert.Equal(model, viewResult.Model);
        }

        [Fact]
        public void Index_Post_ReturnsViewResult_WithResultModel_WhenModelStateIsValid()
        {
            // Arrange
            var model = new CostEstimationVm();
            var resultModel = new CostEstimationVm();
            _costEstimationLogicMock.Setup(logic => logic.CalculateCosts(model)).Returns(resultModel);

            // Act
            var result = _controller.Index(model);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Result", viewResult.ViewName);
            Assert.Equal(resultModel, viewResult.Model);
        }

        [Fact]
        public void Result_Get_ReturnsViewResult()
        {
            // Act
            var result = _controller.Result();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }
    }
}