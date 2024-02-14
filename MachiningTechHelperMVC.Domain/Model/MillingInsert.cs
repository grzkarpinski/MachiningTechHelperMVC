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
        public required string Designation { get; set; }
        public double Radius { get; set; }

        public int GradeId { get; set; }
        public virtual required Grade Grade { get; set; }

        public virtual ICollection<MillingToolMillingInsert>? MillingToolMillingInserts { get; set; }
        public virtual required ICollection<FeedPerTooth> FeedPerTeeth { get; set; }
        public virtual ICollection<MillingToolCheckedParameters>? MillingToolCheckedParameters { get; set; }
    }
}
