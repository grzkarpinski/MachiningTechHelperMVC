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
    public class MillingInsertService : IMillingInsertService
    {
        private readonly IMillingInsertRepository _millingInsertRepository;
        private readonly IMapper _mapper;

        public MillingInsertService(IMillingInsertRepository millingInsertRepository, IMapper mapper)
        {
            _millingInsertRepository = millingInsertRepository;
            _mapper = mapper;
        }

        public ListMillingInsertVm GetAllMillingInserts()
        {
            var inserts = _millingInsertRepository.GetAllMillingInserts();
            var insertVm = new ListMillingInsertVm()
            {
                Inserts = _mapper.Map<List<MillingInsertVm>>(inserts),
                Count = inserts.Count()
            };
            return insertVm;
        }

        public int AddMillingInsert(MillingInsertVm millingInsert)
        {
            var millingInsertToAdd = _mapper.Map<MachiningTechHelperMVC.Domain.Model.MillingInsert>(millingInsert);
            var id = _millingInsertRepository.AddMillingInsert(millingInsertToAdd);
            return id;
        }

        public void DeleteMillingInsert(int millingInsertId)
        {
            _millingInsertRepository.DeleteMillingInsert(millingInsertId);
        }

        public MillingInsertVm GetMillingInsertById(int millingInsertId)
        {
            var millingInsert = _millingInsertRepository.GetMillingInsertById(millingInsertId);
            var millingInsertVm = _mapper.Map<MillingInsertVm>(millingInsert);
            return millingInsertVm;
        }

    }
}
