using MachiningTechelperMVC.Application.ViewModels.SimpleCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechelperMVC.Application.Interfaces
{
    public interface ISimpleCalculatorLogic
    {
        SimpleCalculatorVm Calculate(SimpleCalculatorVm model);
		double CalculateRevitonsPerMinute(double cuttingSpeed, double diameter);
        double CalculateMillingFeed(double feedPerTooth, int teeth, double revolutionsPerMinute);
        double CalculateDrillingFeed(double feedPerRevolution, double revolutionsPerMinute);
    }
}
