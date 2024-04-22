using MachiningTechelperMVC.Application.ViewModels.MillingInsertParametersRange;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechelperMVC.Application.Interfaces
{
    public interface IMillingInsertParametersRangeService
    {
        MillingInsertParametersRangeListVm GetAllMillingInsertParametersRanges();
        int AddMillingInsertParametersRange(MillingInsertParametersRangeVm millingInsertParametersRange);
        void DeleteMillingInsertParametersRange(int millingInsertParametersRangeId);
        MillingInsertParametersRangeVm GetMillingInsertParametersRangeForEdit(int id);
        void UpdateMillingInsertParametersRange(MillingInsertParametersRangeVm millingInsertParametersRange);
        MillingInsertParametersRangeVm GetMillingInsertParametersRangeById(int milling);
    }
}
