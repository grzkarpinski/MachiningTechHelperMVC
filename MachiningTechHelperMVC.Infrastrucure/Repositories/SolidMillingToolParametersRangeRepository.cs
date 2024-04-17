using MachiningTechHelperMVC.Domain.Interfaces;
using MachiningTechHelperMVC.Domain.Model;

namespace MachiningTechHelperMVC.Infrastrucure.Repositories
{
    public class SolidMillingToolParametersRangeRepository : ISolidMillingToolParametersRangeRepository
    {
        private readonly Context _context;

        public SolidMillingToolParametersRangeRepository(Context context)
        {
            _context = context;
        }
        public int AddSolidMillingToolParametersRange(SolidMillingToolParametersRange solidMillingToolParametersRange)
        {
            _context.SolidMillingToolParametersRanges.Add(solidMillingToolParametersRange);
            _context.SaveChanges();
            return solidMillingToolParametersRange.Id;
        }

        public void DeleteSolidMillingToolParametersRange(int solidMillingToolParametersRangeId)
        {
            var solidMillingToolParametersRange = _context.SolidMillingToolParametersRanges.Find(solidMillingToolParametersRangeId);
            if (solidMillingToolParametersRange != null)
            {
                _context.SolidMillingToolParametersRanges.Remove(solidMillingToolParametersRange);
                _context.SaveChanges();
            }
        }

        public IEnumerable<SolidMillingToolParametersRange> GetAllSolidMillingToolParametersRanges()
        {
            return _context.SolidMillingToolParametersRanges;
        }

        public SolidMillingToolParametersRange GetSolidMillingToolParametersRangeById(int solidMillingToolParametersRangeId)
        {
            var solidMillingToolParametersRange = _context.SolidMillingToolParametersRanges.FirstOrDefault(p => p.Id == solidMillingToolParametersRangeId);
            return solidMillingToolParametersRange;
        }

        public void UpdateSolidMillingToolParametersRange(SolidMillingToolParametersRange solidMillingToolParametersRange)
        {
            _context.Attach(solidMillingToolParametersRange);
            _context.Entry(solidMillingToolParametersRange).Property("GradeName").IsModified = true;
            _context.Entry(solidMillingToolParametersRange).Property("Description").IsModified = true;
            _context.Entry(solidMillingToolParametersRange).Property("Material").IsModified = true;
            _context.Entry(solidMillingToolParametersRange).Property("CuttingSpeedMinimum").IsModified = true;
            _context.Entry(solidMillingToolParametersRange).Property("CuttingSpeedMaximum").IsModified = true;
            _context.Entry(solidMillingToolParametersRange).Property("FeedPerRevisionMinimum").IsModified = true;
            _context.Entry(solidMillingToolParametersRange).Property("FeedPerRevisionMaximum").IsModified = true;
            _context.SaveChanges();
        }
    }
}
