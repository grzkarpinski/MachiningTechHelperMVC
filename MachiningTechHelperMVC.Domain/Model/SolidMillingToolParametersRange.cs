using MachiningTechHelperMVC.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Domain.Model
{
    public class SolidMillingToolParametersRange: MillingFeed
    {
        public int SolidMillingToolId { get; set; }
        public virtual SolidMillingTool? SolidMillingTool { get; set; }
    }
}
