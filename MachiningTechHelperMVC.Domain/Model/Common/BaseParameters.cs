using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Domain.Model.Common
{
    public class BaseParameters : BaseEntity
    {
        public string? GradeName { get; set; }
        public string? Description { get; set; }
        public string? Material { get; set; }
        public int CuttingSpeedMinimum { get; set; }
        public int CuttingSpeedMaximum { get; set; }
    }
}
