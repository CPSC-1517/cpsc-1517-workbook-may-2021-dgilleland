using System; // contains the DateTime structure exists
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorWebApp.Pages
{
    public class EventsModel : PageModel
    {
        [BindProperty] // Important for capturing POST information
        public UpcomingEvent Event {get;set;}           // The object through which the user posts information to the page
        public UpcomingEvent RegisteredEvent {get;set;} // The object used for feedback information

        public void OnGet()
        {

        }
        public void OnPost()
        {
            if(Event != null)
            {
                // Using a separate property for capturing the posted data and the "feedback" data
                // allows me to "clear" the form by re-setting the Event to null.
                RegisteredEvent = Event;
                // To "clear" the event information, I would have to change each property individually:
                Event = Event with {Title = string.Empty, Description = string.Empty, AvailableSeats = 0, Date = default(DateTime)};
                // TODO: come back to this and implement the Post-Redirect-Get pattern.
            }
        }
    }

    // This record is a representation of the information of an event in the future.
    public record UpcomingEvent(string Title, string Description, DateTime Date, int AvailableSeats);
}