using MachiningTechelperMVC.Application.Interfaces;
using MachiningTechelperMVC.Application.ViewModels.CostEstimation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MachiningTechHelperApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CostEstimationController : ControllerBase
    {
        private readonly ICostEstimationLogic _costEstimationLogic;

        public CostEstimationController(ICostEstimationLogic costEstimationLogic)
        {
            _costEstimationLogic = costEstimationLogic;
        }

        [HttpGet]
        public ActionResult<CostEstimationVm> Index()
        {
            var model = new CostEstimationVm();
            return Ok(model);
        }

        [HttpPost]
        public ActionResult Index([FromBody]CostEstimationVm model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _costEstimationLogic.CalculateCosts(model);
            return Ok(result);
        }
    }
}
