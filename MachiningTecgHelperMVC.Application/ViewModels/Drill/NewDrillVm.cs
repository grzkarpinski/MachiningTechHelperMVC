using AutoMapper;
using MachiningTechHelperMVC.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Application.ViewModels.Drill
{
    public class NewDrillVm : IMapFrom<Domain.Model.Drill>
    {
        public int Id { get; set; }
        public double Diameter { get; set; }
        public string Designation { get; set; }
        public string Description { get; set; }
        public string ToolType { get; set; }
        public bool IsToolActive { get; set; }

        public string LengthXDiameter { get; set; }
        public int TipAngle { get; set; }
        public string Grade { get; set; }
        public string Producer { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewDrillVm, Domain.Model.Drill>();
        }
    }
}
