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
    }
}
