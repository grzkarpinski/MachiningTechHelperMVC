using MachiningTechelperMVC.Application.Interfaces;
using MachiningTechelperMVC.Application.ViewModels.SolidMillingTool;
using MachiningTechelperMVC.Application.ViewModels.SolidMillingToolCheckedParameters;
using MachiningTechelperMVC.Application.ViewModels.SolidMillingToolParametersRange;
using MachiningTechHelperMVC.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace MachiningTechHelperMVC.Tests.Controllers
{
    public class SolidMillingToolControllerTests
    {
        private readonly Mock<ISolidMillingToolService> _mockSolidMillingToolService;
        private readonly Mock<ISolidMillingToolParametersRangeService> _mockSolidMillingToolParametersRangeService;
        private readonly Mock<ISolidMillingToolCheckedParametersService> _mockSolidMillingToolCheckedParametersService;
        private readonly Mock<ILogger<SolidMillingToolController>> _mockLogger;
        private readonly SolidMillingToolController _controller;

        public SolidMillingToolControllerTests()
        {
            _mockSolidMillingToolService = new Mock<ISolidMillingToolService>();
            _mockSolidMillingToolParametersRangeService = new Mock<ISolidMillingToolParametersRangeService>();
            _mockSolidMillingToolCheckedParametersService = new Mock<ISolidMillingToolCheckedParametersService>();
            _mockLogger = new Mock<ILogger<SolidMillingToolController>>();
            _controller = new SolidMillingToolController(
                _mockSolidMillingToolService.Object,
                _mockSolidMillingToolParametersRangeService.Object,
                _mockSolidMillingToolCheckedParametersService.Object,
                _mockLogger.Object
            );
        }

        [Fact]
        public void AddSolidMillingTool_Get_ReturnsViewResult_WithModel()
        {
            // Act
            var result = _controller.AddSolidMillingTool();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<NewSolidMillingToolVm>(viewResult.Model);
            Assert.NotNull(model.ToolTypes);
        }

        [Fact]
        public void ViewSolidMillingTool_Get_ReturnsViewResult_WithModel()
        {
            // Arrange
            var mockTool = new SolidMillingToolDetailsVm();
            _mockSolidMillingToolService.Setup(service => service.GetSolidMillingToolDetails(1))
                                        .Returns(mockTool);

            // Act
            var result = _controller.ViewSolidMillingTool(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Same(mockTool, viewResult.Model);
        }

        [Fact]
        public void EditSolidMillingTool_Post_ReturnsRedirectToActionResult()
        {
            // Arrange
            var tool = new NewSolidMillingToolVm();
            _mockSolidMillingToolService.Setup(service => service.UpdateSolidMillingTool(tool));

            // Act
            var result = _controller.EditSolidMillingTool(tool);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public void Delete_Get_ReturnsRedirectToActionResult()
        {
            // Arrange
            _mockSolidMillingToolService.Setup(service => service.DeleteSolidMillingToolSoft(1));

            // Act
            var result = _controller.Delete(1);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public void DeletePermanently_Get_ReturnsRedirectToActionResult()
        {
            // Arrange
            _mockSolidMillingToolService.Setup(service => service.DeleteSolidMillingTool(1));

            // Act
            var result = _controller.DeletePermanently(1);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public void AddParametersRange_Get_ReturnsViewResult_WithModel()
        {
            // Act
            var result = _controller.AddParametersRange(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<SolidMillingToolParametersRangeVm>(viewResult.Model);
            Assert.Equal(1, model.SolidMillingToolId);
        }

        [Fact]
        public void DeleteParametersRange_Get_ReturnsRedirectToActionResult()
        {
            // Arrange
            var range = new SolidMillingToolParametersRangeVm { SolidMillingToolId = 1 };
            _mockSolidMillingToolParametersRangeService.Setup(service => service.GetSolidMillingToolParametersForEdit(1))
                                                       .Returns(range);
            _mockSolidMillingToolParametersRangeService.Setup(service => service.DeleteSolidMillingToolParametersRange(1));

            // Act
            var result = _controller.DeleteParametersRange(1);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("ViewSolidMillingTool", redirectToActionResult.ActionName);
            Assert.Equal(1, redirectToActionResult.RouteValues["id"]);
        }

        [Fact]
        public void AddSolidMillingToolCheckedParameters_Get_ReturnsViewResult_WithModel()
        {
            // Act
            var result = _controller.AddSolidMillingToolCheckedParameters(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<SolidMillingToolCheckedParametersVm>(viewResult.Model);
            Assert.Equal(1, model.SolidMillingToolId);
        }

        [Fact]
        public void DeleteSolidMillingToolCheckedParameters_Get_ReturnsRedirectToActionResult()
        {
            // Arrange
            var checkedParams = new SolidMillingToolCheckedParametersVm { SolidMillingToolId = 1 };
            _mockSolidMillingToolCheckedParametersService.Setup(service => service.GetSolidMillingToolCheckedParametersById(1))
                                                         .Returns(checkedParams);
            _mockSolidMillingToolCheckedParametersService.Setup(service => service.DeleteSolidMillingToolCheckedParameters(1));

            // Act
            var result = _controller.DeleteSolidMillingToolCheckedParameters(1);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("ViewSolidMillingTool", redirectToActionResult.ActionName);
            Assert.Equal(1, redirectToActionResult.RouteValues["id"]);
        }
    }
}