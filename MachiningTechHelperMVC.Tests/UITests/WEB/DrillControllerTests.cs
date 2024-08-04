using MachiningTechelperMVC.Application.Interfaces;
using MachiningTechHelperMVC.Application.Interfaces;
using MachiningTechHelperMVC.Application.ViewModels.Drill;
using MachiningTechHelperMVC.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace MachiningTechHelperMVC.Tests.Controllers
{
    public class DrillControllerTests
    {
        private readonly Mock<IDrillService> _drillServiceMock;
        private readonly Mock<IDrillParametersRangeService> _drillParametersRangeServiceMock;
        private readonly Mock<IDrillCheckedParametersService> _drillCheckedParametersServiceMock;
        private readonly Mock<ILogger<DrillController>> _loggerMock;
        private readonly DrillController _controller;

        public DrillControllerTests()
        {
            _drillServiceMock = new Mock<IDrillService>();
            _drillParametersRangeServiceMock = new Mock<IDrillParametersRangeService>();
            _drillCheckedParametersServiceMock = new Mock<IDrillCheckedParametersService>();
            _loggerMock = new Mock<ILogger<DrillController>>();

            _controller = new DrillController(
                _drillServiceMock.Object,
                _drillParametersRangeServiceMock.Object,
                _drillCheckedParametersServiceMock.Object,
                _loggerMock.Object
            );
        }

        [Fact]
        public void Index_Post_ReturnsViewResult_WithFilteredDrillList()
        {
            // Arrange
            var drillList = new List<DrillForListVm> { new DrillForListVm() };
            _drillServiceMock.Setup(service => service.GetAllDrillsForList(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()))
                             .Returns(new ListDrillForListVm { Drills = drillList });

            // Act
            var result = _controller.Index(10, 1, "test");

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<ListDrillForListVm>(viewResult.Model);
            Assert.Equal(drillList, model.Drills);
        }

        [Fact]
        public void AddDrill_Get_ReturnsViewResult_WithNewDrillVm()
        {
            // Act
            var result = _controller.AddDrill();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<NewDrillVm>(viewResult.Model);
            Assert.NotNull(model.ToolTypes);
        }

        [Fact]
        public void ViewDrill_Get_ReturnsViewResult_WithDrillDetails()
        {
            // Arrange
            var drillDetails = new DrillDetailsVm();
            _drillServiceMock.Setup(service => service.GetDrillDetails(It.IsAny<int>())).Returns(drillDetails);

            // Act
            var result = _controller.ViewDrill(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<DrillDetailsVm>(viewResult.Model);
            Assert.Equal(drillDetails, model);
        }

        [Fact]
        public void EditDrill_Post_ReturnsRedirectToActionResult_WhenModelIsValid()
        {
            // Arrange
            var drill = new NewDrillVm();
            _drillServiceMock.Setup(service => service.UpdateDrill(drill));

            // Act
            var result = _controller.EditDrill(drill);

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectResult.ActionName);
        }

        [Fact]
        public void Delete_ReturnsRedirectToActionResult()
        {
            // Act
            var result = _controller.Delete(1);

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectResult.ActionName);
            _drillServiceMock.Verify(service => service.DeleteDrillSoft(1), Times.Once);
        }

        [Fact]
        public void DeletePermanently_ReturnsRedirectToActionResult()
        {
            // Act
            var result = _controller.DeletePermanently(1);

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectResult.ActionName);
            _drillServiceMock.Verify(service => service.DeleteDrill(1), Times.Once);
        }
    }
}