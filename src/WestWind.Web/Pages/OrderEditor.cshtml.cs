using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WestWind.App.Entities;

namespace WebApp.Pages
{
    public class OrderEditorModel : PageModel
    {

        [BindProperty]
        public Order CurrentOrder { get; set; }

        public void OnGet()
        {
        }
    }
}
