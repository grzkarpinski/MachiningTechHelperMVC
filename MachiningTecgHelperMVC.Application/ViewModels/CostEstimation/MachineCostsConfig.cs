using System.Collections.Generic;

namespace MachiningTechelperMVC.Application.ViewModels.CostEstimation
{
    public static class MachineCostsConfig
    {
        public static Dictionary<string, decimal> MachineCosts { get; } = new Dictionary<string, decimal>
        {
            { "Grupa1", 110 },
            { "Grupa2", 120 },
            { "Grupa4", 120 },
            { "Grupa5", 120 },
            { "Grupa6", 140 },
            { "Grupa7", 180 },
            { "Grupa8", 140 },
            { "Grupa10", 220 },
            { "Grupa16", 220 },
            { "Grupa17", 90 }
        };
    }
}
