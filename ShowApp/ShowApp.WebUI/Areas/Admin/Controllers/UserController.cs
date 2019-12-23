using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShowApp.Data.Concrete.EfCore;
using ShowApp.Data.Concrete.EfCore.Identity;
using ShowApp.WebUI.Areas.Admin.Models;

namespace ShowApp.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class UserController : Controller
    {
        private UserManager<AppUser> UserManager;
        private IPasswordValidator<AppUser> PasswordValidator;
        private IPasswordHasher<AppUser> PasswordHasher;
        public UserController(UserManager<AppUser> userManager,
                               IPasswordValidator<AppUser> passwordValidator,
                               IPasswordHasher<AppUser> passwordHasher)
        {
            PasswordValidator = passwordValidator;
            PasswordHasher = passwordHasher;
            UserManager = userManager;
        }
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }
        public IActionResult List()
        {
            return View(UserManager.Users);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(RegisterModel model, IFormFile? file)
        {
            if(ModelState.IsValid)
            {
                AppUser user = new AppUser();
                user.Email = model.Email;
                user.UserName = model.UserName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "avatars", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                user.Image = file.FileName;

                var result = await UserManager.CreateAsync(user,model.Password);
                if(result.Succeeded)
                {
                    return RedirectToAction("List");
                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await UserManager.FindByIdAsync(id);
            if(user != null)
            {
                var result = await UserManager.DeleteAsync(user);
                if(result.Succeeded)
                {
                    return RedirectToAction("List");
                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("",item.Description);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "user not found");
            }
            return RedirectToAction("List",UserManager.Users);
        }
        
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var user = await UserManager.FindByIdAsync(id);
            if(user != null)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("List");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(string id,string password,string mail)
        {
            var user = await UserManager.FindByIdAsync(id);
            if(user != null)
            {
                user.Email = mail;
                IdentityResult validPass = null;
                if(!string.IsNullOrEmpty(password))
                {
                    validPass = await PasswordValidator.ValidateAsync(UserManager, user, password);
                    if(validPass.Succeeded)
                    {
                        user.PasswordHash = PasswordHasher.HashPassword(user, password);
                    }
                    else
                    {
                        foreach(var item in validPass.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }
                if(validPass.Succeeded)
                {
                    var result = await UserManager.UpdateAsync(user);
                    if(result.Succeeded)
                    {
                        return RedirectToAction("List");

                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "USER NOT FOUND!");
            }
            return RedirectToAction("List");
        }
    }
}