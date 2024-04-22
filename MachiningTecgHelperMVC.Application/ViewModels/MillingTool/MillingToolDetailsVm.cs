using MachiningTechelperMVC.Application.ViewModels.MillingInsert;
using MachiningTechelperMVC.Application.ViewModels.MillingToolCheckedParameters;
using MachiningTechelperMVC.Application.ViewModels.Producer;
using MachiningTechHelperMVC.Application.Mapping;
using MachiningTechHelperMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechelperMVC.Application.ViewModels.MillingTool
{
    public class MillingToolDetailsVm : IMapFrom<MachiningTechHelperMVC.Domain.Model.MillingTool>
    {
        public int Id { get; set; }
        public double Diameter { get; set; }
        public double TeethNumber { get; set; }
        public string Designation { get; set; }
        public string Description { get; set; }
        public string ToolType { get; set; }
        public bool IsToolActive { get; set; }

        public int? ProducerId { get; set; }
        public ProducerVm? Producer { get; set; }

        public List<MillingInsertVm> millingInserts { get; set; }
        public List<MillingToolCheckedParametersVm> MillingToolCheckedParameters { get; set; }

        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<MachiningTechHelperMVC.Domain.Model.MillingTool, MillingToolDetailsVm>()
                .ForMember(dest => dest.Producer, opt => opt.MapFrom(src => src.Producer));
        }
    }
}
