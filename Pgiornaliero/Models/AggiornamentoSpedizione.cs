using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpedizioniApp.Models
{
    public class AggiornamentoSpedizione
    {
        public int Id { get; set; }
        public int SpedizioneId { get; set; }
        public Spedizione Spedizione { get; set; }
        public string Stato { get; set; }  // In transito, In consegna, Consegnato, Non consegnato
        public string Luogo { get; set; }
        public string Descrizione { get; set; }
        public DateTime DataOra { get; set; }
    }
}