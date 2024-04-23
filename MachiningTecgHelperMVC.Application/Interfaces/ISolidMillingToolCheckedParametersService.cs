using MachiningTechelperMVC.Application.ViewModels.MillingToolCheckedParameters;
using MachiningTechelperMVC.Application.ViewModels.SolidMillingToolCheckedParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechelperMVC.Application.Interfaces
{
    public interface ISolidMillingToolCheckedParametersService
    {
        ListMillingToolCheckedParametersVm GetAllMillingToolCheckedParameters(int solidMillingToolid);
        int AddSolidMillingToolCheckedParameters(SolidMillingToolCheckedParametersVm millingToolCheckedParameters);
        SolidMillingToolCheckedParametersVm GetSolidMillingToolCheckedParametersForEdit(int solidMillingToolid);
        void UpdateSolidMillingToolCheckedParameters(SolidMillingToolCheckedParametersVm solidMillingToolCheckedParameters);
        SolidMillingToolCheckedParametersVm GetSolidMillingToolCheckedParametersById(int solidMillingToolid);
        void DeleteSolidMillingToolCheckedParameters(int solidMillingToolid);
    }
}
