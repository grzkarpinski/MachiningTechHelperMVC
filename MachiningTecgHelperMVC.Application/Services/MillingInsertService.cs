using AutoMapper;
using AutoMapper.QueryableExtensions;
using MachiningTechelperMVC.Application.Interfaces;
using MachiningTechelperMVC.Application.ViewModels.MillingInsert;
using MachiningTechHelperMVC.Domain.Interfaces;

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

        public ListMillingInsertVm GetAllMillingInserts(int pageSize, int? pageNo, string searchString)
        {
            var millingInserts = _millingInsertRepository.GetAllMillingInserts()
                .ProjectTo<MillingInsertVm>(_mapper.ConfigurationProvider)
                .ToList()
                .Where(p => p.Designation.ToLower().Contains(searchString.ToLower()))
                .ToList();

            var millingInsertsToShow = millingInserts.Skip((int)((pageNo - 1) * pageSize)).Take(pageSize).ToList();
            var millingInsertList = new ListMillingInsertVm()
            {
                PageSize = pageSize,
                CurrentPage = (int)pageNo,
                SearchString = searchString,
                MillingInserts = millingInsertsToShow,
                Count = millingInserts.Count
            };

            return millingInsertList;
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
