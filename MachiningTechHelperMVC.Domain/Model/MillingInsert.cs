using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Domain.Model
{
    public class MillingInsert
    {
        public int Id { get; set; }
        public string Designation { get; set; }
        public double Radius { get; set; }

        public double NonAlloyedSteelFeedPerToothMinimum { get; set; }
        public double NonAlloyedSteelFeedPerToothMaximum { get; set; }

        public double StainlessSteelFeedPerToothMinimum { get; set; }
        public double StainlessSteelFeedPerToothMaximum { get; set; }

        public double AlluminiumFeedPerToothMinimum { get; set; }
        public double AlluminiumFeedPerToothMaximum { get; set; }

        //foreign keys
        public int GradeId { get; set; }

        public virtual Grade Grade { get; set; }
    }
}
