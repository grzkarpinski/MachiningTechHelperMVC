using MachiningTechHelperMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Domain.Interfaces
{
    public interface IDrillParametersRangeRepository
    {
        int AddDrillParametersRange(DrillParametersRange drillParametersRange);
        DrillParametersRange GetDrillParametersRangeById(int drillParametersRangeId);
        IEnumerable<DrillParametersRange> GetAllDrillParametersRanges();
        void UpdateDrillParametersRange(DrillParametersRange drillParametersRange);
        void DeleteDrillParametersRange(int drillParametersRangeId);
    }
}
