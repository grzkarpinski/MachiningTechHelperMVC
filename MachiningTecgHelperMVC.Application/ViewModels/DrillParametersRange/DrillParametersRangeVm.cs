using AutoMapper;
using MachiningTechHelperMVC.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechelperMVC.Application.ViewModels.DrillParametersRange
{
    public class DrillParametersRangeVm : IMapFrom<MachiningTechHelperMVC.Domain.Model.DrillParametersRange>
    {
        public int Id { get; set; }
        public int DrillId { get; set; }
        public string GradeName { get; set; }
        public string Description { get; set; }
        public string Material { get; set; }
        public int CuttingSpeedMinimum { get; set; }
        public int CuttingSpeedMaximum { get; set; }
        public double FeedPerRevisionMinimum { get; set; }
        public double FeedPerRevisionMaximum { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MachiningTechHelperMVC.Domain.Model.DrillParametersRange, DrillParametersRangeVm>().ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }

    }
}
