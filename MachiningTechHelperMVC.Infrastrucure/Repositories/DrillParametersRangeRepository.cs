using MachiningTechHelperMVC.Domain.Interfaces;
using MachiningTechHelperMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Infrastrucure.Repositories
{
    internal class DrillParametersRangeRepository : IDrillParametersRangeRepository
    {
        private readonly Context _context;

        public DrillParametersRangeRepository(Context context)
        {
            _context = context;
        }
        public int AddDrillParametersRange(DrillParametersRange drillParametersRange)
        {
            _context.DrillParametersRanges.Add(drillParametersRange);
            _context.SaveChanges();
            return drillParametersRange.Id;
        }

        public void DeleteDrillParametersRange(int drillParametersRangeId)
        {
            var drillParametersRange = _context.DrillParametersRanges.Find(drillParametersRangeId);
            if (drillParametersRange != null)
            {
                _context.DrillParametersRanges.Remove(drillParametersRange);
                _context.SaveChanges();
            }
        }

        public IEnumerable<DrillParametersRange> GetAllDrillParametersRanges()
        {
            return _context.DrillParametersRanges;
        }

        public DrillParametersRange GetDrillParametersRangeById(int drillParametersRangeId)
        {
            var drillParametersRange = _context.DrillParametersRanges.FirstOrDefault(p => p.Id == drillParametersRangeId);
            return drillParametersRange;
        }

        public void UpdateDrillParametersRange(DrillParametersRange drillParametersRange)
        {
            _context.Attach(drillParametersRange);
            _context.Entry(drillParametersRange).Property("GradeName").IsModified = true;
            _context.Entry(drillParametersRange).Property("Description").IsModified = true;
            _context.Entry(drillParametersRange).Property("Material").IsModified = true;
            _context.Entry(drillParametersRange).Property("CuttingSpeedMinimum").IsModified = true;
            _context.Entry(drillParametersRange).Property("CuttingSpeedMaximum").IsModified = true;
            _context.Entry(drillParametersRange).Property("FeedPerRevisionMinimum").IsModified = true;
            _context.Entry(drillParametersRange).Property("FeedPerRevisionMaximum").IsModified = true;
            _context.SaveChanges();
        }
    }
}
