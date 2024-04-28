using MachiningTechelperMVC.Application.ViewModels.MillingToolCheckedParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechelperMVC.Application.Interfaces
{
    public interface IMillingToolCheckedParametersService
    {
        ListMillingToolCheckedParametersVm GetAllMillingToolCheckedParameters(int millingToolId);
        int AddMillingToolCheckedParameters(MillingToolCheckedParametersVm checkedParameters);
        void DeleteMillingToolCheckedParameters(int id);
        MillingToolCheckedParametersVm GetMillingToolCheckedParametersForEdit(int id);
        void UpdateMillingToolCheckedParameters(MillingToolCheckedParametersVm millingToolCheckedParameters);
        MillingToolCheckedParametersVm GetMillingToolCheckedParametersById(int milling);
    }
}
