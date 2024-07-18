using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SpedizioniApp.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Message { get; set; }

        public IActionResult OnPost()
        {
            // Logica per l'invio del messaggio
            return RedirectToPage("Index");
        }
    }
}