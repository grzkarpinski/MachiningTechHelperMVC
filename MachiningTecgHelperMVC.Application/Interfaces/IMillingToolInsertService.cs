using MachiningTechelperMVC.Application.ViewModels.MillingInsert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechelperMVC.Application.Interfaces
{
    public interface IMillingToolInsertService // for junction table
    {
        void AddMillingToolInsert(MillingInsertVm millingToolInsert);
        void DeleteMillingToolInsert(int millingToolId, int millingInsertId);
        MillingInsertVm GetMillingToolInsert(int millingToolId, int millingInsertId);
    }
}
