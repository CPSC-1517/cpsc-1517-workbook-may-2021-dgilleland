using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Helpers;

namespace WebApp.Pages
{
    public class AdHocModel : PageModel
    {
        public Paginator Revamp { get; set; }

        public void OnGet(int? currentPage)
        {
            int maxPageLinks = 10; // For new Paginator constructor
            int pageNumber = currentPage.HasValue ? currentPage.Value : 1;
            // -- Revamp below
            PageState current = new(pageNumber, 10);
            Revamp = new Paginator(777, current, maxPageLinks);
        }
    }
}
