using MachiningTechelperMVC.Application.ViewModels.MillingTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechelperMVC.Application.Interfaces
{
    public interface IMillingToolService
    {
        ListMillingToolForListVm GetAllMillingToolsForList(int pageSize, int? pageNo, string searchString);
        int AddMillingTool(NewMillingToolVm millingTool);
        MillingToolDetailsVm GetMillingToolDetails(int id);
        NewMillingToolVm GetMillingToolForEdit(int id);
        void UpdateMillingTool(NewMillingToolVm millingTool);
        void DeleteMillingTool(int id);
        void DeleteMillingToolSoft(int id);
    }
}
