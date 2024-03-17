using MachiningTechHelperMVC.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Domain.Model
{
    public class Grade: BaseEntity
    {
        public string GradeName { get; set; }
        public string? Description { get; set; }
        public int NonAlloyedSteelCuttingSpeedMinimum { get; set; }
        public int NonAlloyedSteelCuttingSpeedMaximum { get; set; }
        public int StainlessSteelCuttingSpeedMinimum { get; set; }
        public int StainlessSteelCuttingSpeedMaximum { get; set; }
        public int AlluminiumCuttingSpeedMinimum { get; set; }
        public int AlluminiumCuttingSpeedMaximum { get; set; }

        public virtual ICollection<MillingInsert>? MillingInserts { get; set; }
        public virtual ICollection<SolidMillingTool>? SolidMillingTools { get; set; }
        public virtual ICollection<Drill>? Drills { get; set; }
    }
}
