using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Helpers; // for Paginator class
using WestWind.App.BLL;
using WestWind.App.Collections;
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

        public PartialList<Product> Catalog {get;set;}
        public Paginator Paging {get;set;}

        public void OnGet()
        {
            int pageIndex = 0;
            int pageSize = 10;
            Catalog = _service.GetProducts(pageIndex * pageSize, pageSize);
            Paging = new(Catalog.TotalCount);
            Paging.Current = 1;
        }
    }
}
