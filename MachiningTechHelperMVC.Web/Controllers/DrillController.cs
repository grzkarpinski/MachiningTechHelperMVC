//using Microsoft.AspNetCore.Mvc;

//namespace MachiningTechHelperMVC.Web.Controllers
//{
//    public class DrillController : Controller // WIP
//    {
//        public IActionResult Index()
//        {
//            var model = drillService.GetAllDrillsForList();
//            return View(model);
//        }
//        [HttpGet]
//        public IActionResult AddDrill()
//        {
//            return View();
//        }

//        [HttpPost]
//        public IActionResult AddDrill(DrillModel drill)
//        {
//            var id = drillService.AddDrill(drill);
//            return View();
//        }

//        public IActionResult ViewDrill(int id)
//        {
//            var drillModel = drillService.GetDrillById(id);
//            return View(drillModel);
//        }
//    }
//}
