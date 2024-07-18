using System.Collections.Generic;
using System.Linq;
using SpedizioniApp.Data;
using SpedizioniApp.Models;

namespace SpedizioniApp.Services
{
    public class ClienteService
    {
        private readonly SpedizioniContext _context;

        public ClienteService(SpedizioniContext context)
        {
            _context = context;
        }

        public IEnumerable<Cliente> GetClienti()
        {
            return _context.Clienti.ToList();
        }

        public Cliente GetClienteById(int id)
        {
            return _context.Clienti.Find(id);
        }

        public void AddCliente(Cliente cliente)
        {
            _context.Clienti.Add(cliente);
            _context.SaveChanges();
        }

        public void UpdateCliente(Cliente cliente)
        {
            _context.Clienti.Update(cliente);
            _context.SaveChanges();
        }

        public void DeleteCliente(int id)
        {
            var cliente = _context.Clienti.Find(id);
            if (cliente != null)
            {
                _context.Clienti.Remove(cliente);
                _context.SaveChanges();
            }
        }
    }
}