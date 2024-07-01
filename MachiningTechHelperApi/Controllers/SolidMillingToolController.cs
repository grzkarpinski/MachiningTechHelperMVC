using MachiningTechelperMVC.Application.Interfaces;
using MachiningTechelperMVC.Application.ViewModels.MillingTool;
using MachiningTechelperMVC.Application.ViewModels.SolidMillingTool;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MachiningTechHelperApi.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class SolidMillingToolController : ControllerBase
    {
        private readonly ISolidMillingToolService _solidMillingToolService;

        public SolidMillingToolController(ISolidMillingToolService solidMillingToolService)
        {
            _solidMillingToolService = solidMillingToolService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MillingToolForListVm>> Index(int pageSize = 10, int pageNo = 1, string searchString = "")
        {
            var model = _solidMillingToolService.GetAllSolidMillingToolsForList(pageSize, pageNo, searchString);
            return Ok(model);
        }

        [HttpGet("{id}")]
        public ActionResult<SolidMillingToolDetailsVm> ViewSolidMillingTool(int id)
        {
            var toolModel = _solidMillingToolService.GetSolidMillingToolDetails(id);
            if (toolModel == null)
            {
                return NotFound();
            }
            return Ok(toolModel);
        }
    }
}
