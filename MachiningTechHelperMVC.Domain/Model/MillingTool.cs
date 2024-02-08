﻿using MachiningTechHelperMVC.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Domain.Model
{
    public class MillingTool: BaseRoundTool
    {
        public double TeethNumber { get; set; }

        // foreign keys

        [ForeignKey("Producer")]
        public int ProducerId { get; set; }

        public virtual Producer Producer { get; set; }

        // navigation property

        public virtual ICollection<MillingToolMillingInsert> MillingToolMillingInserts { get; set; }
        public virtual ICollection<MillingToolCheckedParameters> MillingToolCheckedParameters { get; set; }
    }
}
