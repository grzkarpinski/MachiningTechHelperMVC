using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechelperMVC.Application.ViewModels.SimpleCalculator
{
    public class SimpleCalculatorVm
    {
        public bool? IsMilling { get; set; } // leave only IsMilling!!!
        public bool? IsDrilling { get; set; }
        public double CuttingSpeed { get; set; }
        public double Diameter { get; set; }
        public double FeedPerTooth { get; set; }
        public double FeedPerRevolution { get; set; }
        public int Teeth { get; set; }

        // results
        public int RevolutionsPerMinute { get; set; }
        public int FeedPerMinute { get; set; }
    }
}
