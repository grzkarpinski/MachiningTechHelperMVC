using MachiningTechHelperMVC.Domain.Interfaces;
using MachiningTechHelperMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Infrastrucure.Repositories
{
    public class MillingInsertRepository : IMillingInsertRepository
    {
        private readonly Context _context;

        public MillingInsertRepository(Context context)
        {
            _context = context;
        }
        public int AddMillingInsert(MillingInsert millingInsert)
        {
            var millingInserts = _context.MillingInserts.Add(millingInsert);
            _context.SaveChanges();
            return millingInsert.Id;
        }

        public void DeleteMillingInsert(int millingInsertId)
        {
            var millingInsert = _context.MillingInserts.Find(millingInsertId);
            if (millingInsert != null)
            {
                _context.MillingInserts.Remove(millingInsert);
                _context.SaveChanges();
            }
        }

        public MillingInsert GetMillingInsertById(int milling)
        {
            var millingInsert = _context.MillingInserts.Find(milling);
            return millingInsert;
        }

        public List<MillingInsert> GetAllMillingInserts()
        {
            return _context.MillingInserts.ToList();
        }
    }
}
