using MachiningTechelperMVC.Application.ViewModels.Producer;
using MachiningTechelperMVC.Application.ViewModels.SolidMillingToolParametersRange;
using MachiningTechHelperMVC.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechelperMVC.Application.ViewModels.SolidMillingTool
{
    public class SolidMillingToolForListVm : IMapFrom<MachiningTechHelperMVC.Domain.Model.SolidMillingTool>
    {
        public int Id { get; set; }
        public double Diameter { get; set; }
        public int Lcut { get; set; }
        public string ToolType { get; set; }
        public string? Producer { get; set; }

        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<MachiningTechHelperMVC.Domain.Model.SolidMillingTool, SolidMillingToolForListVm>()
                .ForMember(d => d.Producer, opt => opt.MapFrom(s => s.Producer.CompanyName));
        }
    }
}
