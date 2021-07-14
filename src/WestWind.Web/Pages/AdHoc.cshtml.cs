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
        public Paginator Paging { get; set; }
        public Paginator Revamp { get; set; }

        public void OnGet(int? currentPage)
        {
            int pageNumber = currentPage.HasValue ? currentPage.Value : 1;
            Paging = new Paginator(77);
            Paging.Current = pageNumber;

            // -- Revamp below
            PageState current = new(pageNumber, 10);
            Revamp = new Paginator(7777, current);
        }
    }
}
