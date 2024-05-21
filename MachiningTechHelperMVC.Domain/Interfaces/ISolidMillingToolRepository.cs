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

        int AddSolidMillingTool(SolidMillingTool solidMillingTool);
        IQueryable<SolidMillingTool> GetSolidMillingToolByDiameter(double diameter);

        SolidMillingTool GetSolidMillingToolById(int solidMillingToolId);

        IQueryable<SolidMillingTool> GetSolidMillingToolByProducer(int ProducerId);

        void UpdateSolidMillingTool(SolidMillingTool solidMillingToolToUpdate);

        IQueryable<SolidMillingTool> GetAllSolidMillingTools();
    }
}
