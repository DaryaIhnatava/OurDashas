using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Security.Claims;
using System.Threading.Tasks;
using Jewelry.Business;
using Jewelry.Business.LoginService;
using Jewelry.Business.LoginService.Authentication;
using Jewelry.Business.LoginService.Models;
using Jewelry.Database.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Jewelry.Web.Controllers
{
    public class UserController : Controller
    {
        private IService<User> userService;
        private IService<UserSettings> userSettings;
        private readonly IConfiguration configuration;

        public UserController(IService<User> userService, IService<UserSettings> userSettings, IConfiguration configuration)
        {
            this.userService = userService;
            this.userSettings = userSettings;
            this.configuration = configuration;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(User userModel)
        {
            if (ModelState.IsValid)
            {
                User user = userService.GetList().FirstOrDefault(u => u.Email == userModel.Email && Encryption.VerifyMd5Hash(userModel.Password, u.Password));
                if (user != null)
                {
                    Authenticate(userModel.Email);
                    UserSettings userSettingsModel = userSettings.ListByProperty("UserId", user.Id).FirstOrDefault();
                    ChangeTheme(userSettingsModel.Theme);
                    ChangeTime(userSettingsModel.TimeZone);
                    return Redirect($"/Home/ChangeLanguage?lang={userSettingsModel.Language.Trim()}");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(userModel);
        }
        private void ChangeTheme(Theme theme)
        {
            HttpContext.Response.Cookies.Append("theme", theme.ToString());
        }
        private void ChangeTime(string timeZone)
        {
            HttpContext.Response.Cookies.Append("timeZone", timeZone);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(User userModel)
        {
            if (ModelState.IsValid)
            {
                User user = userService.GetList().FirstOrDefault(u => u.Email == userModel.Email);
                if (user == null)
                {
                    userService.Insert(userModel);
                    user = userService.GetList().FirstOrDefault(u => u.Email == userModel.Email);
                    Theme theme;
                    Enum.TryParse<Theme>(configuration.GetSection("Theme").Value, out theme);
                    userSettings.Insert(new UserSettings()
                    {
                        Language = configuration.GetSection("Culture").Value,
                        UserId = user.Id,
                        Theme = theme,
                        TimeZone = configuration.GetSection("TimeZoneKey").Value
                    });
                    Authenticate(userModel.Email); 

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(userModel);
        }

        private async void Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Response.Cookies.Delete("timeZone");
            HttpContext.Response.Cookies.Delete("lang");
            HttpContext.Response.Cookies.Delete("theme");
            return RedirectToAction("Login", "User");
        }
    }
}