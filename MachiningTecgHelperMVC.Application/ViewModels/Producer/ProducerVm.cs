using AutoMapper;
using MachiningTechHelperMVC.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechelperMVC.Application.ViewModels.Producer // TYPO: MachiningTechelperMVC!!!!!
{
    public class ProducerVm: IMapFrom<MachiningTechHelperMVC.Domain.Model.Producer>
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MachiningTechHelperMVC.Domain.Model.Producer, ProducerVm>().ReverseMap();
        }
    }
}
