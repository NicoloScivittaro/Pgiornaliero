using System.Collections.Generic;
using System.Linq;
using SpedizioniApp.Data;
using SpedizioniApp.Models;

namespace SpedizioniApp.Services
{
    public class SpedizioneService
    {
        private readonly SpedizioniContext _context;

        public SpedizioneService(SpedizioniContext context)
        {
            _context = context;
        }

        public IEnumerable<Spedizione> GetSpedizioni()
        {
            return _context.Spedizioni.ToList();
        }

        public Spedizione GetSpedizioneById(int id)
        {
            return _context.Spedizioni.Find(id);
        }

        public void AddSpedizione(Spedizione spedizione)
        {
            _context.Spedizioni.Add(spedizione);
            _context.SaveChanges();
        }

        public void UpdateSpedizione(Spedizione spedizione)
        {
            _context.Spedizioni.Update(spedizione);
            _context.SaveChanges();
        }

        public void DeleteSpedizione(int id)
        {
            var spedizione = _context.Spedizioni.Find(id);
            if (spedizione != null)
            {
                _context.Spedizioni.Remove(spedizione);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Spedizione> GetSpedizioniInConsegnaOggi()
        {
            return _context.Spedizioni.Where(s => s.DataConsegnaPrevista.Date == DateTime.Now.Date).ToList();
        }

        public int GetSpedizioniInAttesaDiConsegna()
        {
            return _context.Spedizioni.Count(s => s.Aggiornamenti.All(a => a.Stato != "consegnato"));
        }

        public IEnumerable<IGrouping<string, Spedizione>> GetSpedizioniPerCittaDestinataria()
        {
            return _context.Spedizioni.GroupBy(s => s.CittaDestinataria).ToList();
        }
    }
}