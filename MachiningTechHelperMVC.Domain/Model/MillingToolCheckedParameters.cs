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
        public required string Material { get; set; }
        public int RevisionsPerSecond { get; set; }
        public int FeedPerMinute { get; set; }
        public double CuttingDepth { get; set; }

        public int MillingToolId { get; set; }
        public virtual required MillingTool MillingTool { get; set; }

        public int MillingInsertId { get; set; }
        public virtual required MillingInsert MillingInsert { get; set; }
    }
}
