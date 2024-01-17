using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Domain.Model
{
    public class SolidMillingTool
    {
        public int Id { get; set; }
        public double Diameter { get; set; }
        public string Designation { get; set; }
        public string Description { get; set; }

        public double TeethNumber { get; set; }

        public double Radius { get; set; }

        // foreign keys
        [ForeignKey("Grade")]
        public int GradeId { get; set; }

        [ForeignKey("Producer")]
        public int ProducerId { get; set; }

        public virtual Grade Grade { get; set; }
        public virtual Producer Producer { get; set; }

        // navigation property
        public virtual ICollection<SolidMillingToolCheckedParameters> SolidMillingToolCheckedParameters { get; set; }

        public virtual ICollection<FeedPerTooth> FeedPerTeeth { get; set; }

    }
}
