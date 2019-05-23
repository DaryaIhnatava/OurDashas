// <copyright file="HomeController.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>


using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Jewelry.Business.TimeZoneService;
using Jewelry.Web.i18n;
using Microsoft.Extensions.Localization;

namespace Jewelry.Web.Controllers
{
    #region Usings
    using System;
    using System.Linq;
    using Jewelry.Business;
    using Jewelry.Business.Errors;
    using Jewelry.Business.LoginService.Models;
    using Jewelry.Database.Data;
    using Microsoft.AspNetCore.Localization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    #endregion

    /// <summary>
    /// HomeController class
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class HomeController : Controller
    {
        private IService<User> userService;
        private readonly IStringLocalizer<HomeController> localizer;
        private readonly IConfiguration configuration;

        private IService<UserSettings> userSettings;

        public HomeController(IStringLocalizer<HomeController> localizer, IConfiguration configuration, IService<User> userService,
        IService<UserSettings> userSettings)
        {
            this.localizer = localizer;
            this.configuration = configuration;
            this.userService = userService;
            this.userSettings = userSettings;
        }
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>Main home page</returns>
        public IActionResult Index()
        {
            Dictionary<string, string> timeZones = TimeZoneService.TimeZones;
            return this.View(timeZones);
        }

        /// <summary>
        /// IActionResult About
        /// </summary>
        /// <returns>About view</returns>
        public IActionResult About()
        {
            throw new ExchangeRateNullException("No exchange rate found for current currencies");
        }

        /// <summary>
        /// IActionResult Contact
        /// </summary>
        /// <returns>View of contacts</returns>
        public IActionResult Contact()
        {
            throw new Exception("message");
            this.ViewData["Message"] = "Your contact page.";
            return this.View();
        }


        /// <summary>Changes the language.</summary>
        /// <param name="lang">The language.</param>
        /// <param name="url">The URL.</param>
        /// <returns>Main view</returns>
        public IActionResult ChangeLanguage(string lang = null, string url = null)
        {
            if (lang == null)
            {
                var requestCulture = HttpContext.Request.Cookies["lang"].ToString();
                if (requestCulture.ToString() == "ru-RU")
                {
                    HttpContext.Response.Cookies.Append("lang", "en-US");
                    HttpContext.Features.Set<IRequestCultureFeature>(new RequestCultureFeature(new RequestCulture(new CultureInfo("en-US")), null));
                    var m = HttpContext.Features.Get<IRequestCultureFeature>();
                }
                else
                {
                    HttpContext.Response.Cookies.Append("lang", "ru-RU");
                }
            }
            else
            {
                User user = userService.ListByProperty("Email", HttpContext.User.Identity.Name).FirstOrDefault();
                if (User != null)
                {
                    UserSettings userSettingsModel = userSettings.ListByProperty("UserId", user.Id).FirstOrDefault();
                    userSettingsModel.Language = lang;
                    userSettings.Insert(userSettingsModel);
                }

                HttpContext.Response.Cookies.Append("lang", lang);
            }

            if (url != null)
            {
                return Redirect(url.Replace("http://localhost:61589", String.Empty));
            }

            return RedirectToAction("Index");
        }

        /// <summary>Changes the theme.</summary>
        /// <param name="theme">The theme.</param>
        /// <returns>Main view</returns>
        public IActionResult ChangeTheme(string theme)
        {
            if (theme == "white")
            {
                HttpContext.Response.Cookies.Append("theme", "white");
            }
            else
            {
                HttpContext.Response.Cookies.Append("theme", "black");
            }

            User user = userService.ListByProperty("Email", HttpContext.User.Identity.Name)?.FirstOrDefault();
            if (user != null)
            {
                UserSettings userSettingsModel = userSettings.ListByProperty("UserId", user.Id).FirstOrDefault();
                Theme userTheme;
                Enum.TryParse<Theme>(theme, out userTheme);
                userSettingsModel.Theme = userTheme;
                userSettings.Insert(userSettingsModel);
            }

            return RedirectToAction("Index");
        }

        /// <summary>Changes the time zone.</summary>
        /// <param name="timeZone">The time zone.</param>
        /// <returns>Main view</returns>
        public IActionResult ChangeTimeZone(string timeZone)
        {
            HttpContext.Response.Cookies.Append("timeZone", timeZone);
            User user = userService.ListByProperty("Email", HttpContext.User.Identity.Name)?.FirstOrDefault();
            if (user != null)
            {
                UserSettings userSettingsModel = userSettings.ListByProperty("UserId", user.Id).FirstOrDefault();
                userSettingsModel.TimeZone = timeZone;
                userSettings.Insert(userSettingsModel);
            }

            return RedirectToAction("Index");
        }
    }
}
