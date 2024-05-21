using AutoMapper;
using MachiningTechelperMVC.Application.Interfaces;
using MachiningTechelperMVC.Application.ViewModels.SolidMillingToolParametersRange;
using MachiningTechHelperMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechelperMVC.Application.Services
{
    public class SolidMillingToolParametersRangeService : ISolidMillingToolParametersRangeService
    {
        private readonly ISolidMillingToolParametersRangeRepository _solidMillingToolParametersRangeRepository;
        private readonly IMapper _mapper;

        public SolidMillingToolParametersRangeService(ISolidMillingToolParametersRangeRepository solidMillingToolParametersRangeRepository, IMapper mapper)
        {
            _solidMillingToolParametersRangeRepository = solidMillingToolParametersRangeRepository;
            _mapper = mapper;
        }

        public int AddSolidMillingToolParametersRange(SolidMillingToolParametersRangeVm solidMillingToolParametersRange)
        {
            var solidMillingToolParametersRangeToAdd = _mapper.Map<MachiningTechHelperMVC.Domain.Model.SolidMillingToolParametersRange>(solidMillingToolParametersRange);
            var id = _solidMillingToolParametersRangeRepository.AddSolidMillingToolParametersRange(solidMillingToolParametersRangeToAdd);
            return id;
        }

        public void DeleteSolidMillingToolParametersRange(int id)
        {
            _solidMillingToolParametersRangeRepository.DeleteSolidMillingToolParametersRange(id);
        }

        public SolidMillingToolParametersRangeVm GetSolidMillingToolParametersForEdit(int id)
        {
            var solidMillingToolParametersRange = _solidMillingToolParametersRangeRepository.GetSolidMillingToolParametersRangeById(id);
            var solidMillingToolParametersRangeVm = _mapper.Map<SolidMillingToolParametersRangeVm>(solidMillingToolParametersRange);
            return solidMillingToolParametersRangeVm;
        }

        public SolidMillingToolParametersRangeListVm GetSolidMillingToolParametersRange()
        {
            var solidMillingToolParametersRanges = _solidMillingToolParametersRangeRepository.GetAllSolidMillingToolParametersRanges();
            var solidMillingToolParametersRangesVm = new SolidMillingToolParametersRangeListVm()
            {
                SolidMillingToolParametersRanges = _mapper.Map<List<SolidMillingToolParametersRangeVm>>(solidMillingToolParametersRanges),
                Count = solidMillingToolParametersRanges.Count()
            };
            return solidMillingToolParametersRangesVm;
        }

        public void UpdateSolidMillingToolParametersRange(SolidMillingToolParametersRangeVm solidMillingToolParametersRange)
        {
            var solidMillingToolParametersRangeToUpdate = _mapper.Map<MachiningTechHelperMVC.Domain.Model.SolidMillingToolParametersRange>(solidMillingToolParametersRange);
            _solidMillingToolParametersRangeRepository.UpdateSolidMillingToolParametersRange(solidMillingToolParametersRangeToUpdate);
        }
    }
}
