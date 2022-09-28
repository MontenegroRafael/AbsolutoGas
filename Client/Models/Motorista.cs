using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Models
{
    public class Motorista
    {

        public int IdMotorista { get; set; }
        public string Nome { get; set; }
        public string CNH { get; set; }
        public string Telefone { get; set; }

        public Motorista(string nome, string cnh, string telefone)
        {
            Nome = nome;
            CNH = cnh;
            Telefone = telefone;
        }

        public Motorista(int idMotorista, string nome, string cnh, string telefone)
        {
            IdMotorista = idMotorista;
            Nome = nome;
            CNH = cnh;
            Telefone = telefone;
        }
    }
}
