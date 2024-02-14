using MachiningTechHelperMVC.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Domain.Model
{
    public class Producer: BaseEntity
    {
        public string CompanyName { get; set; }

        public virtual ICollection<MillingTool>? MillingTools { get; set; }
        public virtual ICollection<SolidMillingTool>? SolidMillingTools { get; set; }
        public virtual ICollection<Drill>? Drills { get; set; }
    }
}
