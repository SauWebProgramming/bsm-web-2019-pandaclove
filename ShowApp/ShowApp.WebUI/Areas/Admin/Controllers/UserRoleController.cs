using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ShowApp.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserRoleController : Controller
    {
        private RoleManager<IdentityRole> RoleManager;
        public UserRoleController(RoleManager<IdentityRole> roleManager)
        {
            RoleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View(RoleManager.Roles);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(string name)
        {
            if(ModelState.IsValid)
            {
                var result = await RoleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(name);
        }
    }
}