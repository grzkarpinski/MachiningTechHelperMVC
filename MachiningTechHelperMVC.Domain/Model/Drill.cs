using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Domain.Model
{
    public class Drill
    {
        public int Id { get; set; }
        public double Diameter { get; set; }
        public string LengthXDiameter { get; set; }
        public string Designation { get; set; }
        public string Description { get; set; }

        public int TipAngle { get; set; }

        // foreign keys
        [ForeignKey("Grade")]
        public int GradeId { get; set; }
        public virtual Grade Grade { get; set; }

        [ForeignKey("Producer")]
        public int ProducerId { get; set; }

        public virtual Producer Producer { get; set; }

        // navigation property
        public virtual ICollection<DrillCheckedParameters> DrillCheckedParameters { get; set; }
        public virtual ICollection<FeedPerRevision> FeedPerRevisions { get; set; }
    }
}
