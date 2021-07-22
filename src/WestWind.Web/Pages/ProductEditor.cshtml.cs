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

        public void OnGet(int? id) // Allow an optional integer value for the id of the product to edit
        {
            if(id.HasValue) // A nullable int will have a property called .HasValue
            {
                ProductItem = _service.GetProduct(id.Value); // The .Value property of the nullable int is an acutal int
            }
            PopulateDropDown();
        }

        // An IActionResult allows me more control in communicating the results of this request to the web browser
        public IActionResult OnPost() 
        {
            _service.AddProduct(ProductItem); // Calling the ProductInventoryService.AddProduct method
            // Use the POST-Redirect-GET pattern to prevent inadvertant resubmissions of POST requests
            return RedirectToPage(new {id = ProductItem.ProductID });
            // PopulateDropDown();
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
