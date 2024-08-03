using MachiningTechelperMVC.Application.Interfaces;
using MachiningTechelperMVC.Application.ViewModels.CostEstimation;
using MachiningTechHelperApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace MachiningTechHelperApi.Tests
{
    public class CostEstimationControllerTests
    {
        private readonly Mock<ICostEstimationLogic> _mockCostEstimationLogic;
        private readonly CostEstimationController _controller;

        public CostEstimationControllerTests()
        {
            _mockCostEstimationLogic = new Mock<ICostEstimationLogic>();
            _controller = new CostEstimationController(_mockCostEstimationLogic.Object);
        }

        [Fact]
        public void Index_Get_ReturnsOkResultWithModel()
        {
            // Act
            var result = _controller.Index();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsType<CostEstimationVm>(okResult.Value);
            Assert.NotNull(model);
        }

        [Fact]
        public void Index_Post_InvalidModel_ReturnsBadRequest()
        {
            // Arrange
            _controller.ModelState.AddModelError("error", "some error");

            // Act
            var result = _controller.Index(new CostEstimationVm());

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }

        [Fact]
        public void Index_Post_ValidModel_ReturnsOkResultWithCalculatedCosts()
        {
            // Arrange
            var model = new CostEstimationVm();
            var expectedResult = new CostEstimationVm { TotalTPZCost = 100, TotalTJCost = 200 };
            _mockCostEstimationLogic.Setup(x => x.CalculateCosts(model)).Returns(expectedResult);

            // Act
            var result = _controller.Index(model);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualResult = Assert.IsType<CostEstimationVm>(okResult.Value);
            Assert.Equal(expectedResult.TotalTPZCost, actualResult.TotalTPZCost);
            Assert.Equal(expectedResult.TotalTJCost, actualResult.TotalTJCost);
        }
    }
}