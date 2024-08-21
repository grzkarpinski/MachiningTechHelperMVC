using AutoMapper;
using AutoMapper.QueryableExtensions;
using MachiningTechelperMVC.Application.Interfaces;
using MachiningTechelperMVC.Application.Services;
using MachiningTechelperMVC.Application.ViewModels.MillingInsert;
using MachiningTechHelperMVC.Domain.Interfaces;
using MachiningTechHelperMVC.Domain.Model;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MachiningTechelperMVC.Tests
{
    public class MillingInsertServiceTests
    {
        private readonly Mock<IMillingInsertRepository> _mockRepo;
        private readonly Mock<IMapper> _mockMapper;
        private readonly MillingInsertService _service;

        public MillingInsertServiceTests()
        {
            _mockRepo = new Mock<IMillingInsertRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new MillingInsertService(_mockRepo.Object, _mockMapper.Object);
        }

        [Fact]
        public void AddMillingInsert_ShouldReturnNewId()
        {
            // Arrange
            var vm = new MillingInsertVm();
            var model = new MillingInsert();
            _mockMapper.Setup(m => m.Map<MillingInsert>(vm)).Returns(model);
            _mockRepo.Setup(r => r.AddMillingInsert(model)).Returns(1);

            // Act
            var result = _service.AddMillingInsert(vm);

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void DeleteMillingInsert_ShouldCallRepository()
        {
            // Act
            _service.DeleteMillingInsert(1);

            // Assert
            _mockRepo.Verify(r => r.DeleteMillingInsert(1), Times.Once);
        }

        [Fact]
        public void GetMillingInsertById_ShouldReturnViewModel()
        {
            // Arrange
            var model = new MillingInsert();
            var vm = new MillingInsertVm();
            _mockRepo.Setup(r => r.GetMillingInsertById(1)).Returns(model);
            _mockMapper.Setup(m => m.Map<MillingInsertVm>(model)).Returns(vm);

            // Act
            var result = _service.GetMillingInsertById(1);

            // Assert
            Assert.Equal(vm, result);
        }
    }
}
