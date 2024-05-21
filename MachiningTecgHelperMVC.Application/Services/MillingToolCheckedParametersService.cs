using AutoMapper;
using MachiningTechelperMVC.Application.Interfaces;
using MachiningTechelperMVC.Application.ViewModels.MillingToolCheckedParameters;
using MachiningTechHelperMVC.Domain.Interfaces;
using MachiningTechHelperMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechelperMVC.Application.Services
{
    public class MillingToolCheckedParametersService : IMillingToolCheckedParametersService
    {
        private readonly IMillingToolCheckedParametersRepository _millingToolCheckedParametersRepo;
        private readonly IMapper _mapper;

        public MillingToolCheckedParametersService(IMillingToolCheckedParametersRepository millingToolCheckedParametersRepo, IMapper mapper)
        {
            _millingToolCheckedParametersRepo = millingToolCheckedParametersRepo;
            _mapper = mapper;
        }
        public int AddMillingToolCheckedParameters(MillingToolCheckedParametersVm checkedParameters)
        {
            var checkedParametersToAdd = _mapper.Map<MillingToolCheckedParameters>(checkedParameters);
            var id = _millingToolCheckedParametersRepo.AddMillingToolCheckedParameters(checkedParametersToAdd);
            return id;
        }

        public void DeleteMillingToolCheckedParameters(int id)
        {
            _millingToolCheckedParametersRepo.DeleteMillingToolCheckedParameters(id);
        }

        public ListMillingToolCheckedParametersVm GetAllMillingToolCheckedParameters(int millingToolId)
        {
            var checkedParameters = _millingToolCheckedParametersRepo.GetMillingToolCheckedParametersbyTool(millingToolId);
            var checkedParametersVm = new ListMillingToolCheckedParametersVm()
            {
                MillingToolCheckedParameters = _mapper.Map<List<MillingToolCheckedParametersVm>>(checkedParameters),
                Count = checkedParameters.Count()
            };
            return checkedParametersVm;
        }

        public MillingToolCheckedParametersVm GetMillingToolCheckedParametersById(int milling)
        {
            var checkedParameters = _millingToolCheckedParametersRepo.GetMillingToolCheckedParametersById(milling);
            var checkedParametersVm = _mapper.Map<MillingToolCheckedParametersVm>(checkedParameters);
            return checkedParametersVm;
        }

        public MillingToolCheckedParametersVm GetMillingToolCheckedParametersForEdit(int id)
        {
            var checkedParameters = _millingToolCheckedParametersRepo.GetMillingToolCheckedParametersById(id);
            var checkedParametersVm = _mapper.Map<MillingToolCheckedParametersVm>(checkedParameters);
            return checkedParametersVm;
        }

        public void UpdateMillingToolCheckedParameters(MillingToolCheckedParametersVm millingToolCheckedParameters)
        {
            var checkedParametersToUpdate = _mapper.Map<MillingToolCheckedParameters>(millingToolCheckedParameters);
            _millingToolCheckedParametersRepo.UpdateMillingToolCheckedParameters(checkedParametersToUpdate);
        }
    }
}
