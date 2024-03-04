using AutoMapper;
using MachiningTechHelperMVC.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Application.ViewModels.Drill
{
    public class DrillForListVm : IMapFrom<Domain.Model.Drill>
    {

        public int Id { get; set; }
        public double Diameter { get; set; }

        public string LengthXDiameter { get; set; }

        public string ToolType { get; set; }

        public string? Producer { get; set; }

        public void Mapping(Profile profile) 
        {
            profile.CreateMap<Domain.Model.Drill, DrillForListVm>()
                .ForMember(d => d.Producer, opt => opt.MapFrom(s => s.Producer.CompanyName));

        }
    }
}
