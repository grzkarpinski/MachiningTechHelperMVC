using MachiningTechHelperMVC.Application.ViewModels.Drill;
using MachiningTechHelperMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Application.Interfaces
{
    public interface IDrillService
    {
        ListDrillForListVm GetAllDrillsForList();

        int AddDrill(NewDrillVm drill);

        DrillDetailsVm GetDrillDetails(int drillId);
    }
}
