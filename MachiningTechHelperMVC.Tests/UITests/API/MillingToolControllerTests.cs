using MachiningTechHelperApi.Controllers;
using MachiningTechelperMVC.Application.Interfaces;
using MachiningTechelperMVC.Application.ViewModels.MillingTool;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace MachiningTechHelperMVC.Tests.UITests.API
{
    public class MillingToolControllerTests
    {
        private readonly Mock<IMillingToolService> _mockMillingToolService;
        private readonly MillingToolController _controller;

        public MillingToolControllerTests()
        {
            _mockMillingToolService = new Mock<IMillingToolService>();
            _controller = new MillingToolController(_mockMillingToolService.Object);
        }

        [Fact]
        public void ViewMillingTool_ExistingId_ReturnsOkResult_WithMillingToolDetails()
        {
            // Arrange
            var millingTool = new MillingToolDetailsVm { Id = 1};
            _mockMillingToolService.Setup(service => service.GetMillingToolDetails(1)).Returns(millingTool);

            // Act
            var result = _controller.ViewMillingTool(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<MillingToolDetailsVm>(okResult.Value);
            Assert.Equal(1, returnValue.Id);
        }

        [Fact]
        public void ViewMillingTool_NonExistingId_ReturnsNotFoundResult()
        {
            // Arrange
            _mockMillingToolService.Setup(service => service.GetMillingToolDetails(1)).Returns((MillingToolDetailsVm)null);

            // Act
            var result = _controller.ViewMillingTool(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}

