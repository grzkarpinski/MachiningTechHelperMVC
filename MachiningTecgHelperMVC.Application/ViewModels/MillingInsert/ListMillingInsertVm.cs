using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechelperMVC.Application.ViewModels.MillingInsert
{
    public class ListMillingInsertVm
    {
        public List<MillingInsertVm> MillingInserts { get; set; }

        public int? MillingToolId { get; set; }
        public int Count { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }

        public string SearchString { get; set; }
    }
}
