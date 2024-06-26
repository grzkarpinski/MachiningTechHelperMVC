using MachiningTechHelperMVC.Application.Interfaces;
using MachiningTechHelperMVC.Application.ViewModels.Drill;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MachiningTechHelperApi.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class DrillController : ControllerBase
    {
        private readonly IDrillService _drillService;
        public DrillController(IDrillService drillService)
        {
            _drillService = drillService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DrillForListVm>> Index(int pageSize = 10, int pageNo = 1, string searchString = "")
        {
            var model = _drillService.GetAllDrillsForList(pageSize, pageNo, searchString);
            return Ok(model);
        }

        [HttpGet("{id}")]
        public ActionResult<DrillDetailsVm> ViewDrill(int id)
        {
            var drillModel = _drillService.GetDrillDetails(id);
            if (drillModel == null)
            {
                return NotFound();
            }

            return Ok(drillModel);
        }
    }
}
