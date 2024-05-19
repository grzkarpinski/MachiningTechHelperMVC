using AutoMapper;
using AutoMapper.QueryableExtensions;
using MachiningTechelperMVC.Application.Interfaces;
using MachiningTechelperMVC.Application.ViewModels.SolidMillingTool;
using MachiningTechHelperMVC.Domain.Interfaces;

namespace MachiningTechelperMVC.Application.Services
{
    public class SolidMillingToolService : ISolidMillingToolService
    {
        private readonly ISolidMillingToolRepository _solidMillingToolRepo;
        private readonly IMapper _mapper;

        public SolidMillingToolService(ISolidMillingToolRepository solidMillingToolRepo, IMapper mapper)
        {
            _solidMillingToolRepo = solidMillingToolRepo;
            _mapper = mapper;
        }

        public int AddSolidMillingTool(NewSolidMillingToolVm solidMillingTool)
        {
            var solidMillingToolToAdd = _mapper.Map<MachiningTechHelperMVC.Domain.Model.SolidMillingTool>(solidMillingTool);
            var id = _solidMillingToolRepo.AddSolidMillingTool(solidMillingToolToAdd);
            return id;
        }

        public void DeleteSolidMillingTool(int id)
        {
            _solidMillingToolRepo.DeleteSolidMillingTool(id);
        }

        public ListSolidMillingToolForListVm GetAllSolidMillingToolsForList(int pageSize, int? pageNo, string searchString)
        {
            var solidMillingTools = _solidMillingToolRepo.GetAllSolidMillingTools()
                .ProjectTo<SolidMillingToolForListVm>(_mapper.ConfigurationProvider).ToList().
                Where(p => p.ToolType.ToString().ToLower().Contains(searchString.ToLower())).ToList(); //ProjectTo - collection

            var solidMillingToolsToShow = solidMillingTools.Skip((int)((pageNo - 1) * pageSize)).Take(pageSize).ToList();
            var solidMillingToolList = new ListSolidMillingToolForListVm()
            {
                PageSize = pageSize,
                CurrentPage = (int)pageNo,
                SearchString = searchString,
                SolidMillingTools = solidMillingToolsToShow,
                Count = solidMillingTools.Count
            };

            return solidMillingToolList;
        }

        public SolidMillingToolDetailsVm GetSolidMillingToolDetails(int id)
        {
            var solidMillingTool = _solidMillingToolRepo.GetSolidMillingToolById(id);
            var solidMillingToolVm = _mapper.Map<SolidMillingToolDetailsVm>(solidMillingTool); //Map - single object
            return solidMillingToolVm;
        }

        public NewSolidMillingToolVm GetSolidMillingToolForEdit(int id)
        {
            var solidMillingTool = _solidMillingToolRepo.GetSolidMillingToolById(id);
            var solidMillingToolVm = _mapper.Map<NewSolidMillingToolVm>(solidMillingTool);
            return solidMillingToolVm;
        }

        public void UpdateSolidMillingTool(NewSolidMillingToolVm solidMillingTool)
        {
            var solidMillingToolToUpdate = _mapper.Map<MachiningTechHelperMVC.Domain.Model.SolidMillingTool>(solidMillingTool);
            _solidMillingToolRepo.UpdateSolidMillingTool(solidMillingToolToUpdate);
        }
    }
}
