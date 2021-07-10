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


        public void OnGet(int? currentPage)
        {
            Paging = new Paginator(7777);

            Paging.Current = currentPage.HasValue ? currentPage.Value : 1;
        }
    }
}
