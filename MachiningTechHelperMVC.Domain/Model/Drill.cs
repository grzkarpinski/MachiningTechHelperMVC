using MachiningTechHelperMVC.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Domain.Model
{
    public class Drill: BaseRoundTool
    {
        public string LengthXDiameter { get; set; }
        public int TipAngle { get; set; }

        public int GradeId { get; set; }
        public virtual Grade Grade { get; set; }

        public int ProducerId { get; set; }
        public virtual Producer Producer { get; set; }

        public virtual ICollection<DrillCheckedParameters>? DrillCheckedParameters { get; set; }
        public virtual ICollection<FeedPerRevision>? FeedPerRevisions { get; set; }
    }
}
