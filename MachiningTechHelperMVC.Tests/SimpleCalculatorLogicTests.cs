using MachiningTechHelperMVC.Domain.Calculators;
using MachiningTechelperMVC.Application.Calculators;
using MachiningTechelperMVC.Application.Interfaces;
using MachiningTechelperMVC.Application.ViewModels.SimpleCalculator;
using Moq;
using Xunit;
using System;

namespace MachiningTechHelperMVC.Tests
{
    public class SimpleCalculatorLogicTests
    {
        [Fact]
        public void Calculate_NullModel_ThrowsArgumentNullException()
        {
            // Arrange
            var logic = new SimpleCalculatorLogic();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => logic.Calculate(null));
        }

        [Fact]
        public void Calculate_MillingModel_UsesMillingStrategy()
        {
            // Arrange
            var mockStrategy = new Mock<ICalculationStrategy>();
            var model = new SimpleCalculatorVm { IsMilling = true, CuttingSpeed = 200, Diameter = 20, FeedPerTooth = 0.1, Teeth = 3};
            var expectedModel = new SimpleCalculatorVm { RevolutionsPerMinute = 3183, FeedPerMinute = 954 };
            mockStrategy.Setup(s => s.Calculate(model)).Returns(expectedModel);

            var logic = new SimpleCalculatorLogic();
            var context = new SimpleCalculatorContext(mockStrategy.Object);

            // Act
            var result = logic.Calculate(model);

            // Assert
            Assert.Equal(expectedModel.RevolutionsPerMinute, result.RevolutionsPerMinute);
            Assert.Equal(expectedModel.FeedPerMinute, result.FeedPerMinute);
        }

        [Fact]
        public void Calculate_DrillingModel_UsesDrillingStrategy()
        {
            // Arrange
            var mockStrategy = new Mock<ICalculationStrategy>();
            var model = new SimpleCalculatorVm { IsMilling = false, CuttingSpeed = 200, Diameter = 20, FeedPerRevolution = 0.2};
            var expectedModel = new SimpleCalculatorVm { RevolutionsPerMinute = 3183, FeedPerMinute = 636 };
            mockStrategy.Setup(s => s.Calculate(model)).Returns(expectedModel);

            var logic = new SimpleCalculatorLogic();
            var context = new SimpleCalculatorContext(mockStrategy.Object);

            // Act
            var result = logic.Calculate(model);

            // Assert
            Assert.Equal(expectedModel.RevolutionsPerMinute, result.RevolutionsPerMinute);
            Assert.Equal(expectedModel.FeedPerMinute, result.FeedPerMinute);
        }
    }
}