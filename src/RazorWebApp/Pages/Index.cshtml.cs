using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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

        [BindProperty]
        public IFormFile UserFile { get; set; }

        public string[] Folders {get;set;} = new string[0];
        public void OnPostShow()
        {
            // A post method acting as a specific "page handler"
            Folders = System.IO.Directory.GetDirectories(ContentRootPath);
            
        }

        public void OnPost()
        {
            // if there is a UserFile (not null)...
            if (UserFile != null)
            {
                //      if I do not have an "Uploads" folder in my ContentRootPath
                string uploadsFolder = System.IO.Path.Combine(ContentRootPath, "Uploads");
                if(!System.IO.Directory.Exists(uploadsFolder))
                    //          then create that folder
                    System.IO.Directory.CreateDirectory(uploadsFolder);
                string filePath = System.IO.Path.Combine(uploadsFolder, UserFile.FileName); // not too secure
                if(!System.IO.File.Exists(filePath))
                //      if I do not have the user file already
                {
                    //          then save that file
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        UserFile.CopyTo(stream);
                    }
                }
                else
                {
                //          else set a message saying that I already have that file
                }
            }
        }

        public void OnGet()
        {
            // this is the method that will run for a
            // GET request of this page.
            Announcement = "My first Razor Page app.";
        }
    }
}
