using MachiningTechHelperMVC.Domain.Interfaces;
using MachiningTechHelperMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiningTechHelperMVC.Infrastrucure.Repositories
{
    public class DrillCheckedParametersRepository : IDrillCheckedParametersRepository
    {
        private readonly Context _context;
        public DrillCheckedParametersRepository(Context context)
        {
            _context = context;
        }
        public int AddDrillCheckedParameters(DrillCheckedParameters drillCheckedParameters)
        {
            _context.DrillsCheckedParameters.Add(drillCheckedParameters);
            _context.SaveChanges();
            return drillCheckedParameters.Id;
        }

        public void DeleteDrillCheckedParameters(int drillCheckedParametersId)
        {
            var drillCheckedParameters = _context.DrillsCheckedParameters.Find(drillCheckedParametersId);
            if (drillCheckedParameters != null)
            {
                _context.DrillsCheckedParameters.Remove(drillCheckedParameters);
                _context.SaveChanges();
            }
        }

        public IQueryable<DrillCheckedParameters> GetDrillCheckedParametersbyTool(int drillId)
        {
            var drillCheckedParameters = _context.DrillsCheckedParameters.Where(d => d.DrillId == drillId);
            return drillCheckedParameters;
        }
    }
}
