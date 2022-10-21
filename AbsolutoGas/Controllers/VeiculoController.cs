using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AbsolutoGas.Models;
using AbsolutoGas.Repositorios;
using AbsolutoGas.ViewModels;
using Dapper;

namespace AbsolutoGas.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        VeiculoAcessoBanco repositorioVeiculo = new VeiculoAcessoBanco();
        //private object _veiculos;


        [HttpPost]  // CADASTRAR VEICULO VIA CONSOLE
        public IActionResult Save(Veiculo veiculo)
        {
            if (veiculo == null)
                return NoContent();

            repositorioVeiculo.SalvarVeiculo(veiculo);

            return Ok("Adicionado com sucesso!");
        }

        [HttpGet]  // MOSTRAR LISTA DE VEICULOS VIA CONSOLE
        public IActionResult BuscarTodos()
        {
            var veiculo = repositorioVeiculo.BuscarTodos();

            if (veiculo == null || !veiculo.Any())
                return NotFound(new { mensage = $"Lista vazia." });

            return Ok(veiculo);

        }

        [HttpPut]  // ATUALIZAR VEICULO POR ID VIA CONSOLE
        public IActionResult Atualizar(AtualizarVeiculoModel veiculo)
        {
            var cEncontrado = repositorioVeiculo.Atualizar(veiculo.IdEncontrar, veiculo.Atualizar);
            return Ok(cEncontrado);
        }

        [HttpDelete]  // DELETAR VEICULO POR PLACA VIA CONSOLE
        public IActionResult Remover(string placa)
        {
            var vEncontrado = repositorioVeiculo.BuscarPorModelo(placa);

            if (vEncontrado == null)
                return NotFound("Não há nenhum registro com essa placa.");

            repositorioVeiculo.Remover(vEncontrado);

            return Ok();
        }
    }
}
