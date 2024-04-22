using MachiningTechelperMVC.Application.ViewModels.SolidMillingTool;
using MachiningTechHelperMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechelperMVC.Application.Interfaces
{
    public interface ISolidMillingToolService
    {
        ListSolidMillingToolForListVm GetAllSolidMillingToolsForList(int pageSize, int? pageNo, string searchString);
        int AddSolidMillingTool(NewSolidMillingToolVm solidMillingTool);
        SolidMillingToolDetailsVm GetSolidMillingToolDetails(int id);
        NewSolidMillingToolVm GetSolidMillingToolForEdit(int id);
        void UpdateSolidMillingTool(NewSolidMillingToolVm solidMillingTool);
        void DeleteSolidMillingTool(int id);
    }
}
