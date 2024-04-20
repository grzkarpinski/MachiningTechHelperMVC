using MachiningTechelperMVC.Application.ViewModels.Producer;
using MachiningTechelperMVC.Application.ViewModels.SolidMillingToolCheckedParameters;
using MachiningTechelperMVC.Application.ViewModels.SolidMillingToolParametersRange;
using MachiningTechHelperMVC.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechelperMVC.Application.ViewModels.SolidMillingTool
{
    public class SolidMillingToolDetailsVm : IMapFrom<MachiningTechHelperMVC.Domain.Model.SolidMillingTool>
    {
        public int Id { get; set; }
        public double Diameter { get; set; }
        public double TeethNumber { get; set; }
        public double Radius { get; set; }
        public int Lcut { get; set; }
        public string Designation { get; set; }
        public string Description { get; set; }
        public string ToolType { get; set; }
        public bool IsToolActive { get; set; }

        public int? ProducerId { get; set; }
        public ProducerVm? Producer { get; set; }

        public List<SolidMillingToolParametersRangeVm>? SolidMillingToolParametersRanges { get; set; }

        public List<SolidMillingToolCheckedParametersVm>? SolidMillingToolCheckedParameters { get; set; }

        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<MachiningTechHelperMVC.Domain.Model.SolidMillingTool, SolidMillingToolDetailsVm>()
                .ForMember(dest => dest.Producer, opt => opt.MapFrom(src => src.Producer))
                .ForMember(dest => dest.SolidMillingToolParametersRanges, opt => opt.MapFrom(src => src.SolidMillingToolParametersRanges))
                .ForMember(d => d.SolidMillingToolCheckedParameters, opt => opt.MapFrom(src => src.SolidMillingToolCheckedParameters));
        }
    }
}
