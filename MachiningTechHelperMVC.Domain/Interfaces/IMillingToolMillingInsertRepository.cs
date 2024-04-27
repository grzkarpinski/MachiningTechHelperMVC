﻿using MachiningTechHelperMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Domain.Interfaces
{
    public interface IMillingToolMillingInsertRepository // for junction table
    {
        MillingToolMillingInsert GetById(int millingToolId, int millingInsertId);
        void Add(MillingToolMillingInsert millingToolMillingInsert);
        void Delete(MillingToolMillingInsert millingToolMillingInsert);
    }
}
