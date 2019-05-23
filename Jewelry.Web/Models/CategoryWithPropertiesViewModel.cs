using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jewelry.Business.Data;

namespace Jewelry.Web.Models
{
    public class CategoryWithPropertiesViewModel
    {
        public IDictionary<string, bool> Properties { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
