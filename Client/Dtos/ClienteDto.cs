using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Dtos
{
    public class ClienteDto
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Referencia { get; set; }

        public ClienteDto()
        {
        }

        public ClienteDto(int idCliente, string nome, string telefone)
        {
            IdCliente = idCliente;
            Nome = nome;
            Telefone = telefone;
        }
    }
}
