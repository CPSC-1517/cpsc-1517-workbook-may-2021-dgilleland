using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class SandboxModel : PageModel
    {
        // empty list
        public List<Stuff> LotsOfStuff {get;set;} = new();
        [BindProperty]
        public int SelectedItem {get;set;}
        public void OnGet()
        {
            PopulateDropDown();
        }
        public void OnPost()
        {
            PopulateDropDown();
        }
        private void PopulateDropDown()
        {
            LotsOfStuff.Add(new(5, "Very Poor"));
            LotsOfStuff.Add(new(4, "Poor"));
            LotsOfStuff.Add(new(3, "Meh"));
            LotsOfStuff.Add(new(2, "Good"));
            LotsOfStuff.Add(new(1, "Very Good"));
        }
    }
    public record Stuff(int Id, string Text);
}
