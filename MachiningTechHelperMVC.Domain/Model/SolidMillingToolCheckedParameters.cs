using MachiningTechHelperMVC.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Domain.Model
{
    public class SolidMillingToolCheckedParameters: BaseEntity
    {
        public string Material { get; set; }
        public int RevisionsPerSecond { get; set; }
        public int FeedPerMinute { get; set; }
        public double cuttingDepth { get; set; }

        public int SolidMillingToolId { get; set; }
        public virtual SolidMillingTool SolidMillingTool { get; set; }

    }
}
