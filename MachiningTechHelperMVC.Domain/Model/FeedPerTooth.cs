﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Domain.Model
{
    public class FeedPerTooth
    {
        public int Id { get; set; }

        public string Material { get; set; }
        public double FeedPerToothMinimum { get; set; }
        public double FeedPerToothMaximum { get; set; }

        // foreign keys
        public int SolidMillingToolId { get; set; }
        public virtual SolidMillingTool SolidMillingTool { get; set; }
        public int MillingInsertId { get; set; }

        public virtual MillingInsert MillingInsert { get; set; }
    }
}
