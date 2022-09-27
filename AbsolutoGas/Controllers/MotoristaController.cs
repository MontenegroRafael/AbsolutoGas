using Microsoft.AspNetCore.Mvc;
using System.Linq;
using AbsolutoGas.Models;
using AbsolutoGas.Repositorios;
using AbsolutoGas.ViewModels;

namespace AbsolutoGas.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class MotoristaController : ControllerBase
    {
        MotoristaAcessoBanco repositorioMotorista = new MotoristaAcessoBanco();

        [HttpPost]  // CADASTRAR MOTORISTA VIA REQUEST
        public IActionResult Salvar2([FromBody] SalvarMotoristaModel salvarMotoristaViewModel)
        {
            if (salvarMotoristaViewModel == null)
                return Ok("Não foram informados dados");

            if (salvarMotoristaViewModel.Motorista == null)
                return Ok("Dados do cliente não informados.");

            var resultado = repositorioMotorista.SalvarMotorista(salvarMotoristaViewModel.Motorista);

            if (resultado) return Ok("Motorista cadastrado com sucesso.");

            return Ok("Houve um problema ao salvar. Motorista não cadastrado.");
        }

        [HttpPost]  // CADASTRAR MOTORISTA
        public IActionResult Save(Motorista motorista)
        {
            if (motorista == null)
                return NoContent();

            repositorioMotorista.SalvarMotorista(motorista);

            return Ok("Adicionado com sucesso!");
        }

        [HttpGet]  // MOSTRAR LISTA DE MOTORISTA
        public IActionResult BuscarTodos()
        {
            var motorista = repositorioMotorista.BuscarTodos();

            if (motorista == null || !motorista.Any())
                return NotFound(new { mensage = $"Lista vazia." });

            return Ok(motorista);

        }

        [HttpPut]  // ATUALIZAR MOTORISTA POR ID
        public IActionResult Atualizar(AtualizarMotoristaModel motorista)
        {
            var mEncontrado = repositorioMotorista.Atualizar(motorista.IdEncontrar, motorista.Atualizar);
            return Ok(mEncontrado);
        }

        [HttpDelete]  // DELETAR MOTORISTA POR NOME
        public IActionResult Remover(string nome)
        {
            var mEncontrado = repositorioMotorista.BuscarPorNome(nome);

            if (mEncontrado == null)
                return NotFound("Não há nenhum registro com esse nome.");

            repositorioMotorista.Remover(mEncontrado);

            return Ok();
        }
    }
}
