using MachiningTechelperMVC.Application.ViewModels.MillingInsert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechelperMVC.Application.Interfaces
{
    public interface IMillingInsertService
    {
        ListMillingInsertVm GetAllMillingInserts();
        int AddMillingInsert(MillingInsertVm millingInsert);
        void DeleteMillingInsert(int millingInsertId);
        MillingInsertVm GetMillingInsertById(int millingInsertId);
    }
}
