using System.Linq;
using Jewelry.Business.CurrencyService;
using Jewelry.Business.Data;
using Jewelry.Business.JewellryService;
using Microsoft.AspNetCore.Mvc;

namespace Jewelry.Web.Controllers
{
    public class JewellryController : Controller
    {

        private readonly IJewellryService jewellryService;

        public JewellryController(IJewellryService jewellryService)
        {
            this.jewellryService = jewellryService;
        }

        public IActionResult Index()
        {
            System.Collections.Generic.IEnumerable<Jewellry> jewellries = jewellryService.GetJewellries();
            Jewellry jewellry = jewellries.FirstOrDefault();
            jewellryService.ConvertPriceCurrency(jewellry, Currency.Ruble);
            return View();
        }

        public IActionResult List()
        {
            var sortedListOfJewellries = jewellryService.GetSortedJewellriesByPropertyName("Price");
            return View(sortedListOfJewellries);
        }

        public IActionResult Filter()
        {
            string property = "Brand";
            var jewellries = jewellryService.GetJewellries().Count(q => q.Brand == "Parker" || q.Brand == "Sokolov");
            var filteredJewellries = jewellryService.GetFilteredJewellries(property, new string[] { "Parker", "Sokolov" });
            return View(filteredJewellries);
        }
    }
}