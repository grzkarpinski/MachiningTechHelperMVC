using MachiningTechHelperMVC.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Domain.Model
{
    public class MillingInsertParametersRange: MillingFeed
    {
        public int MillingInsertId { get; set; }
        public virtual MillingInsert? MillingInsert { get; set; }
    }
}
