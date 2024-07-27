using AutoMapper;
using FluentValidation;
using MachiningTechHelperMVC.Application.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechelperMVC.Application.ViewModels.DrillParametersRange
{
    public class DrillParametersRangeVm : IMapFrom<MachiningTechHelperMVC.Domain.Model.DrillParametersRange>
    {
        public int Id { get; set; }
        public int DrillId { get; set; }
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
        [Display(Name = "Posuw na obrót min mm/rev")]
        public double FeedPerRevisionMinimum { get; set; }
        [Display(Name = "Posuw na obrót max mm/rev")]
        public double FeedPerRevisionMaximum { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MachiningTechHelperMVC.Domain.Model.DrillParametersRange, DrillParametersRangeVm>().ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }

    }

    public class DrillParametersRangeValidation : AbstractValidator<DrillParametersRangeVm>
    {
        public DrillParametersRangeValidation()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.DrillId).NotNull();
            RuleFor(x => x.GradeName).NotEmpty();
            RuleFor(x => x.Material).NotEmpty();
            RuleFor(x => x.CuttingSpeedMinimum).GreaterThan(0);
            RuleFor(x => x.CuttingSpeedMaximum).GreaterThanOrEqualTo(x => x.CuttingSpeedMinimum);
            RuleFor(x => x.FeedPerRevisionMinimum).GreaterThan(0);
            RuleFor(x => x.FeedPerRevisionMaximum).GreaterThanOrEqualTo(x => x.FeedPerRevisionMinimum);
        }
    }
}
