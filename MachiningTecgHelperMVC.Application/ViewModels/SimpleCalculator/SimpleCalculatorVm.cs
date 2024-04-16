using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechelperMVC.Application.ViewModels.SimpleCalculator
{
    public class SimpleCalculatorVm
    {
        public bool IsMilling { get; set; }
        [Display(Name = "Vc (m/min)")]
        public double CuttingSpeed { get; set; }
        [Display(Name = "Średnica (mm)")]
        public double Diameter { get; set; }
        [Display(Name = "fz (mm/ząb)")]
        public double FeedPerTooth { get; set; }
        [Display(Name = "fn (mm/obr)")]
        public double FeedPerRevolution { get; set; }
        [Display(Name = "Z")]
        public int Teeth { get; set; }

        // results
        [Display(Name = "Obroty(obr/min)")]
        public int RevolutionsPerMinute { get; set; }
        [Display(Name = "Posuw(mm/min)")]
        public int FeedPerMinute { get; set; }
    }
}
