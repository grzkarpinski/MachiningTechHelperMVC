using AutoMapper;
using MachiningTechelperMVC.Application.Interfaces;
using MachiningTechelperMVC.Application.ViewModels.DrillCheckedParameters;
using MachiningTechHelperMVC.Domain.Interfaces;
using MachiningTechHelperMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechelperMVC.Application.Services
{
    public class DrillCheckedParametersService : IDrillCheckedParametersService
    {
        private readonly IDrillCheckedParametersRepository _drillCheckedParametersRepo;
        private readonly IMapper _mapper;

        public DrillCheckedParametersService(IDrillCheckedParametersRepository drillCheckedParametersRepo, IMapper mapper)
        {
            _drillCheckedParametersRepo = drillCheckedParametersRepo;
            _mapper = mapper;
        }
        public int AddDrillCheckedParameters(DrillCheckedParametersVm drillCheckedParameters)
        {
            var drillCheckedParametersToAdd = _mapper.Map<DrillCheckedParameters>(drillCheckedParameters);
            var id = _drillCheckedParametersRepo.AddDrillCheckedParameters(drillCheckedParametersToAdd);
            return id;
        }

        public void DeleteDrillCheckedParameters(int drillCheckedParametersId)
        {
            _drillCheckedParametersRepo.DeleteDrillCheckedParameters(drillCheckedParametersId);
        }

        public ListDrillCheckedParametersVm GetAllDrillCheckedParameters(int drillId)
        {
            var drillCheckedParameters = _drillCheckedParametersRepo.GetDrillCheckedParametersbyTool(drillId);
            var drillCheckedParametersVm = new ListDrillCheckedParametersVm()
            {
                DrillCheckedParameters = _mapper.Map<List<DrillCheckedParametersVm>>(drillCheckedParameters),
                Count = drillCheckedParameters.Count()
            };
            return drillCheckedParametersVm;
        }

        public DrillCheckedParametersVm GetDrillCheckedParametersById(int drillCheckedParametersId)
        {
            var drillCheckedParameters = _drillCheckedParametersRepo.GetDrillCheckedParametersById(drillCheckedParametersId);
            var drillCheckedParametersVm = _mapper.Map<DrillCheckedParametersVm>(drillCheckedParameters);
            return drillCheckedParametersVm;
        }

        public DrillCheckedParametersVm GetDrillCheckedParametersForEdit(int id)
        {
            var drillCheckedParameters = _drillCheckedParametersRepo.GetDrillCheckedParametersById(id);
            var drillCheckedParametersVm = _mapper.Map<DrillCheckedParametersVm>(drillCheckedParameters);
            return drillCheckedParametersVm;
        }

        public void UpdateDrillCheckedParameters(DrillCheckedParametersVm drillCheckedParameters)
        {
            var drillCheckedParametersToUpdate = _mapper.Map<MachiningTechHelperMVC.Domain.Model.DrillCheckedParameters>(drillCheckedParameters);
            _drillCheckedParametersRepo.UpdateDrillCheckedParameters(drillCheckedParametersToUpdate);
        }
    }
}
