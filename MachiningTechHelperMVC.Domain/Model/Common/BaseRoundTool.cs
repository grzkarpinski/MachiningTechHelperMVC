using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Domain.Model.Common
{
    public class BaseRoundTool: BaseEntity
    {
        public double Diameter { get; set; }
        public string Designation { get; set; }

        public string Description { get; set; }
    }
}
