using MachiningTechHelperMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Domain.Interfaces
{
    public interface ISolidMillingToolCheckedParametersRepository
    {
        void DeleteSolidMillingToolCheckedParameters(int solidMillingToolCheckedParametersId);

        int AddSolidMillingToolCheckedParameters(SolidMillingToolCheckedParameters solidMillingToolCheckedParameters);

        IQueryable<SolidMillingToolCheckedParameters> GetSolidMillingToolCheckedParametersbyTool(int solidMillingToolId);
    }
}
