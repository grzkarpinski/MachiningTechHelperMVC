using MachiningTechHelperApi.Controllers;
using MachiningTechelperMVC.Application.Interfaces;
using MachiningTechelperMVC.Application.ViewModels.MillingTool;
using MachiningTechelperMVC.Application.ViewModels.SolidMillingTool;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace MachiningTechHelperMVC.Tests.UITests.API
{
    public class SolidMillingToolControllerTests
    {
        private readonly Mock<ISolidMillingToolService> _mockSolidMillingToolService;
        private readonly SolidMillingToolController _controller;

        public SolidMillingToolControllerTests()
        {
            _mockSolidMillingToolService = new Mock<ISolidMillingToolService>();
            _controller = new SolidMillingToolController(_mockSolidMillingToolService.Object);
        }

        [Fact]
        public void ViewSolidMillingTool_ExistingId_ReturnsOkResult_WithSolidMillingToolDetails()
        {
            // Arrange
            var tool = new SolidMillingToolDetailsVm { Id = 1};
            _mockSolidMillingToolService.Setup(service => service.GetSolidMillingToolDetails(1)).Returns(tool);

            // Act
            var result = _controller.ViewSolidMillingTool(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<SolidMillingToolDetailsVm>(okResult.Value);
            Assert.Equal(1, returnValue.Id);
        }

        [Fact]
        public void ViewSolidMillingTool_NonExistingId_ReturnsNotFoundResult()
        {
            // Arrange
            _mockSolidMillingToolService.Setup(service => service.GetSolidMillingToolDetails(1)).Returns((SolidMillingToolDetailsVm)null);

            // Act
            var result = _controller.ViewSolidMillingTool(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}
