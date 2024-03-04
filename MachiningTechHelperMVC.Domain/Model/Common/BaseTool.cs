using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Domain.Model.Common
{
    public class BaseTool: BaseEntity
    {
        public string Designation { get; set; }
        public string? Description { get; set; }
        public ToolType ToolType { get; set; }
        public bool IsToolActive { get; set; }
    }
}
