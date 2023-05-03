using APIClienteWEB.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO.MemoryMappedFiles;


namespace APIClienteWEB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {

        private List<Cliente> LerArquivoJson()
        {
            string caminhoDoArquivo = "C:/Projetos/APIClienteWEB/APIClienteWEB/Data/cliente.json";
            string conteudoDoArquivo = System.IO.File.ReadAllText(caminhoDoArquivo);
            List<Cliente> clientes = JsonConvert.DeserializeObject<List<Cliente>>(conteudoDoArquivo);
            return clientes;
        }

        [HttpGet("listar")]
        public List<Cliente> GetPessoa(string? cpf = null, string? nome = null)
        {
            List<Cliente> lista = LerArquivoJson();
            var listaporfiltro = lista.AsQueryable();

            if (!string.IsNullOrEmpty(nome))
            {
                listaporfiltro = listaporfiltro.Where(c => c.Nome.Contains(nome));
            }

            if (!string.IsNullOrEmpty(cpf))
            {
                listaporfiltro = listaporfiltro.Where(c => c.CPF == cpf);
            }

            return listaporfiltro.ToList();
        }
        [HttpPost]
        [Route("criar")]
        public IActionResult AddPessoa([FromBody] Cliente novaPessoa)
        {
            List<Cliente> pessoas = LerArquivoJson();
            pessoas.Add(novaPessoa);
            SalvarArquivoJson(pessoas);
            return CreatedAtAction(nameof(GetPessoa), new { id = novaPessoa.Id }, novaPessoa);
        }
        [HttpPut("atualizar/{id}")]
        public IActionResult UpdatePessoa(int id, [FromBody] Cliente clienteAtualizada)
        {
            List<Cliente> clientes = LerArquivoJson();
            Cliente cliente = clientes.FirstOrDefault(p => p.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }

            cliente.Nome = clienteAtualizada.Nome;
            cliente.Contato = clienteAtualizada.Contato;
            cliente.RG = clienteAtualizada.RG;
            cliente.CPF = clienteAtualizada.CPF;
            cliente.Endereco = clienteAtualizada.Endereco;
            cliente.Id = clienteAtualizada.Id;
            SalvarArquivoJson(clientes);

            return NoContent();
        }
        [HttpDelete("remover/{id}")]
        public IActionResult DeletePessoa(int id)
        {
            List<Cliente> clientes = LerArquivoJson();
            Cliente cliente = clientes.FirstOrDefault(p => p.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }

            clientes.Remove(cliente);
            SalvarArquivoJson(clientes);

            return NoContent();
        }
        private void SalvarArquivoJson(List<Cliente> pessoas)
        {
            string caminhoDoArquivo = @"C:\\Projetos\\APIClienteWEB\\APIClienteWEB\\Data\\cliente.json";
            string conteudoDoArquivo = JsonConvert.SerializeObject(pessoas);
            System.IO.File.WriteAllText(caminhoDoArquivo, conteudoDoArquivo);
        }

    }
}