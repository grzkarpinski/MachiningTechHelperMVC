using MachiningTechHelperMVC.Domain.Model;

namespace MachiningTechHelperMVC.Domain.Interfaces
{
    public interface ISolidMillingToolRepository
    {
        void DeleteSolidMillingTool(int solidMillingToolId);

        int AddSolidMillingTool(SolidMillingTool solidMillingTool);

        SolidMillingTool GetSolidMillingToolById(int solidMillingToolId);

        void UpdateSolidMillingTool(SolidMillingTool solidMillingToolToUpdate);

        IQueryable<SolidMillingTool> GetAllSolidMillingTools();
    }
}
