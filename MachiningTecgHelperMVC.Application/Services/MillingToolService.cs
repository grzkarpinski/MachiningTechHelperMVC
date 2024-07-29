using AutoMapper;
using AutoMapper.QueryableExtensions;
using MachiningTechelperMVC.Application.Interfaces;
using MachiningTechelperMVC.Application.ViewModels.MillingTool;
using MachiningTechHelperMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechelperMVC.Application.Services
{
    public class MillingToolService : IMillingToolService
    {
        private readonly IMillingToolRepository _millingToolRepo;
        private readonly IMapper _mapper;

        public MillingToolService(IMillingToolRepository millingToolRepo, IMapper mapper)
        {
            _millingToolRepo = millingToolRepo;
            _mapper = mapper;
        }

        public int AddMillingTool(NewMillingToolVm millingTool)
        {
            var millingToolToAdd = _mapper.Map<MachiningTechHelperMVC.Domain.Model.MillingTool>(millingTool);
            var id = _millingToolRepo.AddMillingTool(millingToolToAdd);
            return id;
        }

        public void DeleteMillingTool(int id)
        {
            _millingToolRepo.DeleteMillingTool(id);
        }

        public void DeleteMillingToolSoft(int id)
        {
            _millingToolRepo.DeleteMillingToolSoft(id);
        }

        public ListMillingToolForListVm GetAllMillingToolsForList(int pageSize, int? pageNo, string searchString)
        {
            var millingTools = _millingToolRepo.GetAllMillingTools()
                .ProjectTo<MillingToolForListVm>(_mapper.ConfigurationProvider).ToList().
                Where(p => p.ToolType.ToString().ToLower().Contains(searchString.ToLower())).ToList(); //ProjectTo - collection

            var millingToolsToShow = millingTools.Skip((int)((pageNo - 1) * pageSize)).Take(pageSize).ToList();
            var millingToolList = new ListMillingToolForListVm()
            {
                PageSize = pageSize,
                CurrentPage = (int)pageNo,
                SearchString = searchString,
                MillingTools = millingToolsToShow,
                Count = millingTools.Count
            };

            return millingToolList;
        }

        public MillingToolDetailsVm GetMillingToolDetails(int id)
        {
            var millingTool = _millingToolRepo.GetMillingToolById(id);
            var millingToolVm = _mapper.Map<MillingToolDetailsVm>(millingTool); //Map - single object
            return millingToolVm;
        }

        public NewMillingToolVm GetMillingToolForEdit(int id)
        {
            var millingTool = _millingToolRepo.GetMillingToolById(id);
            var millingToolVm = _mapper.Map<NewMillingToolVm>(millingTool);
            return millingToolVm;
        }

        public void UpdateMillingTool(NewMillingToolVm millingTool)
        {
            var millingToolToUpdate = _mapper.Map<MachiningTechHelperMVC.Domain.Model.MillingTool>(millingTool);
            _millingToolRepo.UpdateMillingTool(millingToolToUpdate);
        }
    }
}
