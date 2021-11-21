using DataLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PhotoAlbumSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoAlbumSystem.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> UserMgr { get; }
        private SignInManager<IdentityUser> SignInMgr { get; }
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            UserMgr = userManager;
            SignInMgr = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await SignInMgr.SignOutAsync();
            return RedirectToAction("index", "home");

        }


        public IActionResult Welcome()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterView model)
        {
            if(ModelState.IsValid)
            {
                var user = new IdentityUser 
                { 
                    UserName = model.Email,
                    Email = model.Email 
                };
                var result = await UserMgr.CreateAsync(user, model.Password);

                if(result.Succeeded)
                {
                    await SignInMgr.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View();

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginView model)
        {
            


            if (ModelState.IsValid)
            {
                
                var result = await SignInMgr.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                
            }

            return View(model);

        }



    }
}
