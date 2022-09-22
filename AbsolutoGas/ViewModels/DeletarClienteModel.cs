using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbsolutoGas.Models;

namespace AbsolutoGas.ViewModels
{
    public class DeletarClienteModel
    {
        public string Nome { get; set; }
        public Cliente Remover { get; set; }
    }
}
