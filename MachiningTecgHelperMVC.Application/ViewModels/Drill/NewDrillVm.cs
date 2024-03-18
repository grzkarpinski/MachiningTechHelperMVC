using AutoMapper;
using FluentValidation;
using MachiningTechHelperMVC.Application.Mapping;
using MachiningTechHelperMVC.Domain.Model;
using MachiningTechHelperMVC.Domain.Model.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
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
		public IEnumerable<SelectListItem> ToolTypes { get; set; } // To use in dropdown list
		public bool IsToolActive { get; set; }
        public string LengthXDiameter { get; set; }
        public int TipAngle { get; set; }
        //public string Grade { get; set; }  // DELETE
        //public string Producer { get; set; } // DELETE

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewDrillVm, Domain.Model.Drill>()
            .ForMember(dest => dest.ToolType, opt => opt.MapFrom(src => (ToolType)Enum.Parse(typeof(ToolType), src.ToolType)))
            .ReverseMap();
        }
    }

    public class NewDrillValidation: AbstractValidator<NewDrillVm> 
    {
        public NewDrillValidation() 
        {
            RuleFor(x=> x.Id).NotNull();
            RuleFor(x=> x.Diameter).GreaterThan(0);
            RuleFor(x=> x.Designation).NotEmpty();
            RuleFor(x=> x.Description).NotEmpty();
            RuleFor(x=> x.ToolType).NotEmpty();
            RuleFor(x=> x.LengthXDiameter).NotEmpty();
            RuleFor(x=> x.TipAngle).GreaterThan(0);
        }
    }
}
