using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSorteadorApi.Domain;

namespace WebSorteadorApi.Services
{
    public interface IClienteService
    {
        List<int> GetNumeros();
        int Sortear();
    }
}
