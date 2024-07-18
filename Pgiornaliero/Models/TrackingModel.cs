namespace Pgiornaliero.Models
{
    public class TrackingModel
    {
        // Proprietà del modello
        public int Id { get; set; }
        public string Status { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public Spedizione Spedizione { get; set; }
        public DateTime UpdateDateTime { get; set; }

        // Costruttore vuoto necessario per il model binding in ASP.NET Core
        public TrackingModel()
        {
        }
    }
}