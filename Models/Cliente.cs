using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using Newtonsoft.Json;

namespace APIClienteWEB.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Contato Contato { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public Endereco Endereco { get; set; }

    }

}
