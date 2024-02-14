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
        private readonly IDrillRepository _drillRepository;
        public int AddDrill(NewDrillVm drill)
        {
            throw new NotImplementedException(); // ?????????????????????????????
        }

        public ListDrillForListVm GetAllDrillsForList()
        {
            var drills = _drillRepository.GetAllDrills();
            ListDrillForListVm result = new ListDrillForListVm();
            result.Drills = new List<DrillForListVm>();
            foreach (var drill in drills)
            {
                var drillVm = new DrillForListVm()
                {
                        Id = drill.Id,
                        Diameter = drill.Diameter,
                        LengthXDiameter = drill.LengthXDiameter,
                        Description = drill.Description,
                };
                result.Drills.Add(drillVm);
            }
            result.Count = result.Drills.Count;
            return result;
        }

        public DrillDetailsVm GetDrillDetails(int drillId)
        {
            var drill = _drillRepository.GetDrillById(drillId);
            var drillVm = new DrillDetailsVm();
            drillVm.Id = drill.Id;
            drillVm.Diameter = drill.Diameter;
            drillVm.LengthXDiameter = drill.LengthXDiameter;
            drillVm.Description = drill.Description;
            drillVm.Producer = drill.Producer.Name;
            drillVm.Grade = drill.Grade.GradeName;
            drillVm.TipAngle = drill.TipAngle;
            drillVm.Designation = drill.Designation;

            drillVm.DrillCheckedParameters = new List<DrillCheckedParametersForListVm>();
            drillVm.FeedPerRevisions = new List<FeedPerRevisionForListVm>();

            foreach (var feedPerRevision in drill.FeedPerRevisions)
            {
                {
                    var add = new FeedPerRevisionForListVm()
                    {
                        Id = feedPerRevision.Id,
                        Material = feedPerRevision.Material,
                        FeedPerRevisionMinimum= feedPerRevision.FeedPerRevisionMinimum,
                        FeedPerRevisionMaximum = feedPerRevision.FeedPerRevisionMaximum,
                    };
                    drillVm.FeedPerRevisions.Add(add);
            };

                foreach (var drillCheckedParameter in drill.DrillCheckedParameters)
                {
                var add = new DrillCheckedParametersForListVm()
    {
                    Id = drillCheckedParameter.Id,
                    RevisionsPerMinute = drillCheckedParameter.RevisionsPerMinute,
                    FeedPerMinute = drillCheckedParameter.FeedPerMinute,
                    Material = drillCheckedParameter.Material,
                };
                drillVm.DrillCheckedParameters.Add(add);
                }
                
            }

            return drillVm;
        }
    }
}
