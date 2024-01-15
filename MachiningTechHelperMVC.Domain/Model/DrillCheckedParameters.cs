using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Domain.Model
{
    public class DrillCheckedParameters
    {
        public int Id { get; set; }

        public string Material { get; set; }

        public int RevisionsPerSecond { get; set; }

        public int FeedPerMinute { get; set; }

        public int DrillId { get; set; }

        [ForeignKey("Drill")]
        public virtual Drill Drill { get; set; }
    }
}
