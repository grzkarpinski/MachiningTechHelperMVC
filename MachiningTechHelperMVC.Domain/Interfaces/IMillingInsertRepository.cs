using MachiningTechHelperMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Domain.Interfaces
{
    public interface IMillingInsertRepository
    {
        void DeleteMillingInsert(int millingInsertId);

        int AddMillingInsert(MillingInsert millingInsert);

        MillingInsert GetMillingInsertById(int milling);

        IQueryable<MillingInsert> GetAllMillingInserts();
    }
}
