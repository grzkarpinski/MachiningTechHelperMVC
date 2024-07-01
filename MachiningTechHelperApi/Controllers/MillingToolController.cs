using MachiningTechelperMVC.Application.Interfaces;
using MachiningTechelperMVC.Application.ViewModels.MillingTool;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MachiningTechHelperApi.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class MillingToolController : ControllerBase
    {
        private readonly IMillingToolService _millingToolService;

        public MillingToolController(IMillingToolService millingToolService)
        {
            _millingToolService = millingToolService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MillingToolForListVm>> Index(int pageSize = 10, int pageNo = 1, string searchString = "")
        {
            var model = _millingToolService.GetAllMillingToolsForList(pageSize, pageNo, searchString);
            return Ok(model);
        }

        [HttpGet("{id}")]
        public ActionResult<MillingToolDetailsVm> ViewMillingTool(int id)
        {
            var millingToolModel = _millingToolService.GetMillingToolDetails(id);
            if (millingToolModel == null)
            {
                return NotFound();
            }
            return Ok(millingToolModel);
        }
    }
}