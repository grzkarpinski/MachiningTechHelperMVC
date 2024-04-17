using MachiningTechHelperMVC.Domain.Interfaces;
using MachiningTechHelperMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Infrastrucure.Repositories
{
    public class MillingInsertParametersRangeRepository : IMillingInsertParametersRangeRepository
    {
        private readonly Context _context;

        public MillingInsertParametersRangeRepository(Context context)
        {
            _context = context;
        }

        public int AddMillingInsertParametersRange(MillingInsertParametersRange millingInsertParametersRange)
        {
            _context.MillingInsertParametersRange.Add(millingInsertParametersRange);
            _context.SaveChanges();
            return millingInsertParametersRange.Id;
        }

        public void DeleteMillingInsertParametersRange(int millingInsertParametersRangeId)
        {
            var millingInsertParametersRange = _context.MillingInsertParametersRange.Find(millingInsertParametersRangeId);
            if (millingInsertParametersRange != null)
            {
                _context.MillingInsertParametersRange.Remove(millingInsertParametersRange);
                _context.SaveChanges();
            }
        }

        public IEnumerable<MillingInsertParametersRange> GetAllMillingInsertParametersRanges()
        {
            return _context.MillingInsertParametersRange;
        }

        public MillingInsertParametersRange GetMillingInsertParametersRangeById(int millingImsertParametersRangeId)
        {
            var millingInsertParametersRange = _context.MillingInsertParametersRange.FirstOrDefault(p => p.Id == millingImsertParametersRangeId);
            return millingInsertParametersRange;
        }

        public void UpdateMillingInsertParametersRange(MillingInsertParametersRange millingInsertParametersRange)
        {
            _context.Attach(millingInsertParametersRange);
            _context.Entry(millingInsertParametersRange).Property("GradeName").IsModified = true;
            _context.Entry(millingInsertParametersRange).Property("Description").IsModified = true;
            _context.Entry(millingInsertParametersRange).Property("Material").IsModified = true;
            _context.Entry(millingInsertParametersRange).Property("CuttingSpeedMinimum").IsModified = true;
            _context.Entry(millingInsertParametersRange).Property("CuttingSpeedMaximum").IsModified = true;
            _context.Entry(millingInsertParametersRange).Property("FeedPerRevisionMinimum").IsModified = true;
            _context.Entry(millingInsertParametersRange).Property("FeedPerRevisionMaximum").IsModified = true;
            _context.SaveChanges();
        }
    }
}
