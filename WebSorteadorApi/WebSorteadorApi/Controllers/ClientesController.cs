using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebSorteadorApi.Domain;
using WebSorteadorApi.Infrastructure.Repositories;
using WebSorteadorApi.Services;

namespace WebSorteadorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _repository;

        public ClientesController(IClienteRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public List<Cliente> GetClientes()
        {
            return _repository.Get();
        }

        [HttpGet("{id}")]
        public Cliente GetClienteById(int id)
        {
            return _repository.GetById(id);
        }

        [HttpGet("Download/{id}")]
        public ActionResult DownloadTxt(int id)
        {
            Cliente cliente = GetClienteById(id);

            using (TextWriter File = new StreamWriter("NumeroSorteado.txt"))
            {
                File.WriteLine("Obrigado, " + cliente.Nome + "! Por ter solicitado o número " + cliente.Numero + ".");
            }

            return Ok("Download feito com sucesso!");
        }

        [HttpPost]
        public dynamic PostCliente(Cliente cliente)
        {
            ClienteService service = new ClienteService(_repository);

            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Modelo inválido" });
            }

            cliente.Numero = service.Sortear();
            _repository.Post(cliente);

            return cliente;
        }
    }
}
