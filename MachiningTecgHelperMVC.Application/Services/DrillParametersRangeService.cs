using AutoMapper;
using MachiningTechelperMVC.Application.Interfaces;
using MachiningTechelperMVC.Application.ViewModels.DrillParametersRange;
using MachiningTechHelperMVC.Domain.Interfaces;

namespace MachiningTechelperMVC.Application.Services
{
    public class DrillParametersRangeService : IDrillParametersRangeService
    {
        private readonly IDrillParametersRangeRepository _drillParametersRangeRepo;
        private readonly IMapper _mapper;

        public DrillParametersRangeService(IDrillParametersRangeRepository drillParametersRangeRepo, IMapper mapper)
        {
            _drillParametersRangeRepo = drillParametersRangeRepo;
            _mapper = mapper;
        }

        public int AddDrillParametersRange(DrillParametersRangeVm drillParametersRange)
        {
            var drillParametersRangeToAdd = _mapper.Map<MachiningTechHelperMVC.Domain.Model.DrillParametersRange>(drillParametersRange);
            var id = _drillParametersRangeRepo.AddDrillParametersRange(drillParametersRangeToAdd);
            return id;
        }

        public void DeleteDrillParametersRange(int drillParametersRangeId)
        {
            _drillParametersRangeRepo.DeleteDrillParametersRange(drillParametersRangeId);
        }

        public ListDrillParametersRangeListVm GetAllDrillParametersRanges()
        {
            var drillParametersRanges = _drillParametersRangeRepo.GetAllDrillParametersRanges();
            var drillParametersRangesVm = new ListDrillParametersRangeListVm()
            {
                DrillParametersRanges = _mapper.Map<List<DrillParametersRangeVm>>(drillParametersRanges),
                Count = drillParametersRanges.Count()
            };
            return drillParametersRangesVm;
        }

        public DrillParametersRangeVm GetDrillParametersRangeById(int drillParametersRangeId)
        {
            var drillParametersRange = _drillParametersRangeRepo.GetDrillParametersRangeById(drillParametersRangeId);
            var drillParametersRangeVm = _mapper.Map<DrillParametersRangeVm>(drillParametersRange);
            return drillParametersRangeVm;
        }

        public DrillParametersRangeVm GetDrillParametersRangeForEdit(int id)
        {
            var drillParametersRange = _drillParametersRangeRepo.GetDrillParametersRangeById(id);
            var drillParametersRangeVm = _mapper.Map<DrillParametersRangeVm>(drillParametersRange);
            return drillParametersRangeVm;
        }

        public void UpdateDrillParametersRange(DrillParametersRangeVm drillParametersRange)
        {
            var drillParametersRangeToUpdate = _mapper.Map<MachiningTechHelperMVC.Domain.Model.DrillParametersRange>(drillParametersRange);
            _drillParametersRangeRepo.UpdateDrillParametersRange(drillParametersRangeToUpdate);
        }
    }
}
