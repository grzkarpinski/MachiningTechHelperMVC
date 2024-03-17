using AutoMapper;
using AutoMapper.QueryableExtensions;
using MachiningTechHelperMVC.Application.Interfaces;
using MachiningTechHelperMVC.Application.ViewModels.Drill;
using MachiningTechHelperMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Application.Services
{
    public class DrillService : IDrillService
    {
        private readonly IDrillRepository _drillRepo;
        private readonly IMapper _mapper;

        public DrillService(IDrillRepository drillRepo, IMapper mapper)
        {
            _drillRepo = drillRepo;
            _mapper = mapper;
        }
        public int AddDrill(NewDrillVm drill)
        {
            var drillToAdd = _mapper.Map<Domain.Model.Drill>(drill);
            var id = _drillRepo.AddDrill(drillToAdd);
            return id;
        }

        public ListDrillForListVm GetAllDrillsForList(int pageSize, int? pageNo, string searchString)
        {
            var drills = _drillRepo.GetAllDrills()
                .ProjectTo<DrillForListVm>(_mapper.ConfigurationProvider).ToList().
                Where(p => p.ToolType.ToString().ToLower().Contains(searchString.ToLower())).ToList(); //ProjectTo - collection

            var drillsToShow = drills.Skip((int)((pageNo - 1) * pageSize)).Take(pageSize).ToList();
            var drillList = new ListDrillForListVm()
            {
                PageSize = pageSize,
                CurrentPage = (int)pageNo,
                SearchString = searchString,
                Drills = drillsToShow,
                Count = drills.Count
            };

            return drillList;
        }

        public DrillDetailsVm GetDrillDetails(int id)
        {
            var drill = _drillRepo.GetDrillById(id);

            var drillVm = _mapper.Map<DrillDetailsVm>(drill); //Map - single object

            drillVm.DrillCheckedParameters = new List<DrillCheckedParametersVm>();

            if (drill.DrillCheckedParameters != null)
               {
                foreach (var checkedParameter in drill.DrillCheckedParameters)
                {
                    var checkedParameterVm = new DrillCheckedParametersVm()
                    {
                        Id = checkedParameter.Id,
                        Material = checkedParameter.Material,
                        RevisionsPerMinute = checkedParameter.RevisionsPerMinute,
                        FeedPerMinute = checkedParameter.FeedPerMinute,
                    };
                    drillVm.DrillCheckedParameters.Add(checkedParameterVm);
                }
            }
            return drillVm;

        }
    }
}
