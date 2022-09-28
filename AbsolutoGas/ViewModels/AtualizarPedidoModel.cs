using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbsolutoGas.Models;

namespace AbsolutoGas.ViewModels
{
    public class AtualizarPedidoModel
    {
        public int IdEncontrar { get; set; }
        public Pedido Atualizar { get; set; }
    }
}
