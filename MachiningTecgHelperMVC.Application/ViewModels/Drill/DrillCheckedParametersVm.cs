using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Application.ViewModels.Drill
{
    public class DrillCheckedParametersVm
    {
        public int Id { get; set; }
        public string Material { get; set; }
        public int RevisionsPerMinute { get; set; }
        public int FeedPerMinute { get; set; }

    }
}
