using AutoMapper;
using MachiningTechelperMVC.Application.Interfaces;
using MachiningTechelperMVC.Application.ViewModels.MillingInsert;
using MachiningTechHelperMVC.Domain.Interfaces;
using MachiningTechHelperMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechelperMVC.Application.Services
{
    internal class MillingToolMillingInsertService : IMillingToolMillingInsertService
    {
        private readonly IMillingToolMillingInsertRepository _millingToolMillingInsertRepo;
        private readonly IMapper _mapper;

        public MillingToolMillingInsertService(IMillingToolMillingInsertRepository millingToolMillingInsertRepo, IMapper mapper)
        {
            _millingToolMillingInsertRepo = millingToolMillingInsertRepo;
            _mapper = mapper;
        }

        public void AddMillingToolInsert(int millingToolId, int millingInsertId)
        {
            var millingToolMillingInsert = new MillingToolMillingInsert
            {
                MillingToolId = millingToolId,
                MillingInsertId = millingInsertId
            };
            _millingToolMillingInsertRepo.Add(millingToolMillingInsert);
        }

        public void DeleteMillingToolInsert(int millingToolId, int millingInsertId)
        {
            var millingToolMillingInsert = _millingToolMillingInsertRepo.GetById(millingToolId, millingInsertId);
            _millingToolMillingInsertRepo.Delete(millingToolMillingInsert);
        }

        public MillingInsertVm GetMillingToolInsert(int millingToolId, int millingInsertId)
        {
            var millingToolMillingInsert = _millingToolMillingInsertRepo.GetById(millingToolId, millingInsertId);
            var millingInsertVm = _mapper.Map<MillingInsertVm>(millingToolMillingInsert.MillingInsert);
            return millingInsertVm;
        }
    }
}
