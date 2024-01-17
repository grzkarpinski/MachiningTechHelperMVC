using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Domain.Model
{
    public class MillingToolMillingInsert
    {
        public int MillingToolId { get; set; }
        public int MillingInsertId { get; set; }

        public virtual MillingTool MillingTool { get; set; }
        public virtual MillingInsert MillingInsert { get; set; }
    }
}
