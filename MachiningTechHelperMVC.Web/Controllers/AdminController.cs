using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MachiningTechHelperMVC.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AdminController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        //DONE
        public IActionResult Index()
        {
            return View();
        }

        //add security authentication only for admin


        //DONE
        public IActionResult Roles()
        {
            return View(_roleManager.Roles);
        }

        //DONE
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRole(string roleName)
        {
            if (string.IsNullOrEmpty(roleName) == false)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = roleName
                };
                IdentityResult result = _roleManager.CreateAsync(role).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction("Roles");
                }
            }
            return View(roleName);
        }


        //DONE
        public IActionResult DeleteRole(string id)
        {
            IdentityRole role = _roleManager.FindByIdAsync(id).Result;
            if (role != null)
            {
                IdentityResult result = _roleManager.DeleteAsync(role).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction("Roles");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "No role found");
            }
            return View("Roles", _roleManager.Roles);
        }

        //TODO: Add methods for managing users

    }
}
