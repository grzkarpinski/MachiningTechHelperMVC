using MachiningTechHelperMVC.Domain.Interfaces;
using MachiningTechHelperMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Infrastrucure.Repositories
{
    public class SolidMillingToolCheckedParametersRepository : ISolidMillingToolCheckedParametersRepository
    {
        private readonly Context _context;
        public SolidMillingToolCheckedParametersRepository(Context context)
        {
            _context = context;
        }
        public int AddSolidMillingToolCheckedParameters(SolidMillingToolCheckedParameters solidMillingToolCheckedParameters)
        {
            _context.SolidMillingToolsCheckedParameters.Add(solidMillingToolCheckedParameters);
            _context.SaveChanges();
            return solidMillingToolCheckedParameters.Id;
        }

        public void DeleteSolidMillingToolCheckedParameters(int solidMillingToolCheckedParametersId)
        {
            var solidMillingToolCheckedParameters = _context.SolidMillingToolsCheckedParameters.Find(solidMillingToolCheckedParametersId);
            if (solidMillingToolCheckedParameters != null)
            {
                _context.SolidMillingToolsCheckedParameters.Remove(solidMillingToolCheckedParameters);
                _context.SaveChanges();
            }
        }

        public IQueryable<SolidMillingToolCheckedParameters> GetSolidMillingToolCheckedParametersbyTool(int solidMillingToolId)
        {
            var solidMillingToolCheckedParameters = _context.SolidMillingToolsCheckedParameters.Where(m => m.SolidMillingToolId == solidMillingToolId);
            return solidMillingToolCheckedParameters;
        }

        public SolidMillingToolCheckedParameters GetSolidMillingToolCheckedParametersById(int Id)
        {
            var solidMillingToolCheckedParameters = _context.SolidMillingToolsCheckedParameters.Find(Id);
            return solidMillingToolCheckedParameters;
        }

        public void UpdateSolidMillingToolCheckedParameters(SolidMillingToolCheckedParameters solidMillingToolCheckedParametersToUpdate)
        {
            _context.Attach(solidMillingToolCheckedParametersToUpdate);
            _context.Entry(solidMillingToolCheckedParametersToUpdate).Property("Material").IsModified = true;
            _context.Entry(solidMillingToolCheckedParametersToUpdate).Property("RevisionsPerSecond").IsModified = true;
            _context.Entry(solidMillingToolCheckedParametersToUpdate).Property("FeedPerMinute").IsModified = true;
            _context.Entry(solidMillingToolCheckedParametersToUpdate).Property("cuttingDepth").IsModified = true;
            _context.SaveChanges();
        }
    }
}
