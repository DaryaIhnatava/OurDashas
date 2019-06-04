// <copyright file="JewelryController.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>


using System.IO;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Extensions.Logging;

namespace Jewelry.Web.Controllers
{
    #region Usings 
    using System.Collections.Generic;
    using Jewelry.Business.CategoryService;
    using Jewelry.Business.Data;
    using Jewelry.Business.DataManipulations;
    using Jewelry.Business.FilterService;
    using Jewelry.Business.JewelryService;
    using Jewelry.Web.Models;
    using BusinessResources = Jewelry.Business.i18n;
    using WebResources = Jewelry.Web.i18n;
    using Microsoft.AspNetCore.Mvc;
    using Jewelry.Business.i18n;
    using Microsoft.Extensions.Localization;
    using System.Net.Http;
    using System;
    using System.Text;
    #endregion

    /// <summary>
    /// Jewelry controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class JewelryController : Controller
    {
        /// <summary>
        /// The jewelry service
        /// </summary>
        private readonly IJewelryService jewelryService;

        /// <summary>
        /// The category service
        /// </summary>
        private readonly ICategoryService categoryService;

        /// <summary>
        /// The filter service
        /// </summary>
        private readonly IFilterService filter;

        /// <summary>
        /// The Jewelries list
        /// </summary>
        private IEnumerable<Jewelry> jewelries;

        private readonly ILogger<JewelryController> logger;

        private readonly IStringLocalizer<JewelryController> _localizer;

        /// <summary>
        /// Jewelry Controller
        /// </summary>
        /// <param name="jewelryService">jewelry service</param>
        /// <param name="categoryService">category service</param>
        /// <param name="filter">filter</param>
        public JewelryController(IJewelryService jewelryService, ICategoryService categoryService, IFilterService filter, IStringLocalizer<JewelryController> localizer, ILogger<JewelryController> logger)
        {
            this.jewelryService = jewelryService;
            this.categoryService = categoryService;
            this.filter = filter;
            this._localizer = localizer;
            this.logger = logger;
        }

        /// <summary>
        /// Indexes the specified jewelry.
        /// </summary>
        /// <param name="jewelry">The jewelry.</param>
        /// <param name="currency">The currency.</param>
        /// <returns>Main jewelry view</returns>
        public IActionResult CurrencyConvert(Business.Data.Jewelry jewelry, Currency currency)
        {
            jewelry = new Jewelry(1, "ring", "gold", "Ray", 50, Currency.Dollar);
            jewelry.Price = this.jewelryService.ConvertPriceCurrency(jewelry.Price, currency);
            return this.View(jewelry);
        }

        /// <summary>
        /// Index method
        /// </summary>
        /// <returns>View with model</returns>
        public IActionResult Index()
        {
            logger.LogError("This is Error from JewelryController");
            logger.LogWarning("This is warning from JewelryController");
            this.jewelries = this.jewelryService.GetJewelries();
            var categories = this.GetCategories();
            JewelriesViewModel viewModel = new JewelriesViewModel()
            {
                Jewelries = this.jewelries,
                categoryWithPropertiesViewModel = new CategoryWithPropertiesViewModel()
                {
                    Categories = categories,
                    Properties = this.GetPropertyNames()
                }
            };
            return this.View(viewModel);
        }

        /// <summary>
        /// Post index method
        /// </summary>
        /// <param name="categories">categories</param>
        /// <returns>View with model</returns>
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public IActionResult Index(List<Category> categories, string propertyName, string save, string take, string skip = "0")
        {
            var jewelries = this.jewelryService.GetJewelries();
            jewelries = this.filter.GetFilteredJewelries(categories, jewelries);
            jewelries = SortingService.SortByPropertyName(jewelries, propertyName);
            JewelriesViewModel viewModel = new JewelriesViewModel()
            {
                Jewelries = jewelries,
                categoryWithPropertiesViewModel = new CategoryWithPropertiesViewModel()
                {
                    Categories = this.GetFilterCategory(categories),
                    Properties = this.GetPropertyNames(propertyName)
                }
            };
            return View(viewModel);
        }
        //public void SendGetRequest(List<Category> categories, string save, string take, string skip)
        //{
        //    string baseUrl = HttpContext.Request.Scheme.ToString() + "://" + HttpContext.Request.Host.Value.ToString();
        //    using (HttpClient client = new HttpClient())
        //    {
        //        var request = new HttpRequestMessage
        //        {
        //            RequestUri = new Uri($"{baseUrl}/Report"),
        //            Method = HttpMethod.Get,
        //        };
        //        foreach (var category in categories)
        //        {
        //            foreach (var item in category.PropertyValues.Where(x => x.Checked == true && !String.IsNullOrWhiteSpace(x.PropertyValue)))
        //            {
        //                request.Headers.Add($"Category_{category.PropertyName}", item.PropertyValue);
        //            }
        //        }
        //        request.Headers.Add("fileType", save);
        //        request.Headers.Add("take", take);
        //        request.Headers.Add("skip", skip);
        //        var send = client.SendAsync(request);
        //        send.Wait();
        //        var result = send.Result;
        //    }

        //}
        //public void SendPostRequest(List<Category> categories, string save, string take, string skip)
        //{
        //    string baseUrl = HttpContext.Request.Scheme.ToString() + "://" + HttpContext.Request.Host.Value.ToString();

        //    StringBuilder sb = new StringBuilder();
        //    foreach (var category in categories)
        //    {
        //        foreach (var item in category.PropertyValues.Where(x => x.Checked == true && !String.IsNullOrWhiteSpace(x.PropertyValue)))
        //        {
        //            sb.Append($"{category.PropertyName}={item.PropertyValue}&");
        //        }
        //    }
        //    sb.Append($"fileType={save}&take={take}&skip={skip}");
        //    System.Net.WebRequest req = System.Net.WebRequest.Create(baseUrl+"/Report");
        //    req.ContentType = "application/x-www-form-urlencoded";
        //    req.Method = "POST";
        //    string requestBody = sb.ToString();
        //    byte[] bytes = System.Text.Encoding.ASCII.GetBytes(requestBody);
        //    req.ContentLength= bytes.Length;
        //    System.IO.Stream os = req.GetRequestStream(); 
        //    os.Write(bytes, 0, bytes.Length); 
        //    os.Close();
        //    System.Net.WebResponse resp = req.GetResponse();
        //    //System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
        //}
        /// <summary>
        /// GetJewelries method
        /// </summary>
        /// <returns>list of Jewelries</returns>
        public JsonResult GetJewelries()
        {
            var jewelries = this.jewelryService.GetJewelries();
            return Json(this.jewelries);
        }

        public ActionResult GetJewelry()
        {
            var jewelries = this.jewelryService.GetJewelries();
            return View(jewelries.FirstOrDefault());
        }

        /// <summary>
        /// GetPropertyNames method
        /// </summary>
        /// <returns>list of property names</returns>
        public IDictionary<string, bool> GetPropertyNames(string selectedName = null)
        {
            Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
            foreach (var property in typeof(Jewelry).GetProperties())
            {
                if (property.Name == selectedName)
                {
                    dictionary.Add(_localizer.GetString(property.Name), true);
                }
                else
                {
                    dictionary.Add(_localizer.GetString(property.Name), false);
                }
            }
            return dictionary;
        }

        /// <summary>
        /// GetCategories method
        /// </summary>
        /// <returns> list of Categories</returns>
        private IEnumerable<Category> GetCategories()
        {
            return this.categoryService.GetCategories();
        }

        private IEnumerable<Category> GetFilterCategory(List<Category> categories)
        {
            List<Category> newList = new List<Category>();
            foreach (Category category in categories)
            {
                if (category.PropertyName != "Price")
                {
                    newList.Add(category);
                }
            }
            newList.Add(GetCategories().Where(x => x.PropertyName == "Price").FirstOrDefault());
            return newList;
        }
        
    }
}