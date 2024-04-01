using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechelperMVC.Application.ViewModels.DrillParametersRange
{
    public class ListDrillParametersRangeListVm
    {
        public List<DrillParametersRangeVm> DrillParametersRanges { get; set; }
        public int Count { get; set; }
    }
}
