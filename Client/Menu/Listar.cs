using System;
using System.Collections.Generic;
using System.Text;
using Client.Models;
using System.Data.SqlClient;
using System.Linq;
using System.Data;

namespace Client.Menu
{
    public class Listar
    {
        public static void MostarMenu()
        {

            Console.WriteLine("|******************************** Menu ********************************|");
            Console.WriteLine("|___________  Cliente  ____________|_____________  Veículo  ___________|");
            Console.WriteLine("|                                  |                                   |");
            Console.WriteLine("|>>> [ 1  ] - Listar Todos         | >>> [ 5  ] - Listar Todos         |");
            Console.WriteLine("|>>> [ 2  ] - Cadastrar            | >>> [ 6  ] - Cadastrar            |");
            Console.WriteLine("|>>> [ 3  ] - Excluir              | >>> [ 7  ] - Excluir              |");
            Console.WriteLine("|>>> [ 4  ] - Atualizar            | >>> [ 8  ] - Atualizar            |");
            Console.WriteLine("|                                  |                                   |");
            Console.WriteLine("|__________  Motorista  ___________|_____________  Pedido _____________|");
            Console.WriteLine("|                                  |                                   |");
            Console.WriteLine("|>>> [ 9  ] - Listar Todos         |>>> [ 13 ] - Listar Todos          |");
            Console.WriteLine("|>>> [ 10 ] - Cadastrar            |>>> [ 14 ] - Cadastrar             |");
            Console.WriteLine("|>>> [ 11 ] - Excluir              |>>> [ 15 ] - Excluir/Id            |");
            Console.WriteLine("|>>> [ 12 ] - Atualizar            |>>> [ 16 ] - Atualizar             |");
            Console.WriteLine("|                                  |                                   |");
            Console.WriteLine("|___________  Produto  ____________|__________ __ Finalizar ___________|");
            Console.WriteLine("|                                  |                                   |");
            Console.WriteLine("|>>> [ 17 ] - Listar Todos         |>>> [ 0  ] - Sair                  |");
            Console.WriteLine("|>>> [ 18 ] - Cadastrar            |>>>                                |");
            Console.WriteLine("|>>> [ 19 ] - Excluir/Id           |>>>                                |");
            Console.WriteLine("|>>> [ 20 ] - Atualizar            |>>>                                |");
            Console.WriteLine("|__________________________________|___________________________________|");
        }

        public static void ClienteMostrarIdNome()
        {

            try
            {
                //string connection = @"Data Source=DESKTOP-IR1AB95;Initial Catalog=AbsolutoGas;Integrated Security=True;";//CASA
                string connection = @"Data Source=ITELABD04\SQLEXPRESS;Initial Catalog=AbsolutoGas;Integrated Security=True;";//SENAC

                List<Cliente> listarClientes = new List<Cliente>();

                SqlDataReader resultado;
                var query = "SELECT IdCliente, Nome, Telefone FROM Cliente ";

                using (var sql = new SqlConnection(connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Connection.Open();
                    resultado = command.ExecuteReader();


                    while (resultado.Read())
                    {
                        listarClientes.Add(new Cliente(resultado.GetInt32(resultado.GetOrdinal("IdCliente")),
                                                       resultado.GetString(resultado.GetOrdinal("Nome")),
                                                       resultado.GetString(resultado.GetOrdinal("Telefone"))));
                    }
                }
                Console.WriteLine("=====================================");
                Console.WriteLine("======== Listagem de Clientes =======");
                foreach (Cliente p in listarClientes)
                {
                    Console.WriteLine(" Id: " + p.IdCliente);
                    Console.WriteLine(" Nome: " + p.Nome);
                    Console.WriteLine(" Nome: " + p.Telefone);
                    Console.WriteLine("---------------------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }

        public static void VeiculoMostrarIdModelo()
        {

            try
            {
                //string connection = @"Data Source=DESKTOP-IR1AB95;Initial Catalog=Frota;Integrated Security=True;";//CASA
                string connection = @"Data Source=ITELABD04\SQLEXPRESS;Initial Catalog=Frota;Integrated Security=True;";//SENAC
                List<Veiculo> listarVeiculos = new List<Veiculo>();

                SqlDataReader resultado;
                var query = "SELECT IdVeiculo, Placa FROM Veiculo ";

                using (var sql = new SqlConnection(connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Connection.Open();
                    resultado = command.ExecuteReader();


                    while (resultado.Read())
                    {
                        listarVeiculos.Add(new Veiculo(resultado.GetInt32(resultado.GetOrdinal("IdVeiculo")),
                                                     resultado.GetString(resultado.GetOrdinal("Placa"))));
                    }
                }

                Console.WriteLine("======= Listagem de Veiculos ========");
                foreach (Veiculo p in listarVeiculos)
                {
                    Console.WriteLine(" Id: " + p.IdVeiculo);
                    Console.WriteLine(" Modelo: " + p.Placa);
                    Console.WriteLine("---------------------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }

        public static void MotoristaMostrarIdNome()
        {

            try
            {
                //string connection = @"Data Source=DESKTOP-IR1AB95;Initial Catalog=AbsolutoGas;Integrated Security=True;";//CASA
                string connection = @"Data Source=ITELABD04\SQLEXPRESS;Initial Catalog=AbsolutoGas;Integrated Security=True;";//SENAC

                List<Motorista> listarMotoristas = new List<Motorista>();

                SqlDataReader resultado;
                var query = "SELECT IdMotorista, Nome, CNH, Telefone FROM Motorista ";

                using (var sql = new SqlConnection(connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Connection.Open();
                    resultado = command.ExecuteReader();


                    while (resultado.Read())
                    {
                        listarMotoristas.Add(new Motorista(resultado.GetInt32(resultado.GetOrdinal("IdMotorista")),
                                                       resultado.GetString(resultado.GetOrdinal("Nome")),
                                                       resultado.GetString(resultado.GetOrdinal("CNH")),
                                                       resultado.GetString(resultado.GetOrdinal("Telefone"))));
                    }
                }
                Console.WriteLine("=====================================");
                Console.WriteLine("======== Listagem de Motoristas =======");
                foreach (Motorista p in listarMotoristas)
                {
                    Console.WriteLine(" Id: " + p.IdMotorista);
                    Console.WriteLine(" Nome: " + p.Nome);
                    Console.WriteLine(" Nome: " + p.CNH);
                    Console.WriteLine(" Nome: " + p.Telefone);
                    Console.WriteLine("---------------------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }
    }
}
