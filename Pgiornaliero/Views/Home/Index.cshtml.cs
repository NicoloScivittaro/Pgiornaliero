using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SpedizioniApp.Pages.Home
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            ViewData["Title"] = "Home";
        }
    }
}