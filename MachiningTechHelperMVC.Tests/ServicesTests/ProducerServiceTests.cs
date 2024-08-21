using AutoMapper;
using MachiningTechelperMVC.Application.Interfaces;
using MachiningTechelperMVC.Application.Services;
using MachiningTechelperMVC.Application.ViewModels.Producer;
using MachiningTechHelperMVC.Domain.Interfaces;
using MachiningTechHelperMVC.Domain.Model;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MachiningTechelperMVC.Tests
{
    public class ProducerServiceTests
    {
        private readonly Mock<IProducerRepository> _mockRepo;
        private readonly Mock<IMapper> _mockMapper;
        private readonly ProducerService _service;

        public ProducerServiceTests()
        {
            _mockRepo = new Mock<IProducerRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new ProducerService(_mockRepo.Object, _mockMapper.Object);
        }

        [Fact]
        public void AddProducer_ShouldReturnNewId()
        {
            // Arrange
            var vm = new ProducerVm();
            var model = new Producer();
            _mockMapper.Setup(m => m.Map<Producer>(vm)).Returns(model);
            _mockRepo.Setup(r => r.AddProducer(model)).Returns(1);

            // Act
            var result = _service.AddProducer(vm);

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void DeleteProducer_ShouldCallRepository()
        {
            // Act
            _service.DeleteProducer(1);

            // Assert
            _mockRepo.Verify(r => r.DeleteProducer(1), Times.Once);
        }

        [Fact]
        public void GetProducerById_ShouldReturnViewModel()
        {
            // Arrange
            var model = new Producer();
            var vm = new ProducerVm();
            _mockRepo.Setup(r => r.GetProducerById(1)).Returns(model);
            _mockMapper.Setup(m => m.Map<ProducerVm>(model)).Returns(vm);

            // Act
            var result = _service.GetProducerById(1);

            // Assert
            Assert.Equal(vm, result);
        }

        [Fact]
        public void GetProducerForEdit_ShouldReturnViewModel()
        {
            // Arrange
            var model = new Producer();
            var vm = new ProducerVm();
            _mockRepo.Setup(r => r.GetProducerById(1)).Returns(model);
            _mockMapper.Setup(m => m.Map<ProducerVm>(model)).Returns(vm);

            // Act
            var result = _service.GetProducerForEdit(1);

            // Assert
            Assert.Equal(vm, result);
        }

        [Fact]
        public void UpdateProducer_ShouldCallRepository()
        {
            // Arrange
            var vm = new ProducerVm();
            var model = new Producer();
            _mockMapper.Setup(m => m.Map<Producer>(vm)).Returns(model);

            // Act
            _service.UpdateProducer(vm);

            // Assert
            _mockRepo.Verify(r => r.UpdateProducer(model), Times.Once);
        }
    }
}
