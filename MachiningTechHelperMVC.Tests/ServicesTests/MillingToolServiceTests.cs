using AutoMapper;
using AutoMapper.QueryableExtensions;
using MachiningTechelperMVC.Application.Interfaces;
using MachiningTechelperMVC.Application.Services;
using MachiningTechelperMVC.Application.ViewModels.MillingTool;
using MachiningTechHelperMVC.Domain.Interfaces;
using MachiningTechHelperMVC.Domain.Model;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MachiningTechelperMVC.Tests
{
    public class MillingToolServiceTests
    {
        private readonly Mock<IMillingToolRepository> _mockRepo;
        private readonly Mock<IMapper> _mockMapper;
        private readonly MillingToolService _service;

        public MillingToolServiceTests()
        {
            _mockRepo = new Mock<IMillingToolRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new MillingToolService(_mockRepo.Object, _mockMapper.Object);
        }

        [Fact]
        public void AddMillingTool_ShouldReturnNewId()
        {
            // Arrange
            var vm = new NewMillingToolVm();
            var model = new MillingTool();
            _mockMapper.Setup(m => m.Map<MillingTool>(vm)).Returns(model);
            _mockRepo.Setup(r => r.AddMillingTool(model)).Returns(1);

            // Act
            var result = _service.AddMillingTool(vm);

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void DeleteMillingTool_ShouldCallRepository()
        {
            // Act
            _service.DeleteMillingTool(1);

            // Assert
            _mockRepo.Verify(r => r.DeleteMillingTool(1), Times.Once);
        }

        [Fact]
        public void DeleteMillingToolSoft_ShouldCallRepository()
        {
            // Act
            _service.DeleteMillingToolSoft(1);

            // Assert
            _mockRepo.Verify(r => r.DeleteMillingToolSoft(1), Times.Once);
        }

        [Fact]
        public void GetMillingToolDetails_ShouldReturnViewModel()
        {
            // Arrange
            var model = new MillingTool();
            var vm = new MillingToolDetailsVm();
            _mockRepo.Setup(r => r.GetMillingToolById(1)).Returns(model);
            _mockMapper.Setup(m => m.Map<MillingToolDetailsVm>(model)).Returns(vm);

            // Act
            var result = _service.GetMillingToolDetails(1);

            // Assert
            Assert.Equal(vm, result);
        }

        [Fact]
        public void GetMillingToolForEdit_ShouldReturnViewModel()
        {
            // Arrange
            var model = new MillingTool();
            var vm = new NewMillingToolVm();
            _mockRepo.Setup(r => r.GetMillingToolById(1)).Returns(model);
            _mockMapper.Setup(m => m.Map<NewMillingToolVm>(model)).Returns(vm);

            // Act
            var result = _service.GetMillingToolForEdit(1);

            // Assert
            Assert.Equal(vm, result);
        }

        [Fact]
        public void UpdateMillingTool_ShouldCallRepository()
        {
            // Arrange
            var vm = new NewMillingToolVm();
            var model = new MillingTool();
            _mockMapper.Setup(m => m.Map<MillingTool>(vm)).Returns(model);

            // Act
            _service.UpdateMillingTool(vm);

            // Assert
            _mockRepo.Verify(r => r.UpdateMillingTool(model), Times.Once);
        }
    }
}
