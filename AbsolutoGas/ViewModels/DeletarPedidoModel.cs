using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbsolutoGas.Models;

namespace AbsolutoGas.ViewModels
{
    public class DeletarPedidoModel
    {
        public int IdPedido { get; set; }
        public Pedido Remover { get; set; }
    }
}
