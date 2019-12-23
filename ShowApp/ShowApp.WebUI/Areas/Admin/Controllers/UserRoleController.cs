using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShowApp.Data.Concrete.EfCore.Identity;
using ShowApp.WebUI.Models;

namespace ShowApp.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class UserRoleController : Controller
    {
        private RoleManager<IdentityRole> RoleManager;
        private UserManager<AppUser> UserManager;
        public UserRoleController(RoleManager<IdentityRole> roleManager,
                                   UserManager<AppUser> userManager )
        {
            RoleManager = roleManager;
            UserManager = userManager;
        }
        public IActionResult Index()
        {
            return View(RoleManager.Roles);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            IdentityRole role = await RoleManager.FindByIdAsync(id);
            var members = new List<AppUser>();
            var nonmembers = new List<AppUser>();
            foreach(var user in UserManager.Users)
            {
                var list = await UserManager.IsInRoleAsync(user, role.Name)
                           ? members : nonmembers;
                list.Add(user);
            }
            var model = new RoleDetails()
            {
                Role= role,
                Members = members,
                NonMembers = nonmembers
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(RoleEditModel model)
        {
            IdentityResult result;
            if(ModelState.IsValid)
            {
                foreach (var item in model.IdsToAdd ?? new string[]{ })
                {
                    var user = await UserManager.FindByIdAsync(item);
                    if(user != null)
                    {
                        result = await UserManager.AddToRoleAsync(user, model.RoleName);
                        if(result.Succeeded)
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            foreach(var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                }

                foreach (var item in model.IdsToDelete ?? new string[] { })
                {
                    var user = await UserManager.FindByIdAsync(item);
                    if (user != null)
                    {
                        result = await UserManager.RemoveFromRoleAsync(user, model.RoleName);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                }

            }
            return RedirectToAction("Index");
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
        [HttpPost]
        public async  Task<IActionResult> Delete(string id)
        {
            var role = await RoleManager.FindByIdAsync(id);
            if(role != null)
            {
                var result = await RoleManager.DeleteAsync(role);
                if(result.Succeeded)
                {
                    TempData["message"] = $"{role.Name} has been deleted.";
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
            return RedirectToAction("Index");
        }
    }
}