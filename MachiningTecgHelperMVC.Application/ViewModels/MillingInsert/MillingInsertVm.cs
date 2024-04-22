using MachiningTechelperMVC.Application.ViewModels.MillingInsertParametersRange;
using MachiningTechHelperMVC.Application.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechelperMVC.Application.ViewModels.MillingInsert
{
    public class MillingInsertVm : IMapFrom<MachiningTechHelperMVC.Domain.Model.MillingInsert>
    {
        public int Id { get; set; }
        [Display(Name = "Oznaczenie")]
        public string Designation { get; set; }
        [Display(Name = "R Płytki")]
        public double Radius { get; set; }

        public List<MillingInsertParametersRangeVm>? millingInsertParametersRanges { get; set; }

        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<MachiningTechHelperMVC.Domain.Model.MillingInsert, MillingInsertVm>()
                .ForMember(dest => dest.millingInsertParametersRanges, opt => opt.MapFrom(src => src.MillingInsertParametersRanges));
        }
    }
}
