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
        public string FeedbackMessage { get; set; }

        [BindProperty]
        public Product ProductItem { get; set; }
        [BindProperty(SupportsGet = true)]
        public int? Id { get; set; }

        public void OnGet(string feedback) // Allow an optional integer value for the id of the product to edit
        {
            FeedbackMessage = feedback;
            if (Id.HasValue) // A nullable int will have a property called .HasValue
            {
                ProductItem = _service.GetProduct(Id.Value); // The .Value property of the nullable int is an actual int
                Id = ProductItem?.ProductId; // to "reset" the id to null if the product was not found
            }
            PopulateDropDown();
        }

        // An IActionResult allows me more control in communicating the results of this request to the web browser
        public IActionResult OnPostAdd()
        {
            if (Id.HasValue)
            {
                    ErrorMessage = "This is an existing product, and cannot be re-added.";
                    PopulateDropDown();
                    return Page(); // Return the page as the POST result - This will preserve any user inputs
            }
            else if (ModelState.IsValid) // recheck the validation based on the asp-validation-for
            {
                try
                {
                    _service.AddProduct(ProductItem); // Calling the ProductInventoryService.AddProduct method
                                                      // Use the POST-Redirect-GET pattern to prevent inadvertent resubmissions of POST requests
                    return RedirectToPage(new { id = ProductItem.ProductId, feedback = "New Product Added" });
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
            if (Id.HasValue && ModelState.IsValid)
            {
                try
                {
                    ProductItem.ProductId = Id.Value;
                    _service.UpdateProduct(ProductItem);
                    // Redirect to GET request since everything worked out OK
                    return RedirectToPage(new { id = ProductItem.ProductId, feedback = "Product Updated" });
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
            else
            {
                ErrorMessage = "Invalid Product Details - Unable to Update Product";
                PopulateDropDown();
                return Page();
            }
        }

        public IActionResult OnPostDelete()
        {
            try
            {
                ProductItem.ProductId = Id.Value;
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
