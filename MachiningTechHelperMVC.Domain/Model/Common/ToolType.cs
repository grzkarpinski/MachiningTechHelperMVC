using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Domain.Model.Common
{
    public enum ToolType
    {
        drillHSS,
        drillSolidCarbide,
        drillHeadCarbide,
        drillIndexable,

        solidEndMillHSS,
        solidEndMillCarbide,
        SolidEndMillTSC,
        solidBallNoseMill,

        highFeedMill,
        shoulderMill,
        faceMill,
        tSlotMill,
        profileMill,
        chamferMill,
        solidHeadMill,
    }
}
