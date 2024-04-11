using System.Collections.Generic;

namespace MachiningTechelperMVC.Application.ViewModels.CostEstimation
{
    public static class MachineCostsConfig
    {
        public static Dictionary<string, decimal> MachineCosts { get; } = new Dictionary<string, decimal>
        {
            { "Grupa1", 120 },
            { "Grupa2", 130 },
            { "Grupa4", 140 },
            { "Grupa5", 120 },
            { "Grupa6", 160 },
            { "Grupa7", 75 },
            { "Grupa9", 659 },
            { "Grupa10", 45 },
            { "Grupa16", 653 },
            { "Grupa17", 100 }
        };
    }
}
