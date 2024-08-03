using MachiningTechHelperApi.Controllers;
using MachiningTechHelperMVC.Application.Interfaces;
using MachiningTechHelperMVC.Application.ViewModels.Drill;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace MachiningTechHelperMVC.Tests
{
    public class DrillControllerTests
    {
        private readonly Mock<IDrillService> _mockDrillService;
        private readonly DrillController _controller;

        public DrillControllerTests()
        {
            _mockDrillService = new Mock<IDrillService>();
            _controller = new DrillController(_mockDrillService.Object);
        }

        [Fact]
        public void ViewDrill_ExistingId_ReturnsOkResult_WithDrillDetails()
        {
            // Arrange
            var drill = new DrillDetailsVm { Id = 1};
            _mockDrillService.Setup(service => service.GetDrillDetails(1)).Returns(drill);

            // Act
            var result = _controller.ViewDrill(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<DrillDetailsVm>(okResult.Value);
            Assert.Equal(1, returnValue.Id);
        }

        [Fact]
        public void ViewDrill_NonExistingId_ReturnsNotFoundResult()
        {
            // Arrange
            _mockDrillService.Setup(service => service.GetDrillDetails(1)).Returns((DrillDetailsVm)null);

            // Act
            var result = _controller.ViewDrill(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}
