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
        public string Descripion { get; set; }
        public string InsertType { get; set; }
        public double TeethNumber { get; set; }
        public List<double> InsertRadiuses { get; set; }

        public double NonAlloyedSteelFeedPerToothMinimum { get; set; }
        public double NonAlloyedSteelFeedPerToothMaximum { get; set; }

        public double StainlessSteelFeedPerToothMinimum { get; set; }
        public double StainlessSteelFeedPerToothMaximum { get; set; }

        public double AlluminiumFeedPerToothMinimum { get; set; }
        public double AlluminiumFeedPerToothMaximum { get; set; }

        // foreign keys
        [ForeignKey("Grade")]
        public int GradeId { get; set; }

        [ForeignKey("Producer")]
        public int ProducerId { get; set; }

        public virtual Grade Grade { get; set; }
        public virtual Producer Producer { get; set; }

        // navigation property
        public virtual ICollection<MillingToolCheckedParameters> MillingToolCheckedParameters { get; set; }
    }
}
