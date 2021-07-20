using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WestWind.App.BLL;
using WestWind.App.Entities;

namespace WebApp.Pages
{
    public class ProductEditorModel : PageModel
    {
        private readonly ProductInventoryService _service;
        public ProductEditorModel(ProductInventoryService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }
        
        public List<Category> Categories {get;set;}
        public List<SelectListItem> Suppliers { get; set; }

        [BindProperty]
        public Product ProductItem { get; set; }

        public void OnGet()
        {
            PopulateDropDown();
        }

        public void OnPost()
        {
            PopulateDropDown();
        }

        private void PopulateDropDown()
        {
            Categories = _service.ListCategories();
            Suppliers = _service.ListSuppliers()
                                .Select(x => new SelectListItem(x.CompanyName, x.SupplierID.ToString()))
                                .ToList();
        }
    }
}
