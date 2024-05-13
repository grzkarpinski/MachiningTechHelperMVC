using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Domain.Model.Common
{
    public enum ToolType
    {
        drill_HSS,
        drill_VHM,
        drill_VHM_head,
        drill_Indexable,

        solid_EndMill_HSS,
        solid_EndMill_VHM,
        Solid_EndMill_TSC,
        solid_BallNoseMill,

        HF_Mill,
        shoulder_Mill,
        faceMill,
        tSlot_Mill,
        profile_Mill,
        chamfer_Mill,
        solidHead_Mill,
    }
}
