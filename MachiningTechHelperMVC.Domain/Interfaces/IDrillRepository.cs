using MachiningTechHelperMVC.Domain.Model;

namespace MachiningTechHelperMVC.Domain.Interfaces
{
    public interface IDrillRepository
    {
        IQueryable<Drill> GetAllDrills();

        void DeleteDrill(int drillId);

        int AddDrill(Drill drill);

        Drill GetDrillById(int drillId);

        void UpdateDrill(Drill drillToUpdate);
    }
}
