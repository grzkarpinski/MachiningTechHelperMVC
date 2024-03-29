using MachiningTechHelperMVC.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Domain.Model
{
    public class DrillParametersRange: BaseParameters
    {
        public double FeedPerRevisionMinimum { get; set; }
        public double FeedPerRevisionMaximum { get; set; }

        public int DrillId { get; set; }
        public virtual Drill Drill { get; set; }
    }
}
