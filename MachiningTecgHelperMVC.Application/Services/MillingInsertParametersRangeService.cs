using AutoMapper;
using MachiningTechelperMVC.Application.Interfaces;
using MachiningTechelperMVC.Application.ViewModels.MillingInsertParametersRange;
using MachiningTechHelperMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechelperMVC.Application.Services
{
    public class MillingInsertParametersRangeService : IMillingInsertParametersRangeService
    {
        private readonly IMillingInsertParametersRangeRepository _millingInsertParametersRangeRepo;
        private readonly IMapper _mapper;
        public MillingInsertParametersRangeService(IMillingInsertParametersRangeRepository millingInsertParametersRangeRepo, IMapper mapper)
        {
            _millingInsertParametersRangeRepo = millingInsertParametersRangeRepo;
            _mapper = mapper;
        }

        public int AddMillingInsertParametersRange(MillingInsertParametersRangeVm millingInsertParametersRange)
        {
            var millingInsertParametersRangeToAdd = _mapper.Map<MachiningTechHelperMVC.Domain.Model.MillingInsertParametersRange>(millingInsertParametersRange);
            var id = _millingInsertParametersRangeRepo.AddMillingInsertParametersRange(millingInsertParametersRangeToAdd);
            return id;
        }
        public void DeleteMillingInsertParametersRange(int millingInsertParametersRangeId)
        {
            _millingInsertParametersRangeRepo.DeleteMillingInsertParametersRange(millingInsertParametersRangeId);
        }

        public MillingInsertParametersRangeListVm GetAllMillingInsertParametersRanges()
        {
            var millingInsertParametersRanges = _millingInsertParametersRangeRepo.GetAllMillingInsertParametersRanges();
            var millingInsertParametersRangesVm = new MillingInsertParametersRangeListVm()
            {
                MillingInsertParametersRanges = _mapper.Map<List<MillingInsertParametersRangeVm>>(millingInsertParametersRanges),
                Count = millingInsertParametersRanges.Count()
            };
            return millingInsertParametersRangesVm;
        }

        public MillingInsertParametersRangeVm GetMillingInsertParametersRangeById(int milling)
        {
            var millingInsertParametersRange = _millingInsertParametersRangeRepo.GetMillingInsertParametersRangeById(milling);
            var millingInsertParametersRangeVm = _mapper.Map<MillingInsertParametersRangeVm>(millingInsertParametersRange);
            return millingInsertParametersRangeVm;
        }

        public MillingInsertParametersRangeVm GetMillingInsertParametersRangeForEdit(int id)
        {
            var millingInsertParametersRange = _millingInsertParametersRangeRepo.GetMillingInsertParametersRangeById(id);
            var millingInsertParametersRangeVm = _mapper.Map<MillingInsertParametersRangeVm>(millingInsertParametersRange);
            return millingInsertParametersRangeVm;
        }

        public void UpdateMillingInsertParametersRange(MillingInsertParametersRangeVm millingInsertParametersRange)
        {
            var millingInsertParametersRangeToUpdate = _mapper.Map<MachiningTechHelperMVC.Domain.Model.MillingInsertParametersRange>(millingInsertParametersRange);
            _millingInsertParametersRangeRepo.UpdateMillingInsertParametersRange(millingInsertParametersRangeToUpdate);
        }
    }
}
