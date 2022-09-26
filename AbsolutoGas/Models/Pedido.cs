using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsolutoGas.Models
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public DateTime DataEntrega { get; set; }
        public string HoraEntrega { get; set; }
        public int IdCliente { get; set; }
        public int IdProduto { get; set; }
        public int IdPagamento { get; set; }
        public int IdVeiculo { get; set; }
        public int IdMotorista { get; set; }
        public double ValorTotal { get; set; }
        public string Situacao { get; set; }
    }
}
