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
        MillingInsertVm GetMillingInsertForEdit(int id);
        void UpdateMillingInsert(MillingInsertVm millingInsert);
        MillingInsertVm GetMillingInsertById(int millingInsertId);
        void DeleteMillingInsert(int millingInsertId);
    }
}
