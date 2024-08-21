using AutoMapper;
using MachiningTechelperMVC.Application.ViewModels.DrillCheckedParameters;
using MachiningTechHelperMVC.Application.Interfaces;
using MachiningTechHelperMVC.Application.Services;
using MachiningTechHelperMVC.Application.ViewModels.Drill;
using MachiningTechHelperMVC.Domain.Interfaces;
using MachiningTechHelperMVC.Domain.Model;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MachiningTechelperMVC.Tests
{
    public class DrillServiceTests
    {
        private readonly Mock<IDrillRepository> _mockRepo;
        private readonly Mock<IMapper> _mockMapper;
        private readonly DrillService _service;

        public DrillServiceTests()
        {
            _mockRepo = new Mock<IDrillRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new DrillService(_mockRepo.Object, _mockMapper.Object);
        }

        [Fact]
        public void AddDrill_ShouldReturnNewId()
        {
            // Arrange
            var vm = new NewDrillVm();
            var model = new Drill();
            _mockMapper.Setup(m => m.Map<Drill>(vm)).Returns(model);
            _mockRepo.Setup(r => r.AddDrill(model)).Returns(1);

            // Act
            var result = _service.AddDrill(vm);

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void DeleteDrill_ShouldCallRepository()
        {
            // Act
            _service.DeleteDrill(1);

            // Assert
            _mockRepo.Verify(r => r.DeleteDrill(1), Times.Once);
        }

        [Fact]
        public void DeleteDrillSoft_ShouldCallRepository()
        {
            // Act
            _service.DeleteDrillSoft(1);

            // Assert
            _mockRepo.Verify(r => r.DeleteDrillSoft(1), Times.Once);
        }

        [Fact]
        public void GetDrillDetails_ShouldReturnViewModel()
        {
            // Arrange
            var model = new Drill();
            var vm = new DrillDetailsVm();
            _mockRepo.Setup(r => r.GetDrillById(1)).Returns(model);
            _mockMapper.Setup(m => m.Map<DrillDetailsVm>(model)).Returns(vm);

            // Act
            var result = _service.GetDrillDetails(1);

            // Assert
            Assert.Equal(vm, result);
        }

        [Fact]
        public void GetDrillForEdit_ShouldReturnViewModel()
        {
            // Arrange
            var model = new Drill();
            var vm = new NewDrillVm();
            _mockRepo.Setup(r => r.GetDrillById(1)).Returns(model);
            _mockMapper.Setup(m => m.Map<NewDrillVm>(model)).Returns(vm);

            // Act
            var result = _service.GetDrillForEdit(1);

            // Assert
            Assert.Equal(vm, result);
        }

        [Fact]
        public void UpdateDrill_ShouldCallRepository()
        {
            // Arrange
            var vm = new NewDrillVm();
            var model = new Drill();
            _mockMapper.Setup(m => m.Map<Drill>(vm)).Returns(model);

            // Act
            _service.UpdateDrill(vm);

            // Assert
            _mockRepo.Verify(r => r.UpdateDrill(model), Times.Once);
        }
    }
}
