using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using ClosedXML.Excel;
using Jewelry.Business.Data;
using Jewelry.Business.FilterService;
using Jewelry.Business.JewelryService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Jewelry.Web.Middlewares
{
    public class ReportMakingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IJewelryService jewelryService;
        private readonly IFilterService filter;
        
        public ReportMakingMiddleware(RequestDelegate next, IJewelryService jewelryService, IFilterService filter)
        {
            _next = next;
            this.jewelryService = jewelryService;
            this.filter = filter;
        }


        public Task InvokeAsync(HttpContext context)
        {
            IEnumerable<Business.Data.Jewelry> jewelries = jewelryService.GetJewelries();
            List<Category> categories = null;

            if (context.Request.Method=="GET")
            {
                categories = GetParametersFromGetMethod(context);
            }
            else
            {
                categories = GetParametersFromPostMethod(context);
            }
            
            var fileredJewelries = filter.GetFilteredJewelries(categories, jewelries);


            var t = context.Request.Headers.FirstOrDefault(x => x.Key == "skip");
            int? skip = string.IsNullOrWhiteSpace(t.Key) ? (int?)null : int.Parse(t.Value[0]);
            t = context.Request.Headers.FirstOrDefault(x => x.Key == "take");
            int? take = string.IsNullOrWhiteSpace(t.Key) ? (int?)null : int.Parse(t.Value[0]);
            if (skip != null)
            {
                fileredJewelries = fileredJewelries.Skip((int)skip);
            }
            if (take != null)
            {
                fileredJewelries = fileredJewelries.Take((int)take);
            }



            Stream fs = null;
            var fileType = context.Request.Headers["fileType"];
            if (fileType=="xml")
            {
                fs = GetXmlResponse(context, jewelries);
            }
            else
            {
                fs = GetXlsxResponse(context, jewelries);
            }
            fileType = fileType == "xml" ? "application/xml" : "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            var m = new FileStreamResult(fs, fileType);
            Microsoft.AspNetCore.Routing.RouteData rd = new Microsoft.AspNetCore.Routing.RouteData();
            return m.ExecuteResultAsync(new ActionContext(context, rd, new Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor()));

        }

        private List<Category> GetParametersFromGetMethod(HttpContext context)
        {
            List<Category> categories = new List<Category>();
            var parameters = new List<string>();
            foreach (var item in typeof(Business.Data.Jewelry).GetProperties())
            {
                if (context.Request.Query.Any(x => x.Key.Contains(item.Name) || x.Key.Contains("PriceFrom") || x.Key.Contains("PriceTo")))
                {
                    parameters.Add(item.Name);
                }
            }
            foreach (var item in parameters)
            {
                var parameter = context.Request.Query.FirstOrDefault(x => x.Key == item);
                var category = categories.FirstOrDefault(x => x.PropertyName == parameter.Key);
                if (category == null)
                {
                    categories.Add(new Category()
                    {
                        PropertyName = parameter.Key,
                        PropertyValues = new List<Value>()
                    });
                    category = categories.FirstOrDefault(x => x.PropertyName == parameter.Key);
                }

                foreach (var m in parameter.Value.ToString().Split(", "))
                {
                    category.PropertyValues.Add(new Value()
                    {
                        PropertyValue = m,
                        Checked = true
                    });
                }

            }
            return categories;
        }

        private List<Category> GetParametersFromPostMethod(HttpContext context)
        {
            var bodyAsText = new System.IO.StreamReader(context.Request.Body).ReadToEnd();
            var categories = JsonConvert.DeserializeObject<List<Category>>(bodyAsText);
            return categories;
        }

        private Stream GetXmlResponse(HttpContext context, IEnumerable<Business.Data.Jewelry> jewelries)
        {
            XDocument document = new XDocument();
            XElement jewelriesElement = new XElement("Jewelries");
            foreach (var jewelry in jewelries)
            {
                XElement element;
                XElement jewelryElement = new XElement("Jewelry");
                foreach (var item in typeof(Business.Data.Jewelry).GetProperties().Where(x => x.Name != "Price"))
                {
                    element = new XElement(item.Name, item.GetValue(jewelry));
                    jewelryElement.Add(element);
                }
                element = new XElement("Price", jewelry.Price.Value);
                jewelryElement.Add(element);
                element = new XElement("Currency", jewelry.Price.Currency);
                jewelryElement.Add(element);
                jewelriesElement.Add(jewelryElement);
            }
            document.Add(jewelriesElement);
            MemoryStream xmlStream = new MemoryStream();

            document.Save(xmlStream);
            xmlStream.Flush();
            xmlStream.Position = 0;

            return xmlStream;
        }

        private Stream GetXlsxResponse(HttpContext context, IEnumerable<Business.Data.Jewelry> jewelries)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Лист1");
            worksheet.Cell("A" + 1).Value = "Id";
            worksheet.Cell("B" + 1).Value = "Shape";
            worksheet.Cell("C" + 1).Value = "Metal";
            worksheet.Cell("D" + 1).Value = "Brand";
            worksheet.Cell("E" + 1).Value = "Price";
            worksheet.Cell("E" + 1).Value = "Currency";
            int rowId = 2;
            foreach (var item in jewelries)
            {
                worksheet.Cell("A" + rowId).Value = item.Id;
                worksheet.Cell("B" + rowId).Value = item.Shape;
                worksheet.Cell("C" + rowId).Value = item.Metal;
                worksheet.Cell("D" + rowId).Value = item.Brand;
                worksheet.Cell("E" + rowId++).Value = item.Price.Value;
                worksheet.Cell("F" + rowId++).Value = item.Price.Currency;
            }
            worksheet.Columns().AdjustToContents();
            MemoryStream stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Position = 0;
            return stream;
        }
    }
    public static class MyHandlerExtensions
    {
        public static IApplicationBuilder UseReportMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ReportMakingMiddleware>();
        }
    }
}
