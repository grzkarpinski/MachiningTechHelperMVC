using MachiningTechHelperMVC.Domain.Model;

namespace MachiningTechHelperMVC.Domain.Interfaces
{
    public interface IMillingToolRepository
    {
        void DeleteMillingTool(int millingToolId);

        int AddMillingTool(MillingTool millingTool);

        MillingTool GetMillingToolById(int millingToolId);

        IQueryable<MillingInsert> GetMillingInserts();

        void UpdateMillingTool(MillingTool millingToolToUpdate);

        IQueryable<MillingTool> GetAllMillingTools();

    }
}
