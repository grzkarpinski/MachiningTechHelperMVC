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
        void DeleteDrill(int drillId);

        int AddDrill(Drill drill);
        IQueryable<Drill> GetDrillByDiameter(double diameter);

        Drill GetDrillById(int drillId);

        IQueryable<Drill> GetDrillByProducer(int ProducerId);
    }
}
