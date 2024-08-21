using AutoMapper;
using AutoMapper.QueryableExtensions;
using MachiningTechelperMVC.Application.Interfaces;
using MachiningTechelperMVC.Application.Services;
using MachiningTechelperMVC.Application.ViewModels.SolidMillingTool;
using MachiningTechHelperMVC.Domain.Interfaces;
using MachiningTechHelperMVC.Domain.Model;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MachiningTechelperMVC.Tests
{
    public class SolidMillingToolServiceTests
    {
        private readonly Mock<ISolidMillingToolRepository> _mockRepo;
        private readonly Mock<IMapper> _mockMapper;
        private readonly SolidMillingToolService _service;

        public SolidMillingToolServiceTests()
        {
            _mockRepo = new Mock<ISolidMillingToolRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new SolidMillingToolService(_mockRepo.Object, _mockMapper.Object);
        }

        [Fact]
        public void AddSolidMillingTool_ShouldReturnNewId()
        {
            // Arrange
            var vm = new NewSolidMillingToolVm();
            var model = new SolidMillingTool();
            _mockMapper.Setup(m => m.Map<SolidMillingTool>(vm)).Returns(model);
            _mockRepo.Setup(r => r.AddSolidMillingTool(model)).Returns(1);

            // Act
            var result = _service.AddSolidMillingTool(vm);

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void DeleteSolidMillingTool_ShouldCallRepository()
        {
            // Act
            _service.DeleteSolidMillingTool(1);

            // Assert
            _mockRepo.Verify(r => r.DeleteSolidMillingTool(1), Times.Once);
        }

        [Fact]
        public void DeleteSolidMillingToolSoft_ShouldCallRepository()
        {
            // Act
            _service.DeleteSolidMillingToolSoft(1);

            // Assert
            _mockRepo.Verify(r => r.DeleteSolidMillingToolSoft(1), Times.Once);
        }

        [Fact]
        public void GetSolidMillingToolDetails_ShouldReturnViewModel()
        {
            // Arrange
            var model = new SolidMillingTool();
            var vm = new SolidMillingToolDetailsVm();
            _mockRepo.Setup(r => r.GetSolidMillingToolById(1)).Returns(model);
            _mockMapper.Setup(m => m.Map<SolidMillingToolDetailsVm>(model)).Returns(vm);

            // Act
            var result = _service.GetSolidMillingToolDetails(1);

            // Assert
            Assert.Equal(vm, result);
        }

        [Fact]
        public void GetSolidMillingToolForEdit_ShouldReturnViewModel()
        {
            // Arrange
            var model = new SolidMillingTool();
            var vm = new NewSolidMillingToolVm();
            _mockRepo.Setup(r => r.GetSolidMillingToolById(1)).Returns(model);
            _mockMapper.Setup(m => m.Map<NewSolidMillingToolVm>(model)).Returns(vm);

            // Act
            var result = _service.GetSolidMillingToolForEdit(1);

            // Assert
            Assert.Equal(vm, result);
        }

        [Fact]
        public void UpdateSolidMillingTool_ShouldCallRepository()
        {
            // Arrange
            var vm = new NewSolidMillingToolVm();
            var model = new SolidMillingTool();
            _mockMapper.Setup(m => m.Map<SolidMillingTool>(vm)).Returns(model);

            // Act
            _service.UpdateSolidMillingTool(vm);

            // Assert
            _mockRepo.Verify(r => r.UpdateSolidMillingTool(model), Times.Once);
        }
    }
}
