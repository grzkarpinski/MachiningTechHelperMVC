using MachiningTechHelperMVC.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Domain.Model
{
    public class SolidMillingTool: BaseRoundTool
    {
        public double TeethNumber { get; set; }
        public double Radius { get; set; }

        public int? ProducerId { get; set; }
        public virtual Producer? Producer { get; set; }

        public virtual ICollection<SolidMillingToolCheckedParameters>? SolidMillingToolCheckedParameters { get; set; }

        public virtual ICollection<SolidMillingToolParametersRange>? SolidMillingToolParametersRanges { get; set; }

    }
}
