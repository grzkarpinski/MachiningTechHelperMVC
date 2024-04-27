using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Domain.Model.Common
{
    public class BaseRoundTool: BaseTool
    {
        public double Diameter { get; set; }
        public int TeethNumber { get; set; }
    }
}
