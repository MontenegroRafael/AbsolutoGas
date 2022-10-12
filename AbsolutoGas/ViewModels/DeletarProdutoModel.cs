using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbsolutoGas.Models;

namespace AbsolutoGas.ViewModels
{
    public class DeletarProdutoModel
    {
        public string Nome { get; set; }
        public Produto Remover { get; set; }
    }
}
