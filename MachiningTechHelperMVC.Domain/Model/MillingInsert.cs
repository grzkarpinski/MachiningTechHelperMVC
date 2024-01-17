using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Domain.Model
{
    public class MillingInsert
    {
        public int Id { get; set; }
        public string Designation { get; set; }
        public double Radius { get; set; }

        //foreign keys
        public int GradeId { get; set; }

        public virtual Grade Grade { get; set; }

        // navigation property

        public virtual ICollection<MillingToolMillingInsert> MillingToolMillingInserts { get; set; }

        public virtual ICollection<FeedPerTooth> FeedPerTeeth { get; set; }
    }
}
