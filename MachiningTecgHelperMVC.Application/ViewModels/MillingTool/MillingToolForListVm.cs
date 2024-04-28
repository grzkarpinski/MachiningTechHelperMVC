using MachiningTechHelperMVC.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechelperMVC.Application.ViewModels.MillingTool
{
    public class MillingToolForListVm : IMapFrom<MachiningTechHelperMVC.Domain.Model.MillingTool>
    {
        public int Id { get; set; }
        public double Diameter { get; set; }
        public int TeethNumber { get; set; }
        public string ToolType { get; set; }
        public string? Producer { get; set; }

        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<MachiningTechHelperMVC.Domain.Model.MillingTool, MillingToolForListVm>()
                .ForMember(d => d.Producer, opt => opt.MapFrom(s => s.Producer.CompanyName));
        }
    }
}
