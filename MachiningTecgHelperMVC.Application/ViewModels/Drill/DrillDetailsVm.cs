using AutoMapper;
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
        public string? Producer { get; set; }
        public int TipAngle { get; set; }
        public string? Grade { get; set; }

        public List<DrillCheckedParametersVm>? DrillCheckedParameters;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Model.Drill, DrillDetailsVm>()
                .ForMember(d => d.Producer, opt => opt.MapFrom(s => s.Producer != null ? s.Producer.CompanyName : "Not linked yet"))
                .ForMember(d => d.Grade, opt => opt.MapFrom(s => s.Grade != null ? s.Grade.GradeName : "Not linked yet"))
                .ForMember(d => d.DrillCheckedParameters, opt => opt.Ignore()); // TO CHANGE!!!!
        }
    }
}
