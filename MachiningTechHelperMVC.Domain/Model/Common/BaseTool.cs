using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Domain.Model.Common
{
    public class BaseTool: BaseEntity
    {
        public required string Designation { get; set; }
        public string? Description { get; set; }
        public required string ToolType { get; set; }
        public bool IsToolActive { get; set; }
    }
}
