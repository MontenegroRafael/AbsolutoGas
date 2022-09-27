using AbsolutoGas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using AbsolutoGas.Dtos;
using System.Threading.Tasks;
using Dapper;

namespace AbsolutoGas.Repositorios
{
    public class VeiculoAcessoBanco
    {
        private readonly string _connection = @"Data Source=DESKTOP-IR1AB95;Initial Catalog=AbsolutoGas;Integrated Security=True;";//CASA
        //private readonly string _connection = @"Data Source=ITELABD04\SQLEXPRESS;Initial Catalog=AbsolutoGas;Integrated Security=True;";//SENAC

        public bool SalvarVeiculo(Veiculo veiculo)
        {

            try
            {
                var query = @"INSERT INTO Veiculo (Placa, IdMotorista)
                              VALUES (@placa, @idMotorista)";

                using (var sql = new SqlConnection(_connection))

                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@placa", veiculo.Placa);
                    command.Parameters.AddWithValue("@idMotorista", veiculo.IdMotorista);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }

                Console.WriteLine("Veiculo cadastrado com sucesso.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return false;
            }

        }

        public List<VeiculoDto> BuscarTodos()
        {
            List<VeiculoDto> veiculoEncontrados;
            try
            {
                var query = @"SELECT IdVeiculo, Placa, IdMotorista  FROM Veiculo";

                using (var connection = new SqlConnection(_connection))
                {

                    veiculoEncontrados = connection.Query<VeiculoDto>(query).ToList();
                }

                return veiculoEncontrados;


            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);

                return null;
            }
        }

        public VeiculoDto BuscarPorId(int id)
        {
            VeiculoDto veiculoEncontrados;
            try
            {
                var query = @"SELECT IdVeiculo, Placa, IdMotorista FROM Veiculo
                                      WHERE IdVeiculo like CONCAT('%',@id,'%')";

                using (var connection = new SqlConnection(_connection))
                {
                    var parametros = new
                    {
                        id
                    };
                    veiculoEncontrados = connection.QueryFirstOrDefault<VeiculoDto>(query, parametros);
                }

                return veiculoEncontrados;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return null;
            }

        }

        public bool Atualizar(int IdVeiculo, Veiculo veiculo)
        {
            try
            {
                var query = @"UPDATE Veiculo SET Placa = @placa, IdMotorista = @idMotorista 
                                WHERE IdVeiculo = @idVeiculo";

                using (var sql = new SqlConnection(_connection))

                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@placa", veiculo.Placa);
                    command.Parameters.AddWithValue("@idMotorista", veiculo.IdMotorista);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return false;
            }
        }
        public void Remover(VeiculoDto id)
        {
            try
            {
                var query = @"DELETE FROM Veiculo WHERE IdVeiculo = @id";

                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);

                    command.Parameters.AddWithValue("@id", id.IdVeiculo);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }

        }
    }
}
