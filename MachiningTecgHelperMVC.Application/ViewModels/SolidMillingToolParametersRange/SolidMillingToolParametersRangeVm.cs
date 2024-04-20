using FluentValidation;
using MachiningTechHelperMVC.Application.Mapping;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechelperMVC.Application.ViewModels.SolidMillingToolParametersRange
{
    public class SolidMillingToolParametersRangeVm : IMapFrom<MachiningTechHelperMVC.Domain.Model.SolidMillingToolParametersRange>
    {
        public int Id { get; set; }
        public int SolidMillingToolId { get; set; }
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

    public class SolidMillingToolParametersRangeValidation : AbstractValidator<SolidMillingToolParametersRangeVm>
    {
        public SolidMillingToolParametersRangeValidation()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.SolidMillingToolId).NotNull();
            RuleFor(x => x.GradeName).NotEmpty();
            RuleFor(x => x.Material).NotEmpty();
            RuleFor(x => x.CuttingSpeedMinimum).GreaterThan(0);
            RuleFor(x => x.CuttingSpeedMaximum).GreaterThanOrEqualTo(x => x.CuttingSpeedMinimum);
            RuleFor(x => x.FeedPerToothMinimum).GreaterThan(0);
            RuleFor(x => x.FeedPerToothMaximum).GreaterThanOrEqualTo(x => x.FeedPerToothMinimum);
        }
    }
}
