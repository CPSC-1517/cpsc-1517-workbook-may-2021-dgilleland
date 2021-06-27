using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorWebApp.Pages
{
    public class EventsModel : PageModel
    {
        [BindProperty] // Important for capturing POST information
        public string EventTitle {get;set;}
        public string FeedbackMessage { get; set; }

        public void OnGet()
        {

        }
        public void OnPost()
        {
            if(!string.IsNullOrEmpty(EventTitle))
                FeedbackMessage = $"Thanks for telling us about your event: {EventTitle}";
        }
    }
}