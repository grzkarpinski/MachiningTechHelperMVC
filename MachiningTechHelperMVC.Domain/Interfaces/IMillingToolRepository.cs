﻿using MachiningTechHelperMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Domain.Interfaces
{
    public interface IMillingToolRepository
    {
        void DeleteMillingTool(int millingToolId);

        void DeleteMillingToolSoft(int millingToolId);

        int AddMillingTool(MillingTool millingTool);

        MillingTool GetMillingToolById(int millingToolId);

        IQueryable<MillingInsert> GetMillingInserts();

        void UpdateMillingTool(MillingTool millingToolToUpdate);

        IQueryable<MillingTool> GetAllMillingTools();

    }
}
