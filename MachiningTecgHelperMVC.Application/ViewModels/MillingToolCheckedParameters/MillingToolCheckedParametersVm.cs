using MachiningTechelperMVC.Application.ViewModels.MillingInsert;
using MachiningTechHelperMVC.Application.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechelperMVC.Application.ViewModels.MillingToolCheckedParameters
{
    public class MillingToolCheckedParametersVm : IMapFrom<MachiningTechHelperMVC.Domain.Model.MillingToolCheckedParameters>
    {
        public int Id { get; set; }
        public int MillingToolId { get; set; }
        [Display(Name = "Uwagi")]
        public string? Comment { get; set; }
        [Display(Name = "Materiał")]
        public string? Material { get; set; }
        [Display(Name = "Obroty obr/min")]
        public int RevisionsPerMinute { get; set; }
        [Display(Name = "Posuw mm/min")]
        public int FeedPerMinute { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }

        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<MachiningTechHelperMVC.Domain.Model.MillingToolCheckedParameters, MillingToolCheckedParametersVm>().ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
