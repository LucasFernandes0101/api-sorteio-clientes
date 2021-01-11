using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSorteadorApi.Domain
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public int Numero { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}
