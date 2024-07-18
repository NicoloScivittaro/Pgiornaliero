using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpedizioniApp.Services;

namespace SpedizioniApp.Pages
{
    public class TrackingModel : PageModel
    {
        private readonly SpedizioneService _spedizioneService;

        public TrackingModel(SpedizioneService spedizioneService)
        {
            _spedizioneService = spedizioneService;
        }

        [BindProperty]
        public string CodiceFiscale { get; set; }
        [BindProperty]
        public string NumeroSpedizione { get; set; }
        public Spedizione Spedizione { get; set; }

        public void OnPost()
        {
            Spedizione = _spedizioneService.GetSpedizioni()
                .FirstOrDefault(s => s.Cliente.CodiceFiscale == CodiceFiscale && s.NumeroIdentificativo == NumeroSpedizione);
        }
    }
}