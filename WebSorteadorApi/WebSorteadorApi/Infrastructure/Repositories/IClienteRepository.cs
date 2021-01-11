using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSorteadorApi.Domain;

namespace WebSorteadorApi.Infrastructure.Repositories
{
    public interface IClienteRepository
    {
        List<Cliente> Get();
        Cliente GetById(int id);
        void Post(Cliente cliente);
    }
}
