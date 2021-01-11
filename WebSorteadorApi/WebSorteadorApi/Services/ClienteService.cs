using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSorteadorApi.Domain;
using WebSorteadorApi.Infrastructure.Contexto;
using WebSorteadorApi.Infrastructure.Repositories;

namespace WebSorteadorApi.Services
{
    public class ClienteService : IClienteService
    {
        public readonly IClienteRepository _repository;
        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public List<int> GetNumeros()
        {
            List<Cliente> clientes = _repository.Get();
            List<int> numSorteados = new List<int>();

            foreach (Cliente cliente in clientes)
            {
                numSorteados.Add(cliente.Numero);
            }

            return numSorteados;
        }

        public int Sortear()
        {
            List<int> numSorteados = GetNumeros();

            Random rnd = new Random();
            int numSorteado = rnd.Next(0, 99999);

            while (numSorteados.Contains(numSorteado) == true)
            {
                numSorteado = rnd.Next(0, 99999);
            }

            return numSorteado;
        }



    }
}
