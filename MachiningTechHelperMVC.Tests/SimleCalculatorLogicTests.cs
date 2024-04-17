using MachiningTechHelperMVC.Domain.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Tests
{
    public class SimleCalculatorLogicTests
    {
        [Fact]
        public void CalculateRevitonsPerMinuteTest()
        {
            // Arrange
            var logic = new SimpleCalculatorLogic();
            double cuttingSpeed = 100;
            double diameter = 10;
            double expected = 3183.098861837907;
            // Act
            double actual = logic.CalculateRevitonsPerMinute(cuttingSpeed, diameter);
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateMillingFeedTest()
        {
            // Arrange
            var logic = new SimpleCalculatorLogic();
            double feedPerTooth = 0.1;
            int teeth = 2;
            double revolutionsPerMinute = 1000;
            double expected = 200;
            // Act
            double actual = logic.CalculateMillingFeed(feedPerTooth, teeth, revolutionsPerMinute);
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateDrillingFeedTest()
        {
            // Arrange
            var logic = new SimpleCalculatorLogic();
            double feedPerRevolution = 0.1;
            double revolutionsPerMinute = 1000;
            double expected = 100;
            // Act
            double actual = logic.CalculateDrillingFeed(feedPerRevolution, revolutionsPerMinute);
            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
