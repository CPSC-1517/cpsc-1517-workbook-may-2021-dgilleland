using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class AdHocModel : PageModel
    {
        // CurrentPage - the one we are on (1-based)
        // PageSize - # of items per page

        ///<summary>Current is the human-friendly page number that is currently being displayed</summary>
        public int Current { get; set; }
        ///<summary>PageSize is the number of items to display on each page</summary>
        public int PageSize { get; set; } = 10;
        ///<summary>TotalResults is the total number of items in the pagination</summary>
        public int TotalResults {get;set;} = 77;
        ///<summary>PageCount is the total number of pages for the TotalResults</summary>
        public int PageCount { get { return (TotalResults / PageSize) + 1; } }
        ///<summary>PageIndex is the computer-friendly "current page" (useful for calculations with zero-based indexes)</summary>
        public int PageIndex { get { return PageIndex - 1; } }
        ///<summary>FromIndex is the human-friendly item number for the first item in the current page's results</summary>
        public int FromItem // The item # for the first
        {
            get
            {
                int offset = PageIndex * PageSize;
                return offset + 1; 
            }
        }
        ///<summary>ToItem is the human-friendly item number for the last item in the current pages' results</summary>
        public int ToItem
        { get { return FromItem + PageSize - 1; }}

        public void OnGet(int? currentPage)
        {
            Current = currentPage.HasValue ? currentPage.Value : 1;
        }
    }
}
