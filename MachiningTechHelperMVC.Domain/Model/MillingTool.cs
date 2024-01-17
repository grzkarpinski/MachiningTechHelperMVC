using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Domain.Model
{
    public class MillingTool
    {
        public int Id { get; set; }
        public double Diameter { get; set; }
        public string Designation { get; set; }
        public string Description { get; set; }
        public double TeethNumber { get; set; }

        // foreign keys

        [ForeignKey("Producer")]
        public int ProducerId { get; set; }

        public virtual Producer Producer { get; set; }

        // navigation property
        public virtual ICollection<MillingToolCheckedParameters> MillingToolCheckedParameters { get; set; }
    }
}
