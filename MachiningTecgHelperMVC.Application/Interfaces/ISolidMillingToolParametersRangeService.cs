using MachiningTechelperMVC.Application.ViewModels.SolidMillingToolParametersRange;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechelperMVC.Application.Interfaces
{
    public interface ISolidMillingToolParametersRangeService
    {
        SolidMillingToolParametersRangeListVm GetSolidMillingToolParametersRange();
        int AddSolidMillingToolParametersRange(SolidMillingToolParametersRangeVm solidMillingToolParametersRange);
        SolidMillingToolParametersRangeVm GetSolidMillingToolParametersForEdit(int id);
        void UpdateSolidMillingToolParametersRange(SolidMillingToolParametersRangeVm solidMillingToolParametersRange);
        void DeleteSolidMillingToolParametersRange(int id);
    }
}
