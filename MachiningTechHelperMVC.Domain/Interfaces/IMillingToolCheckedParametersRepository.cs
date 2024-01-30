using MachiningTechHelperMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Domain.Interfaces
{
    public interface IMillingToolCheckedParametersRepository
    {
        void DeleteMillingToolCheckedParameters(int millingToolCheckedParametersId);

        int AddMillingToolCheckedParameters(MillingToolCheckedParameters millingToolCheckedParameters);

        IQueryable<MillingToolCheckedParameters> GetMillingToolCheckedParametersbyTool(int millingToolId);


    }
}
