using MachiningTechelperMVC.Application.ViewModels.DrillParametersRange;
using MachiningTechHelperMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechelperMVC.Application.Interfaces
{
    public interface IDrillParametersRangeService
    {
        ListDrillParametersRangeListVm GetAllDrillParametersRanges();
        int AddDrillParametersRange(DrillParametersRangeVm drillParametersRange);
        DrillParametersRangeVm GetDrillParametersRangeForEdit(int id);
        void UpdateDrillParametersRange(DrillParametersRangeVm drillParametersRange);
        DrillParametersRangeVm GetDrillParametersRangeById(int drillParametersRangeId);
        void DeleteDrillParametersRange(int drillParametersRangeId);
    }
}
