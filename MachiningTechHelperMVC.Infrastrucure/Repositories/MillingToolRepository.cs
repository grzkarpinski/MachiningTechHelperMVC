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
    public class MillingToolRepository: IMillingToolRepository
    {
        private readonly Context _context;
        public MillingToolRepository(Context context)
        {
            _context = context;
        }

        public void DeleteMillingTool(int millingToolId) 
        {
            var millingTool = _context.MillingTools.Find(millingToolId);
            if (millingTool != null)
            {
                _context.MillingTools.Remove(millingTool);
                _context.SaveChanges();
            }
        }

        public int AddMillingTool(MillingTool millingTool)
        {
            _context.MillingTools.Add(millingTool);
            _context.SaveChanges();
            return millingTool.Id;
        }

        public IQueryable<MillingTool> GetMillingToolByDiameter(double diameter)
        {
            var millingTools =  _context.MillingTools.Where(m => m.Diameter == diameter);
            return millingTools;

        }
        public MillingTool GetMillingToolById(int millingToolId) // Need to add other nested properties !!!
        {
            var millingTool = _context.MillingTools
                .Include(m => m.Producer)
                .FirstOrDefault(m => m.Id == millingToolId);
            return millingTool;
        }

        public IQueryable<MillingInsert> GetMillingInserts()
        {
            var millingInserts = _context.MillingInserts;
            return millingInserts;
        }

        public IQueryable<MillingTool> GetMillingToolByProducer(int producerId)
        {
            var millingTools = _context.MillingTools.Where(m => m.ProducerId == producerId);
            return millingTools;
        }

        public void UpdateMillingTool(MillingTool millingToolToUpdate)
        {
            var existingMillingTool = _context.MillingTools
                .Include(m => m.Producer)
                .FirstOrDefault(m => m.Id == millingToolToUpdate.Id);

            if (existingMillingTool != null)
            {
                _context.Attach(millingToolToUpdate);
                _context.Entry(millingToolToUpdate).Property("Diameter").IsModified = true;
                _context.Entry(millingToolToUpdate).Property("Designation").IsModified = true;
                _context.Entry(millingToolToUpdate).Property("TeethNumber").IsModified = true;
                _context.SaveChanges();
            }
        }
    }
}
