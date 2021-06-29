using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace RazorWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IWebHostEnvironment _environment;

        public IndexModel(ILogger<IndexModel> logger, IWebHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }

        public string Announcement {get;set;}
        public string WebRootPath
        { get { return _environment.WebRootPath; } }
        public string ContentRootPath
        { get { return _environment.ContentRootPath; } }


        public void OnGet()
        {
            // this is the method that will run for a
            // GET request of this page.
            Announcement = "My first Razor Page app.";
        }
    }
}
