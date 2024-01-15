using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Domain.Model
{
    public class SolidMillingToolCheckedParameters
    {
        public int Id { get; set; }

        public string Material { get; set; }

        public int RevisionsPerSecond { get; set; }

        public int FeedPerMinute { get; set; }

        public double cuttingDepth { get; set; }

        [ForeignKey("SolidMillingTool")]
        public virtual SolidMillingTool SolidMillingTool { get; set; }

    }
}
