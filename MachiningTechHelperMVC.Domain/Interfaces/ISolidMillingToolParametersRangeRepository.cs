using MachiningTechHelperMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Domain.Interfaces
{
    public interface ISolidMillingToolParametersRangeRepository
    {
        int AddSolidMillingToolParametersRange(SolidMillingToolParametersRange solidMillingToolParametersRange);
        SolidMillingToolParametersRange GetSolidMillingToolParametersRangeById(int solidMillingToolParametersRangeId);
        IEnumerable<SolidMillingToolParametersRange> GetAllSolidMillingToolParametersRanges();
        void UpdateSolidMillingToolParametersRange(SolidMillingToolParametersRange solidMillingToolParametersRange);
        void DeleteSolidMillingToolParametersRange(int solidMillingToolParametersRangeId);
    }
}
