using MachiningTechHelperMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Domain.Interfaces
{
    public interface ISolidMillingToolRepository
    {
        void DeleteSolidMillingTool(int solidMillingToolId);
        void DeleteSolidMillingToolSoft(int solidMillingToolId);

        int AddSolidMillingTool(SolidMillingTool solidMillingTool);

        SolidMillingTool GetSolidMillingToolById(int solidMillingToolId);

        void UpdateSolidMillingTool(SolidMillingTool solidMillingToolToUpdate);

        IQueryable<SolidMillingTool> GetAllSolidMillingTools();
    }
}
