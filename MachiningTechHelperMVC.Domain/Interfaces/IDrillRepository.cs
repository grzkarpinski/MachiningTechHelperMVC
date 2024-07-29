using MachiningTechHelperMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Domain.Interfaces
{
    public interface IDrillRepository
    {
        IQueryable<Drill> GetAllDrills();

        void DeleteDrill(int drillId);

        void DeleteDrillSoft(int drillId);

        int AddDrill(Drill drill);

        Drill GetDrillById(int drillId);

        void UpdateDrill(Drill drillToUpdate);
    }
}
