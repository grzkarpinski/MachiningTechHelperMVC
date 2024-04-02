using MachiningTechHelperMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Domain.Interfaces
{
    public interface IDrillCheckedParametersRepository
    {
        void DeleteDrillCheckedParameters(int drillCheckedParametersId);

        int AddDrillCheckedParameters(DrillCheckedParameters drillCheckedParameters);

        IQueryable<DrillCheckedParameters> GetDrillCheckedParametersbyTool(int drillId);

        void UpdateDrillCheckedParameters(DrillCheckedParameters drillCheckedParametersToUpdate);

        DrillCheckedParameters GetDrillCheckedParametersById(int drillCheckedParametersId);
    }
}
