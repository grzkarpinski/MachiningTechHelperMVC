using MachiningTechelperMVC.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Domain.Calculators
{
    public class SimpleCalculatorLogic : ISimpleCalculatorLogic
    {
        public double CalculateRevitonsPerMinute(double cuttingSpeed, double diameter)
        {
            return cuttingSpeed / (Math.PI * diameter);
        }

        public double CalculateMillingFeed(double feedPerTooth, int teeth, double revolutionsPerMinute)
        {
            return feedPerTooth * teeth * revolutionsPerMinute;
        }

        public double CalculateDrillingFeed(double feedPerRevolution, double revolutionsPerMinute)
        {
            return feedPerRevolution * revolutionsPerMinute;
        }
    }
}
