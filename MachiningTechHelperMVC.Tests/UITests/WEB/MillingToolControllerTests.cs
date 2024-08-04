using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MachiningTechelperMVC.Application.Interfaces;
using MachiningTechelperMVC.Application.ViewModels.MillingTool;
using MachiningTechHelperMVC.Web.Controllers;

namespace MachiningTechHelperMVC.Tests.Controllers
{
    public class MillingToolControllerTests
    {
        private readonly Mock<IMillingToolService> _mockMillingToolService;
        private readonly Mock<IMillingInsertService> _mockMillingInsertService;
        private readonly Mock<IMillingInsertParametersRangeService> _mockMillingInsertParametersRangeService;
        private readonly Mock<IMillingToolCheckedParametersService> _mockMillingToolCheckedParametersService;
        private readonly Mock<IMillingToolMillingInsertService> _mockMillingToolMillingInsertService;
        private readonly Mock<ILogger<MillingToolController>> _mockLogger;
        private readonly MillingToolController _controller;

        public MillingToolControllerTests()
        {
            _mockMillingToolService = new Mock<IMillingToolService>();
            _mockMillingInsertService = new Mock<IMillingInsertService>();
            _mockMillingInsertParametersRangeService = new Mock<IMillingInsertParametersRangeService>();
            _mockMillingToolCheckedParametersService = new Mock<IMillingToolCheckedParametersService>();
            _mockMillingToolMillingInsertService = new Mock<IMillingToolMillingInsertService>();
            _mockLogger = new Mock<ILogger<MillingToolController>>();
            _controller = new MillingToolController(
                _mockMillingToolService.Object,
                _mockMillingInsertService.Object,
                _mockMillingInsertParametersRangeService.Object,
                _mockMillingToolCheckedParametersService.Object,
                _mockMillingToolMillingInsertService.Object,
                _mockLogger.Object
            );
        }

        [Fact]
        public void AddMillingTool_ReturnsViewResult_WithNewMillingToolVm()
        {
            // Act
            var result = _controller.AddMillingTool();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<NewMillingToolVm>(viewResult.Model);
        }

        [Fact]
        public void EditMillingTool_ReturnsViewResult_WithMillingTool()
        {
            // Arrange
            int testId = 1;
            _mockMillingToolService.Setup(service => service.GetMillingToolForEdit(testId))
                .Returns(new NewMillingToolVm());

            // Act
            var result = _controller.EditMillingTool(testId);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<NewMillingToolVm>(viewResult.Model);
        }

        [Fact]
        public void EditMillingTool_Post_ValidModel_RedirectsToIndex()
        {
            // Arrange
            var millingToolVm = new NewMillingToolVm();

            // Act
            var result = _controller.EditMillingTool(millingToolVm);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public void DeleteMillingTool_RedirectsToIndex()
        {
            // Arrange
            int testId = 1;

            // Act
            var result = _controller.DeleteMillingTool(testId);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }
    }
}