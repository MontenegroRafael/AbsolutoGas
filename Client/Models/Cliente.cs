using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Models
{
    public class Cliente
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
        public string TipoContato { get; set; }

        public Cliente()
        {
        }

        public Cliente(string nome, string cPF, DateTime dataNascimento, string telefone, string rua, string numero, string bairro, string cidade, string referencia, string tipoContato)
        {
            Nome = nome;
            CPF = cPF;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            Rua = rua;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Referencia = referencia;
            TipoContato = tipoContato;
        }

        public Cliente(int idCliente, string nome, string telefone)
        {
            IdCliente = idCliente;
            Nome = nome;
            Telefone = telefone;
        }
    }
}
