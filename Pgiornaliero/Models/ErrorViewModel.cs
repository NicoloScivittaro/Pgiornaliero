namespace Pgiornaliero.Models
{
    public class SpedizioniContext
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
