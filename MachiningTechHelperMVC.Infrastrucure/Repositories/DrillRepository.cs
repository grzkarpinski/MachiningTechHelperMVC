using MachiningTechHelperMVC.Domain.Interfaces;
using MachiningTechHelperMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Infrastrucure.Repositories
{
    internal class DrillRepository : IDrillRepository
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

        public IQueryable<Drill> GetDrillByDiameter(double diameter)
        {
            var drills = _context.Drills.Where(d => d.Diameter == diameter);
            return drills;
        }

        public Drill GetDrillById(int drillId)
        {
            var drill = _context.Drills.FirstOrDefault(d => d.Id == drillId);
            return drill;
        }

        public IQueryable<Drill> GetDrillByProducer(int ProducerId)
        {
            var drills = _context.Drills.Where(d => d.ProducerId == ProducerId);
            return drills;
        }

        public IQueryable<Drill> GetAllDrills()
        {
            return _context.Drills;
        }
    }
}
