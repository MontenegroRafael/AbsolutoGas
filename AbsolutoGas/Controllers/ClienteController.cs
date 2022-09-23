using Microsoft.AspNetCore.Mvc;
using System.Linq;
using AbsolutoGas.Models;
using AbsolutoGas.Repositorios;
using AbsolutoGas.ViewModels;

namespace AbsolutoGas.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        ClienteAcessoBanco repositorioCliente = new ClienteAcessoBanco();

        [HttpPost]  // CADASTRAR CLIENTE VIA REQUEST
        public IActionResult Salvar2([FromBody] SalvarClienteModel salvarClienteViewModel)
        {
            if (salvarClienteViewModel == null)
                return Ok("Não foram informados dados");

            if (salvarClienteViewModel.Cliente == null)
                return Ok("Dados do cliente não informados.");

            var resultado = repositorioCliente.SalvarCliente(salvarClienteViewModel.Cliente);

            if (resultado) return Ok("Cliente cadastrado com sucesso.");

            return Ok("Houve um problema ao salvar. Cliente não cadastrada.");
        }

        [HttpPost]  // CADASTRAR CLIENTE
        public IActionResult Save(Cliente cliente)
        {
            if (cliente == null)
                return NoContent();

            repositorioCliente.SalvarCliente(cliente);

            return Ok("Adicionado com sucesso!");
        }

        //[HttpGet]  // MOSTRAR LISTA DE CLIENTES
        //public IActionResult BuscarTodos()
        //{
        //    var clientes = repositorioCliente.BuscarTodos();

        //    if (clientes == null || !clientes.Any())
        //        return NotFound(new { mensage = $"Lista vazia." });

        //    return Ok(clientes);

        //}

        [HttpPut]  // ATUALIZAR CLIENTE POR ID
        public IActionResult Atualizar(AtualizarClienteModel cliente)
        {
            var cEncontrado = repositorioCliente.Atualizar(cliente.IdEncontrar, cliente.Atualizar);
            return Ok(cEncontrado);
        }

        [HttpDelete]  // DELETAR CLIENTE POR NOME
        public IActionResult Remover(string nome)
        {
            var cEncontrado = repositorioCliente.BuscarPorNome(nome);

            if (cEncontrado == null)
                return NotFound("Não há nenhum registro com esse nome.");

            repositorioCliente.Remover(cEncontrado);

            return Ok();
        }

    }
}
