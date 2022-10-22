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
    public class PedidoController : ControllerBase
    {
        PedidoAcessoBanco repositorioPedido = new PedidoAcessoBanco();

        [HttpPost] // CADASTRAR PEDIDO VIA REQUEST
        public IActionResult Save2(SalvarPedidoModel salvarpedidomodel)
        {
            var resultado = repositorioPedido.SalvarPedido(salvarpedidomodel.Pedido);

            if (resultado) return Ok("Pedido Salvo Com Sucesso");

            return Ok("Não foi possível salvar esse Pedido");
        }

        [HttpPut]  // ATUALIZAR PEDIDO POR ID VIA REQUEST
        public IActionResult Atualizar2(AtualizarPedidoModel pedido)
        {
            var aEncontrado = repositorioPedido.Atualizar(pedido.IdEncontrar, pedido.Atualizar);
            return Ok(aEncontrado);
        }

        [HttpPost]  // CADASTRAR PEDIDO VIA CONSOLE
        public IActionResult Save(Pedido pedido)
        {
            if (pedido == null)
                return NoContent();

            repositorioPedido.SalvarPedido(pedido);

            return Ok("Adicionado com sucesso!");
        }

        [HttpGet]  // MOSTRAR LISTA DE PEDIDO VIA CONSOLE
        public IActionResult BuscarTodos()
        {
            var pedido = repositorioPedido.BuscarTodos();

            if (pedido == null || !pedido.Any())
                return NotFound(new { mensage = $"Lista vazia." });

            return Ok(pedido);

        }


        [HttpPut]  // ATUALIZAR PEDIDO POR ID VIA CONSOLE
        public IActionResult Atualizar(AtualizarPedidoModel pedido)
        {
            var aEncontrado = repositorioPedido.Atualizar(pedido.IdEncontrar, pedido.Atualizar);
            return Ok(aEncontrado);
        }

        [HttpDelete]  // DELETAR PEDIDO POR ID VIA CONSOLE
        public IActionResult Remover(int idPedido)
        {
            var pEncontrado = repositorioPedido.BuscarPorId(idPedido);

            if (pEncontrado == null)
                return NotFound("Não há nenhum registro com esse id.");

            repositorioPedido.Remover(pEncontrado);

            return Ok();
        }
    }
}
