using MachiningTechHelperMVC.Domain.Interfaces;
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

        public void DeleteMillingToolSoft(int millingToolId)
        {
            var millingTool = _context.MillingTools.Find(millingToolId);
            if (millingTool != null)
            {
                millingTool.IsToolActive = false;
                _context.SaveChanges();
            }
        }

        public int AddMillingTool(MillingTool millingTool)
        {
            _context.MillingTools.Add(millingTool);
            _context.SaveChanges();
            return millingTool.Id;
        }

        public MillingTool GetMillingToolById(int millingToolId)
        {
            var millingTool = _context.MillingTools
                .Include(m => m.Producer)
                .Include(m => m.MillingToolMillingInserts)
                .ThenInclude(m => m.MillingInsert)
                .Include(m => m.MillingToolCheckedParameters)
                .FirstOrDefault(m => m.Id == millingToolId);
            return millingTool;
        }

        public IQueryable<MillingInsert> GetMillingInserts()
        {
            var millingInserts = _context.MillingInserts;
            return millingInserts;
        }

        public void UpdateMillingTool(MillingTool millingToolToUpdate)
        {
            var existingMillingTool = _context.MillingTools
                .Include(m => m.Producer)
                .Include(m => m.MillingToolMillingInserts)
                .ThenInclude(m => m.MillingInsert)
                .Include(m => m.MillingToolCheckedParameters)
                .FirstOrDefault(m => m.Id == millingToolToUpdate.Id);

            if (existingMillingTool != null)
            {
                existingMillingTool.Diameter = millingToolToUpdate.Diameter;
                existingMillingTool.Designation = millingToolToUpdate.Designation;
                existingMillingTool.Description = millingToolToUpdate.Description;
                existingMillingTool.TeethNumber = millingToolToUpdate.TeethNumber;
                existingMillingTool.ToolType = millingToolToUpdate.ToolType;
                _context.SaveChanges();
            }

            if (millingToolToUpdate.Producer != null)
            {
                existingMillingTool.Producer = millingToolToUpdate.Producer;
                _context.SaveChanges();
            }
        }

        public IQueryable<MillingTool> GetAllMillingTools()
        {
            var millingTools = _context.MillingTools
                .Include(m => m.Producer)
                .Include(m => m.MillingToolMillingInserts)
                .Include(m => m.MillingToolCheckedParameters)
                .OrderBy(m => m.Diameter);
            return millingTools;
        }
    }
}
