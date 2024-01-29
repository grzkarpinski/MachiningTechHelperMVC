using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Domain.Model
{
    public class MillingToolCheckedParameters
    {
        public int Id { get; set; }

        public string Material { get; set; }

        public int RevisionsPerSecond { get; set; }

        public int FeedPerMinute { get; set; }

        public double CuttingDepth { get; set; }

        public int MillingToolId { get; set; }

        public int MillingInsertId { get; set; }

        [ForeignKey("MillingTool")]
        public virtual MillingTool MillingTool { get; set; }

        [ForeignKey("MillingInsert")]
        public virtual MillingInsert MillingInsert { get; set; }
    }
}
