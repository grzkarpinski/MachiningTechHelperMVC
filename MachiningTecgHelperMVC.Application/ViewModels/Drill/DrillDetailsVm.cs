using AutoMapper;
using MachiningTechelperMVC.Application.ViewModels.Producer;
using MachiningTechHelperMVC.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Application.ViewModels.Drill
{
    public class DrillDetailsVm : IMapFrom<MachiningTechHelperMVC.Domain.Model.Drill>
    {
        public int Id { get; set; }
        public double Diameter { get; set; }
        public string LengthXDiameter { get; set; }
        public string ToolType { get; set; }
        public string description { get; set; }
        public int TipAngle { get; set; }

        //producer
        public ProducerVm? Producer { get; set; }

        //to implement
        public string? Grade { get; set; }

        public List<DrillCheckedParametersVm>? DrillCheckedParameters;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Model.Drill, DrillDetailsVm>()
                .ForMember(dest => dest.Producer, opt => opt.MapFrom(src => src.Producer))
                .ForMember(d => d.Grade, opt => opt.Ignore()) // TO CHANGE!!!!
                .ForMember(d => d.DrillCheckedParameters, opt => opt.Ignore()); // TO CHANGE!!!!
        }
    }
}
