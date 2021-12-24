using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NayeemSaleApp.Areas.Auth.Models;
using NayeemSaleApp.Controllers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NayeemSaleApp.Services.AuthService.Interfaces;
using NayeemSaleApp.Helpers;
using NayeemSaleApp.Data.Entity;

namespace NayeemSaleApp.Areas.Auth.Controllers
{
    [Authorize]
    [Area("Auth")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IUserInfoes userInfoes;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager, IUserInfoes userInfoes)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            this.userInfoes = userInfoes;
            
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LogInViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var userInfos = await userInfoes.GetUserInfoByUser(model.Name);
                if (userInfos != null)
                {
                    if (userInfos.isActive == 1)
                    {
                        var result = await _signInManager.PasswordSignInAsync(model.Name, model.Password, model.RememberMe, lockoutOnFailure: true);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("Index", "CustomerInfo", new { area = "MasterData" });
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                            return View(model);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Lockout()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                string username = HttpContext.User.Identity.Name;
                var user = new ApplicationUser
                {
                    UserName = model.Name,
                    isActive = 1,
                    PhoneNumber=model.PhoneNumber,
                    PasswordHash=model.Password,
                    Email = model.Email,
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                AddErrors(result);
            }

            return RedirectToAction("Index", "CustomerInfo", new { area = "MasterData" });

        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();

            return RedirectToAction("Login", "Account", new { area = "Auth" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePsswordViewModel model)
        {
            string message = "Fail To Update Password";
            if (ModelState.IsValid)
            {
                var data = await _userManager.ChangePasswordAsync(await _userManager.FindByNameAsync(HttpContext.User.Identity.Name), model.OldPassword, model.Password);
                message = data.ToString();
            }
            return RedirectToAction("Login", "Account", new { area = "Auth" });
        }





        #region GeneralUser
        [AllowAnonymous]
        [HttpGet]
        public async Task<string> RestrictDuplicateUserName(string uName)
        {
            return await userInfoes.CheckUserName(uName);
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<string> RestrictDuplicateEmail(string email)
        {
            return await userInfoes.CheckEmail(email);
        }
   
        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> GeneralRegister(RegisterViewModel model,string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Name,
                    isActive = 1,
                    Email = model.Email,
                    PhoneNumber=model.PhoneNumber,
                    createdAt = DateTime.Now
                };
                var result = await _userManager.CreateAsync(user, model.Password);

                AddErrors(result);
            }

            return RedirectToAction("Index", "DailyExpense", new { area = "DailyExpenseArea" });


        }
        #endregion
       
        #region User Management
        [HttpGet]
        public async Task<IActionResult> UserList()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            List<ApplicationRoleViewModel> lstRole = new List<ApplicationRoleViewModel>();
            foreach (var data in roles)
            {
                ApplicationRoleViewModel modelr = new ApplicationRoleViewModel
                {
                    RoleId = data.Id,
                    RoleName = data.Name
                };
                lstRole.Add(modelr);
            }

            UserListViewModel model = new UserListViewModel
            {
                aspNetUsersViewModels = await userInfoes.GetUserInfoList(),
                userRoles = lstRole,
            };
            return View(model);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        #endregion
        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                var userId = HttpContext.User.Identity.Name;
                return RedirectToAction("Index", "CustomerInfo", new { area = "MasterData" });


              
            }
            else
            {
                var userId = HttpContext.User.Identity.Name;
                return RedirectToAction("Index", "CustomerInfo", new { area = "MasterData" });


            }
        }

        #endregion
     
    }
}