using MachiningTechHelperMVC.Domain.Interfaces;
using MachiningTechHelperMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Infrastrucure.Repositories
{
    public class MillingToolCheckedParametersRepository : IMillingToolCheckedParametersRepository
    {
        private readonly Context _context;
        public MillingToolCheckedParametersRepository(Context context)
        {
            _context = context;
        }
        public int AddMillingToolCheckedParameters(MillingToolCheckedParameters millingToolCheckedParameters)
        {
            _context.MillingToolsCheckedParameters.Add(millingToolCheckedParameters);
            _context.SaveChanges();
            return millingToolCheckedParameters.Id;
        }

        public void DeleteMillingToolCheckedParameters(int millingToolCheckedParametersId)
        {
            var millingToolCheckedParameters = _context.MillingToolsCheckedParameters.Find(millingToolCheckedParametersId);
            if (millingToolCheckedParameters != null)
            {
                _context.MillingToolsCheckedParameters.Remove(millingToolCheckedParameters);
                _context.SaveChanges();
            }
        }

        public IQueryable<MillingToolCheckedParameters> GetMillingToolCheckedParametersbyTool(int millingToolId)
        {
            var millingToolCheckedParameters = _context.MillingToolsCheckedParameters.Where(m => m.MillingToolId == millingToolId);
            return millingToolCheckedParameters;
        }

        public void UpdateMillingToolCheckedParameters(MillingToolCheckedParameters millingToolCheckedParametersToUpdate)
        {
            _context.Attach(millingToolCheckedParametersToUpdate);
            _context.Entry(millingToolCheckedParametersToUpdate).Property("Material").IsModified = true;
            _context.Entry(millingToolCheckedParametersToUpdate).Property("RevisionsPerSecond").IsModified = true;
            _context.Entry(millingToolCheckedParametersToUpdate).Property("FeedPerMinute").IsModified = true;
            _context.Entry(millingToolCheckedParametersToUpdate).Property("CuttingDepth").IsModified = true;
            _context.SaveChanges();
        }
    }
}
