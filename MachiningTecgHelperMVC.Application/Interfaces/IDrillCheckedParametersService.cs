using MachiningTechelperMVC.Application.ViewModels.DrillCheckedParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechelperMVC.Application.Interfaces
{
    public interface IDrillCheckedParametersService
    {
        ListDrillCheckedParametersVm GetAllDrillCheckedParameters(int drillId);
        int AddDrillCheckedParameters(DrillCheckedParametersVm checkedParameters);
        DrillCheckedParametersVm GetDrillCheckedParametersForEdit(int id);
        void UpdateDrillCheckedParameters(DrillCheckedParametersVm drillCheckedParameters);
        DrillCheckedParametersVm GetDrillCheckedParametersById(int drillCheckedParametersId);
        void DeleteDrillCheckedParameters(int drillCheckedParametersId);
    }
}
