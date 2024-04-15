using MachiningTechelperMVC.Application.Interfaces;
using MachiningTechelperMVC.Application.ViewModels.CostEstimation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechelperMVC.Application.Services
{
    public class CostEstimationLogic : ICostEstimationLogic
    {
        public CostEstimationVm CalculateCosts(CostEstimationVm model)
        {
            model.TPZCosts = TimeCosts(model.MachineTypes, model.TPZTimes);
            model.TJCosts = TimeCosts(model.MachineTypes, model.TJTimes);

            model.TotalTPZCost = model.TPZCosts.Sum();
            model.TotalTJCost = model.TJCosts.Sum();

            return model;
        }

        public List<decimal?> TimeCosts(List<string> machineType, List<decimal?> times)
        {
            List<decimal?> costs = new List<decimal?>();

            for (int i = 0; i < times.Count; i++)
            {
                if (times[i].HasValue && machineType[i] != null)
                {
                    decimal cost = times[i].Value / 60 * MachineCostsConfig.MachineCosts[machineType[i]];
                    costs.Add(Math.Round(cost, 2));
                }
                else
                {
                    costs.Add(null);
                }
            }

            return costs;
        }
    }
}
