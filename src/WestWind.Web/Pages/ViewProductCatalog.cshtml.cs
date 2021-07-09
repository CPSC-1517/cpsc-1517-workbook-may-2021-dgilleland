using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WestWind.App.BLL;
using WestWind.App.Entities;

namespace WebApp.Pages
{
    public class ViewProductCatalogModel : PageModel
    {
        private readonly ProductInventoryService _service;
        public ViewProductCatalogModel(ProductInventoryService service)
        {
            _service = service ?? throw new ArgumentNullException();
        }

        public List<Product> Catalog {get;set;}

        public void OnGet()
        {
            Catalog = _service.GetProducts();
        }
    }
}
