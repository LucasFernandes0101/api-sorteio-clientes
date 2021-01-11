using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSorteadorApi.Domain;
using WebSorteadorApi.Infrastructure.Contexto;

namespace WebSorteadorApi.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        public readonly ClienteContext _context;
        public ClienteRepository(ClienteContext context)
        {
            _context = context;
        }

        public List<Cliente> Get()
        {
            return _context.Clientes.ToList();
        }

        public Cliente GetById(int id)
        {
            return (_context.Clientes.Find(id));
        }

        public void Post(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }
    }
}
