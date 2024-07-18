using Microsoft.AspNetCore.Identity;

namespace Pgiornaliero.Models
{
    // Estendi IdentityUser aggiungendo nuove proprietà personalizzate
    public class ApplicationUser : IdentityUser
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string CodiceFiscale { get; set; }
        public string PartitaIVA { get; set; }
    }
}