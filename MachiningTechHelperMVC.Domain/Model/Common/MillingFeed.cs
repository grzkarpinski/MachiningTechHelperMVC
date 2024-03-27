﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Domain.Model.Common
{
    public class MillingFeed: BaseParameters
    {
        public double FeedPerToothMinimum { get; set; }
        public double FeedPerToothMaximum { get; set; }
    }
}
