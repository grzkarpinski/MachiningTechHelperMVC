using FluentValidation;
using MachiningTechHelperMVC.Application.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechelperMVC.Application.ViewModels.MillingInsertParametersRange
{
    public class MillingInsertParametersRangeVm : IMapFrom<MachiningTechHelperMVC.Domain.Model.MillingInsertParametersRange>
    {
        public int Id { get; set; }
        public int MillingInsertId { get; set; }
        [Display(Name = "Gatunek")]
        public string GradeName { get; set; }
        [Display(Name = "Opis")]
        public string? Description { get; set; }
        [Display(Name = "Materiał")]
        public string Material { get; set; }
        [Display(Name = "Prędkość skrawania min m/min")]
        public int CuttingSpeedMinimum { get; set; }
        [Display(Name = "Prędkość skrawania max m/min")]
        public int CuttingSpeedMaximum { get; set; }
        [Display(Name = "Posuw na ząb min mm/ Z")]
        public double FeedPerToothMinimum { get; set; }
        [Display(Name = "Posuw na ząb max mm/ Z")]
        public double FeedPerToothMaximum { get; set; }
    }

    public class MillingInsertParametersRangeValidation : AbstractValidator<MillingInsertParametersRangeVm>
    {
        public MillingInsertParametersRangeValidation()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.MillingInsertId).NotNull();
            RuleFor(x => x.GradeName).NotEmpty();
            RuleFor(x => x.Material).NotEmpty();
            RuleFor(x => x.CuttingSpeedMinimum).GreaterThan(0);
            RuleFor(x => x.CuttingSpeedMaximum).GreaterThanOrEqualTo(x => x.CuttingSpeedMinimum);
            RuleFor(x => x.FeedPerToothMinimum).GreaterThan(0);
            RuleFor(x => x.FeedPerToothMaximum).GreaterThanOrEqualTo(x => x.FeedPerToothMinimum);
        }
    }
}
