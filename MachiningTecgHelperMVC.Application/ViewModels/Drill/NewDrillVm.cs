using AutoMapper;
using FluentValidation;
using MachiningTechelperMVC.Application.ViewModels.Producer;
using MachiningTechHelperMVC.Application.Mapping;
using MachiningTechHelperMVC.Domain.Model;
using MachiningTechHelperMVC.Domain.Model.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Application.ViewModels.Drill
{
    public class NewDrillVm : IMapFrom<Domain.Model.Drill>
    {
        public int Id { get; set; }
        [Display(Name = "Średnica mm")]
        public double Diameter { get; set; }
        [Display(Name = "Symbol")]
        public string Designation { get; set; }
        [Display(Name = "Opis")]
        public string Description { get; set; }
        [Display(Name = "Typ narzędzia")]
        public string ToolType { get; set; }
		public IEnumerable<SelectListItem> ToolTypes { get; set; } // To use in dropdown list
		public bool IsToolActive { get; set; }
        [Display(Name = "L x Średnica")]
        public string LengthXDiameter { get; set; }
        [Display(Name = "Kąt wierzchołka")]
        public int TipAngle { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }

        public ProducerVm NewProducer { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewDrillVm, Domain.Model.Drill>()
            .ForMember(dest => dest.ToolType, opt => opt.MapFrom(src => (ToolType)Enum.Parse(typeof(ToolType), src.ToolType)))
            .ForMember(dest => dest.Producer, opt => opt.MapFrom(src => src.NewProducer))
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
            RuleFor(x=> x.NewProducer).NotNull();
        }
    }
}
