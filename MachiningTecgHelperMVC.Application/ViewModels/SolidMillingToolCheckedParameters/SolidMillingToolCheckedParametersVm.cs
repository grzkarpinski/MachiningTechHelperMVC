using MachiningTechHelperMVC.Application.Mapping;
using System.ComponentModel.DataAnnotations;

namespace MachiningTechelperMVC.Application.ViewModels.SolidMillingToolCheckedParameters
{
    public class SolidMillingToolCheckedParametersVm : IMapFrom<MachiningTechHelperMVC.Domain.Model.SolidMillingToolCheckedParameters>
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
        public int SolidMillingToolId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<MachiningTechHelperMVC.Domain.Model.SolidMillingToolCheckedParameters, SolidMillingToolCheckedParametersVm>().ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
