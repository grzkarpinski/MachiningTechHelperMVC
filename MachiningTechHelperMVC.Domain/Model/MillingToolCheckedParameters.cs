using MachiningTechHelperMVC.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Domain.Model
{
    public class MillingToolCheckedParameters: BaseEntity
    {
        public string Material { get; set; }

        public int RevisionsPerSecond { get; set; }

        public int FeedPerMinute { get; set; }

        public double CuttingDepth { get; set; }

        public int MillingToolId { get; set; }

        public int MillingInsertId { get; set; }

        [ForeignKey("MillingToolId")]
        public virtual MillingTool MillingTool { get; set; }

        [ForeignKey("MillingInsertId")]
        public virtual MillingInsert MillingInsert { get; set; }
    }
}
