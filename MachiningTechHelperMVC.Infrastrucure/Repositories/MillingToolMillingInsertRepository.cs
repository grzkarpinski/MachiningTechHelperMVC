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
        public void Add(int millingToolId, int millingInsertId)
        {
            var existingRecord = _context.MillingToolMillingInserts
                .FirstOrDefault(m => m.MillingToolId == millingToolId && m.MillingInsertId == millingInsertId);

            if (existingRecord == null)
            {
                var link = new MillingToolMillingInsert
                {
                    MillingToolId = millingToolId,
                    MillingInsertId = millingInsertId
                };
                _context.MillingToolMillingInserts.Add(link);
                _context.SaveChanges();
            }
            //else
            //{
            //    // Handle existing record (update, skip, etc.)
            //    // For now, we'll just do nothing.
            //}
        }


        public void Delete(int millingToolId, int millingInsertId)
        {
            var link = _context.MillingToolMillingInserts.FirstOrDefault(x => x.MillingToolId == millingToolId && x.MillingInsertId == millingInsertId);
            if (link != null)
            {
                _context.MillingToolMillingInserts.Remove(link);
                _context.SaveChanges();
            }

        }

        public MillingToolMillingInsert GetById(int millingToolId, int millingInsertId)
        {
            var millingToolMillingInsert = _context.MillingToolMillingInserts.FirstOrDefault(x => x.MillingToolId == millingToolId && x.MillingInsertId == millingInsertId);
            return millingToolMillingInsert;
        }
    }
}
