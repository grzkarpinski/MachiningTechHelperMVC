using AutoMapper;
using MachiningTechelperMVC.Application.Interfaces;
using MachiningTechelperMVC.Application.ViewModels.MillingToolCheckedParameters;
using MachiningTechelperMVC.Application.ViewModels.SolidMillingToolCheckedParameters;
using MachiningTechHelperMVC.Domain.Interfaces;
using MachiningTechHelperMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechelperMVC.Application.Services
{
    public class SolidMillingToolCheckedParametersService : ISolidMillingToolCheckedParametersService
    {
        private readonly ISolidMillingToolCheckedParametersRepository _solidMillingToolCheckedParametersRepo;
        private readonly IMapper _mapper;

        public SolidMillingToolCheckedParametersService(ISolidMillingToolCheckedParametersRepository solidMillingToolCheckedParametersRepo, IMapper mapper)
        {
            _solidMillingToolCheckedParametersRepo = solidMillingToolCheckedParametersRepo;
            _mapper = mapper;
        }
        public int AddMillingToolCheckedParameters(MillingToolCheckedParametersVm millingToolCheckedParameters)
        {
            var solidMillingToolCheckedParametersToAdd = _mapper.Map<SolidMillingToolCheckedParameters>(millingToolCheckedParameters);
            var id = _solidMillingToolCheckedParametersRepo.AddSolidMillingToolCheckedParameters(solidMillingToolCheckedParametersToAdd);
            return id;
        }

        public void DeleteSolidMillingToolCheckedParameters(int solidMillingToolid)
        {
            _solidMillingToolCheckedParametersRepo.DeleteSolidMillingToolCheckedParameters(solidMillingToolid);
        }

        public ListMillingToolCheckedParametersVm GetAllMillingToolCheckedParameters(int solidMillingToolid)
        {
            var solidMillingToolCheckedParameters = _solidMillingToolCheckedParametersRepo.GetSolidMillingToolCheckedParametersbyTool(solidMillingToolid);
            var solidMillingToolCheckedParametersVm = new ListMillingToolCheckedParametersVm()
            {
                MillingToolCheckedParameters = _mapper.Map<List<MillingToolCheckedParametersVm>>(solidMillingToolCheckedParameters),
                Count = solidMillingToolCheckedParameters.Count()
            };
            return solidMillingToolCheckedParametersVm;
        }

        public SolidMillingToolCheckedParametersVm GetSolidMillingToolCheckedParametersById(int solidMillingToolid)
        {
            var solidMillingToolCheckedParameters = _solidMillingToolCheckedParametersRepo.GetSolidMillingToolCheckedParametersById(solidMillingToolid);
            var solidMillingToolCheckedParametersVm = _mapper.Map<SolidMillingToolCheckedParametersVm>(solidMillingToolCheckedParameters);
            return solidMillingToolCheckedParametersVm;
        }

        public SolidMillingToolCheckedParametersVm GetSolidMillingToolCheckedParametersForEdit(int solidMillingToolid)
        {
            var solidMillingToolCheckedParameters = _solidMillingToolCheckedParametersRepo.GetSolidMillingToolCheckedParametersById(solidMillingToolid);
            var solidMillingToolCheckedParametersVm = _mapper.Map<SolidMillingToolCheckedParametersVm>(solidMillingToolCheckedParameters);
            return solidMillingToolCheckedParametersVm;
        }

        public void UpdateSolidMillingToolCheckedParameters(SolidMillingToolCheckedParametersVm solidMillingToolCheckedParameters)
        {
            var solidMillingToolCheckedParametersToUpdate = _mapper.Map<SolidMillingToolCheckedParameters>(solidMillingToolCheckedParameters);
            _solidMillingToolCheckedParametersRepo.UpdateSolidMillingToolCheckedParameters(solidMillingToolCheckedParametersToUpdate);
        }
    }
}
