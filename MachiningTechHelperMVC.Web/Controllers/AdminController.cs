using MachiningTechelperMVC.Application.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MachiningTechHelperMVC.Web.Controllers
{
    [Authorize(Roles="admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AdminController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Roles()
        {
            return View(_roleManager.Roles);
        }

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
            }
            return View("Roles", _roleManager.Roles);
        }

        public IActionResult Users()
        {
            return View(_userManager.Users);
        }

        public IActionResult DeleteUser(string id)
        {
            IdentityUser user = _userManager.FindByIdAsync(id).Result;
            if (user != null)
            {
                IdentityResult result = _userManager.DeleteAsync(user).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction("Users");
                }
            }
            return View("Users", _userManager.Users);
        }

        public async Task<IActionResult> UserDetails(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.Select(r => r.Name).ToList();
                var model = new UserDetailsVm
                {
                    User = user,
                    Roles = roles,
                    AllRoles = allRoles
                };
                return View(model);
            }
            else
            {
                return RedirectToAction("Users");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(string id, UserDetailsVm model)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null && !string.IsNullOrEmpty(model.SelectedRole))
            {
                var result = await _userManager.AddToRoleAsync(user, model.SelectedRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("UserDetails", new { id = user.Id });
                }
            }
            return RedirectToAction("Users");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveRole(string id, string role)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                var result = await _userManager.RemoveFromRoleAsync(user, role);
                if (result.Succeeded)
                {
                    return RedirectToAction("UserDetails", new { id = user.Id });
                }
            }
            return RedirectToAction("Users");
        }
    }
}
