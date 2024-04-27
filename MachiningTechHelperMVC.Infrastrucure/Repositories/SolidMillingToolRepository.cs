﻿using MachiningTechHelperMVC.Domain.Interfaces;
using MachiningTechHelperMVC.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Infrastrucure.Repositories
{
    public class SolidMillingToolRepository : ISolidMillingToolRepository
    {
        private readonly Context _context;
        public SolidMillingToolRepository(Context context)
        {
            _context = context;
        }
        public int AddSolidMillingTool(SolidMillingTool solidMillingTool)
        {
            var solidMillingTools = _context.SolidMillingTools.Add(solidMillingTool);
            _context.SaveChanges();
            return solidMillingTool.Id;
        }

        public void DeleteSolidMillingTool(int solidMillingToolId)
        {
            var solidMillingTool = _context.SolidMillingTools.Find(solidMillingToolId);
            if (solidMillingTool != null)
            {
                _context.SolidMillingTools.Remove(solidMillingTool);
                _context.SaveChanges();
            }
        }

        public IQueryable<SolidMillingTool> GetSolidMillingToolByDiameter(double diameter)
        {
            var solidMillingTools = _context.SolidMillingTools.Where(s => s.Diameter == diameter);
            return solidMillingTools;
        }

        public SolidMillingTool GetSolidMillingToolById(int solidMillingToolId) // Need to add other nested properties !!!
        {
            var solidMillingTool = _context.SolidMillingTools
                .Include(s => s.Producer)
                .Include(s => s.SolidMillingToolParametersRanges)
                .Include(s => s.SolidMillingToolCheckedParameters)
                .FirstOrDefault(s => s.Id == solidMillingToolId);
            return solidMillingTool;
        }

        public IQueryable<SolidMillingTool> GetSolidMillingToolByProducer(int ProducerId)
        {
            var solidMillingTools = _context.SolidMillingTools.Where(s => s.ProducerId == ProducerId);
            return solidMillingTools;
        }

        public void UpdateSolidMillingTool(SolidMillingTool solidMillingToolToUpdate)
        {
            var existingSolidMillingTool = _context.SolidMillingTools
                .Include(s => s.Producer)
                .Include(s => s.SolidMillingToolParametersRanges)
                .Include(s => s.SolidMillingToolCheckedParameters)
                .FirstOrDefault(s => s.Id == solidMillingToolToUpdate.Id);

            if (existingSolidMillingTool != null)
            {
                existingSolidMillingTool.Diameter = solidMillingToolToUpdate.Diameter;
                existingSolidMillingTool.Designation = solidMillingToolToUpdate.Designation;
                existingSolidMillingTool.Description = solidMillingToolToUpdate.Description;
                existingSolidMillingTool.Radius = solidMillingToolToUpdate.Radius;
                existingSolidMillingTool.TeethNumber = solidMillingToolToUpdate.TeethNumber;
                existingSolidMillingTool.Lcut = solidMillingToolToUpdate.Lcut;
                existingSolidMillingTool.ToolType = solidMillingToolToUpdate.ToolType;
                _context.SaveChanges();
            }

            if (solidMillingToolToUpdate.Producer != null)
            {
                existingSolidMillingTool.Producer = solidMillingToolToUpdate.Producer;
                _context.SaveChanges();
            }
        }

        public IQueryable<SolidMillingTool> GetAllSolidMillingTools()
        {
            var solidMillingTools = _context.SolidMillingTools
                .Include(s => s.Producer)
                .Include(s => s.SolidMillingToolParametersRanges)
                .Include(s => s.SolidMillingToolCheckedParameters);
            return solidMillingTools;
        }
    }
}
