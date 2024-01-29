using MachiningTechHelperMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Domain.Interfaces
{
    public interface IMillingToolRepository
    {
        void DeleteMillingTool(int millingToolId);

        int AddMillingTool(MillingTool millingTool);

        IQueryable<MillingTool> GetMillingToolByDiameter(double diameter);

        MillingTool GetMillingToolById(int millingToolId);

        IQueryable<MillingInsert> GetMillingInserts();

        IQueryable<MillingTool> GetMillingToolByProducer(int ProducerId);

    }
}
