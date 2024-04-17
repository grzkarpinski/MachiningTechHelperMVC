using MachiningTechHelperMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Domain.Interfaces
{
    public interface IMillingInsertParametersRangeRepository
    {
        int AddMillingInsertParametersRange(MillingInsertParametersRange millingInsertParametersRange);
        MillingInsertParametersRange GetMillingInsertParametersRangeById(int millingImsertParametersRangeId);
        IEnumerable<MillingInsertParametersRange> GetAllMillingInsertParametersRanges();
        void UpdateMillingInsertParametersRange(MillingInsertParametersRange millingInsertParametersRange);
        void DeleteMillingInsertParametersRange(int millingInsertParametersRangeId);
    }
}
