using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShowApp.Data.Concrete.EfCore.Identity;
using ShowApp.WebUI.Models;

namespace ShowApp.WebUI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<AppUser> UserManager;
        private SignInManager<AppUser> SignInManager;
        public AccountController(UserManager<AppUser> userManager,
                                 SignInManager<AppUser> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model,string returnUrl)
        {
            if(ModelState.IsValid)
            {
                var user = await UserManager.FindByEmailAsync(model.Email);
                
                if(user != null)
                {
                    await SignInManager.SignOutAsync();
                    var result = await SignInManager.PasswordSignInAsync(user,model.Password,false,false);
                    
                    if(result.Succeeded)
                    {
                        return Redirect(returnUrl ?? "/");
                    }
                }
                ModelState.AddModelError("Email", "Invalid E-Mail or Password");

            }
            return View(model);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return Redirect("/Home/Index");
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterModel model, IFormFile file)
        {
            if (ModelState.IsValid)
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

                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return Redirect("/Home/Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View(model);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}