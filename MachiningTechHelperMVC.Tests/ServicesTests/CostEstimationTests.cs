using MachiningTechelperMVC.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Tests.ServicesTests
{
    public class CostEstimationTests
    {
        [Fact]
        public void TimeCostsTest()
        {
            // Arrange
            var machineType = new List<string> { "Grupa1", "Grupa17" };
            var times = new List<decimal?> { 10, 100 };
            var expected = new List<decimal?> { 18.33m, 150.00m };

            // Act
            var result = new CostEstimationLogic().TimeCosts(machineType, times);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
