using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Models
{
    public class Veiculo
    {
        
        public int IdVeiculo { get; set; }
        public string Placa { get; set; }

        public Veiculo(string placa)
        {
            Placa = placa;
        }

        public Veiculo(int idVeiculo, string placa)
        {
            IdVeiculo = idVeiculo;
            Placa = placa;
        }
    }

}
