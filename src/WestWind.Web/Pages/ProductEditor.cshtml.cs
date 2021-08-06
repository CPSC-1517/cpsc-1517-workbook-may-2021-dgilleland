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

        public List<Category> Categories { get; set; }
        public List<SelectListItem> Suppliers { get; set; }
        public string ErrorMessage { get; set; }

        [BindProperty]
        public Product ProductItem { get; set; }

        public void OnGet(int? id) // Allow an optional integer value for the id of the product to edit
        {
            if (id.HasValue) // A nullable int will have a property called .HasValue
            {
                ProductItem = _service.GetProduct(id.Value); // The .Value property of the nullable int is an acutal int
            }
            PopulateDropDown();
        }

        // An IActionResult allows me more control in communicating the results of this request to the web browser
        public IActionResult OnPostAdd()
        {
            if (ModelState.IsValid) // recheck the validation based on the asp-validation-for
            {
                try
                {
                    _service.AddProduct(ProductItem); // Calling the ProductInventoryService.AddProduct method
                                                      // Use the POST-Redirect-GET pattern to prevent inadvertant resubmissions of POST requests
                    return RedirectToPage(new { id = ProductItem.ProductId });
                }
                catch (Exception ex)
                {
                    // Start with the assumption that the given exception is the root of the problem
                    Exception rootCause = ex;
                    // Loop to "drill-down" to what the original cause of the problem is
                    while (rootCause.InnerException != null)
                        rootCause = rootCause.InnerException;

                    ErrorMessage = rootCause.Message;
                    PopulateDropDown();
                    return Page(); // Return the page as the POST result - This will preserve any user inputs
                }
            }
            PopulateDropDown();
            return Page();
        }

        public IActionResult OnPostUpdate()
        {
            try
            {
                _service.UpdateProduct(ProductItem);
                // Redirect to GET request since everything worked out OK
                return RedirectToPage(new { id = ProductItem.ProductId });
            }
            catch (Exception ex)
            {
                // Start with the assumption that the given exception is the root of the problem
                Exception rootCause = ex;
                // Loop to "drill-down" to what the original cause of the problem is
                while (rootCause.InnerException != null)
                    rootCause = rootCause.InnerException;

                ErrorMessage = rootCause.Message;
                PopulateDropDown();
                return Page(); // Return the page as the POST result - This will preserve any user inputs
            }
        }

        public IActionResult OnPostDelete()
        {
            try
            {
                _service.DeleteProduct(ProductItem);
                return RedirectToPage(new { id = (int?)null }); // I need to remember to be explicit about having a "blank" product id
            }
            catch (Exception ex)
            {
                // Start with the assumption that the given exception is the root of the problem
                Exception rootCause = ex;
                // Loop to "drill-down" to what the original cause of the problem is
                while (rootCause.InnerException != null)
                    rootCause = rootCause.InnerException;

                ErrorMessage = rootCause.Message;
                PopulateDropDown();
                return Page(); // Return the page as the POST result - This will preserve any user inputs
            }
        }

        private void PopulateDropDown()
        {
            Categories = _service.ListCategories();
            Suppliers = _service.ListSuppliers()
                                .Select(x => new SelectListItem(x.CompanyName, x.SupplierId.ToString()))
                                .ToList();
        }
    }
}
