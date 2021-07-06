using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WestWind.App.BLL; // TempService class
using WestWind.App.Entities; // Shipper class

namespace MyApp.Namespace
{
    public class SandboxModel : PageModel
    {
        // Add a dependency on our TempService
        private readonly TempService _service;
        public SandboxModel(TempService service)
        {
            _service = service;
        }
        
        public List<Shipper> Shippers { get; set; }
        public void OnGet()
        {
            Shippers = _service.ListShippers();
        }
    }
}
