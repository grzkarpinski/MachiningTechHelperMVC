using MachiningTechHelperMVC.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechelperMVC.Application.ViewModels.DrillCheckedParameters
{
    public class DrillCheckedParametersVm : IMapFrom<MachiningTechHelperMVC.Domain.Model.DrillCheckedParameters>
    {
        public int Id { get; set; }
        public string Material { get; set; }
        public int RevisionsPerMinute { get; set; }
        public int FeedPerMinute { get; set; }
        public int DrillId { get; set; }
        public string DrillName { get; set; }
        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<MachiningTechHelperMVC.Domain.Model.DrillCheckedParameters, DrillCheckedParametersVm>().ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
