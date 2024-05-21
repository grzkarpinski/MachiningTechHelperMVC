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
    public class DrillRepository : IDrillRepository
    {
        private readonly Context _context;
        public DrillRepository(Context context)
        {
            _context = context;
        }
        public int AddDrill(Drill drill)
        {
            _context.Drills.Add(drill);
            _context.SaveChanges();
            return drill.Id;
        }

        public void DeleteDrill(int drillId)
        {
            var drill = _context.Drills.Find(drillId);
            if (drill != null)
            {
                _context.Drills.Remove(drill);
                _context.SaveChanges();
            }
        }

        public Drill GetDrillById(int drillId)
        {
            var drill = _context.Drills
                .Include(d => d.Producer)
                .Include(d => d.DrillParametersRanges)
                .Include(d => d.DrillCheckedParameters)
                .FirstOrDefault(d => d.Id == drillId);
            return drill;
        }

        public IQueryable<Drill> GetAllDrills()
        {
            return _context.Drills.Where(p => p.IsToolActive)
                .OrderBy(p => p.Diameter);
        }

        public void UpdateDrill(Drill drillToUpdate)
        {
            // Check if the Drill already exists in the database
            var existingDrill = _context.Drills
                                        .Include(d => d.Producer)
                                        .Include(d => d.DrillParametersRanges)
                                        .Include(d => d.DrillCheckedParameters)
                                        .FirstOrDefault(d => d.Id == drillToUpdate.Id);

            if (existingDrill != null)
            {
                // Update the properties of the existing Drill
                existingDrill.Diameter = drillToUpdate.Diameter;
                existingDrill.Designation = drillToUpdate.Designation;
                existingDrill.Description = drillToUpdate.Description;
                existingDrill.ToolType = drillToUpdate.ToolType;
                existingDrill.LengthXDiameter = drillToUpdate.LengthXDiameter;
                existingDrill.TipAngle = drillToUpdate.TipAngle;

                // Check if the Producer is not null before trying to update it
                if (drillToUpdate.Producer != null)
                {
                    // Update the properties of the existing Producer
                    existingDrill.Producer.CompanyName = drillToUpdate.Producer.CompanyName;
                }

                _context.SaveChanges();
            }
        }
    }
}
