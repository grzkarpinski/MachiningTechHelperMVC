using MachiningTechHelperMVC.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Domain.Model
{
    public class DrillCheckedParameters: BaseEntity
    {
        public required string Material { get; set; }
        public int RevisionsPerMinute { get; set; }
        public int FeedPerMinute { get; set; }

        public int DrillId { get; set; }
        public virtual required Drill Drill { get; set; }
    }
}
