using MachiningTechHelperMVC.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Domain.Model
{
    public class MillingInsert: BaseEntity
    {
        public string Designation { get; set; }
        public double Radius { get; set; }

        public virtual ICollection<MillingToolMillingInsert>? MillingToolMillingInserts { get; set; }
        public virtual ICollection<FeedPerTooth>? FeedPerTeeth { get; set; }
        public virtual ICollection<MillingToolCheckedParameters>? MillingToolCheckedParameters { get; set; }
    }
}
