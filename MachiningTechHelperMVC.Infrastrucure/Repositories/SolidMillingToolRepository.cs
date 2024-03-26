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
                .Include(s => s.Grade)
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
            _context.Attach(solidMillingToolToUpdate);
            _context.Entry(solidMillingToolToUpdate).Property("Diameter").IsModified = true;
            _context.Entry(solidMillingToolToUpdate).Property("TeethNumber").IsModified = true;
            _context.Entry(solidMillingToolToUpdate).Property("Radius").IsModified = true;
            _context.Entry(solidMillingToolToUpdate).Property("Producer").IsModified = true;
            _context.Entry(solidMillingToolToUpdate).Property("Grade").IsModified = true;
            _context.SaveChanges();
        }
    }
}
