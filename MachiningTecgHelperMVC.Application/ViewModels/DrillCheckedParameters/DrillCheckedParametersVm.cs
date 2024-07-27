using FluentValidation;
using MachiningTechHelperMVC.Application.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechelperMVC.Application.ViewModels.DrillCheckedParameters
{
    public class DrillCheckedParametersVm : IMapFrom<MachiningTechHelperMVC.Domain.Model.DrillCheckedParameters>
    {
        public int Id { get; set; }
        [Display(Name = "Uwagi")]
        public string? Comment { get; set; }
        [Display(Name = "Materiał")]
        public string? Material { get; set; }
        [Display(Name = "Obroty obr/min")]
        public int RevisionsPerMinute { get; set; }
        [Display(Name = "Posuw mm/min")]
        public int FeedPerMinute { get; set; }
        public int DrillId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<MachiningTechHelperMVC.Domain.Model.DrillCheckedParameters, DrillCheckedParametersVm>().ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }

    public class DrillCheckedParametersValidation : AbstractValidator<DrillCheckedParametersVm>
    {
        public DrillCheckedParametersValidation()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Material).NotEmpty();
            RuleFor(x => x.RevisionsPerMinute).GreaterThan(0);
            RuleFor(x => x.FeedPerMinute).GreaterThan(0);
            RuleFor(x => x.DrillId).NotNull();
        }
    }
}
