using AutoMapper;
using MachiningTechelperMVC.Application.ViewModels.Producer;
using MachiningTechHelperMVC.Application.Mapping;
using MachiningTechHelperMVC.Domain.Model.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechelperMVC.Application.ViewModels.MillingTool
{
    public class NewMillingToolVm : IMapFrom<MachiningTechHelperMVC.Domain.Model.MillingTool>
    {
        public int Id { get; set; }
        public double Diameter { get; set; }
        public string Designation { get; set; }
        public string Description { get; set; }
        public string ToolType { get; set; }
        public IEnumerable<SelectListItem> ToolTypes { get; set; } // To use in dropdown list
        public bool IsToolActive { get; set; }

        public ProducerVm NewProducer { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewMillingToolVm, MachiningTechHelperMVC.Domain.Model.MillingTool>()
            .ForMember(dest => dest.ToolType, opt => opt.MapFrom(src => (ToolType)Enum.Parse(typeof(ToolType), src.ToolType)))
            .ForMember(dest => dest.Producer, opt => opt.MapFrom(src => src.NewProducer))
            .ReverseMap();
        }
    }
}
