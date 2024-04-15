using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechelperMVC.Application.ViewModels.CostEstimation
{
    public class CostEstimationVm
    {
        public List<string> MachineTypes { get; set; } = new List<string>();
        public List<decimal?> TPZTimes { get; set; } = new List<decimal?>();
        public List<decimal?> TJTimes { get; set; } = new List<decimal?>();

        // results
        public List<decimal?> TPZCosts { get; set; } = new List<decimal?>();
        public List<decimal?> TJCosts { get; set; } = new List<decimal?>();
        public decimal? TotalTPZCost { get; set; }
        public decimal? TotalTJCost { get; set; }
    }
}
