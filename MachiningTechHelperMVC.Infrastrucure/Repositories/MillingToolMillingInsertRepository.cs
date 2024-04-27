using MachiningTechHelperMVC.Domain.Interfaces;
using MachiningTechHelperMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Infrastrucure.Repositories
{
    public class MillingToolMillingInsertRepository : IMillingToolMillingInsertRepository
    {
        private readonly Context _context;

        public MillingToolMillingInsertRepository(Context context)
        {
            _context = context;
        }
        public void Add(MillingToolMillingInsert millingToolMillingInsert)
        {
            _context.MillingToolMillingInserts.Add(millingToolMillingInsert);
            _context.SaveChanges();
        }

        public void Delete(MillingToolMillingInsert millingToolMillingInsert)
        {
            _context.MillingToolMillingInserts.Remove(millingToolMillingInsert);
            _context.SaveChanges();

        }

        public MillingToolMillingInsert GetById(int millingToolId, int millingInsertId)
        {
            var millingToolMillingInsert = _context.MillingToolMillingInserts.FirstOrDefault(x => x.MillingToolId == millingToolId && x.MillingInsertId == millingInsertId);
            return millingToolMillingInsert;
        }
    }
}
