using MachiningTechelperMVC.Application.ViewModels.CostEstimation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechelperMVC.Application.Interfaces
{
    public interface ICostEstimationLogic
    {
        CostEstimationVm CalculateCosts(CostEstimationVm model);
        List<decimal> TimeCosts(List<decimal> Costs); // Do this method need more arguments?
    }
}
