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
    public class MotoristaAcessoBanco
    {
        private readonly string _connection = @"Data Source=DESKTOP-IR1AB95;Initial Catalog=AbsolutoGas;Integrated Security=True;";//CASA
        //private readonly string _connection = @"Data Source=ITELABD04\SQLEXPRESS;Initial Catalog=AbsolutoGas;Integrated Security=True;";//SENAC

        public bool SalvarMotorista(Motorista motorista)
        {

            try
            {
                var query = @"INSERT INTO Motorista (Nome, CNH, Telefone)
                              VALUES (@nome,@CNH,@telefone)";

                using (var sql = new SqlConnection(_connection))

                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@nome", motorista.Nome);
                    command.Parameters.AddWithValue("@CNH", motorista.CNH);
                    command.Parameters.AddWithValue("@telefone", motorista.Telefone);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }

                Console.WriteLine("Motorista cadastrado com sucesso.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return false;
            }

        }

        public List<MotoristaDto> BuscarTodos()
        {
            List<MotoristaDto> motoristaEncontrados;
            try
            {
                var query = @"SELECT IdMotorista, Nome, CNH, Telefone  FROM Motorista";

                using (var connection = new SqlConnection(_connection))
                {

                    motoristaEncontrados = connection.Query<MotoristaDto>(query).ToList();
                }

                return motoristaEncontrados;


            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);

                return null;
            }
        }

        public MotoristaDto BuscarPorNome(string nome)
        {
            MotoristaDto motoristaEncontrados;
            try
            {
                var query = @"SELECT IdMotorista, Nome, CNH, Telefone FROM Motorista
                                      WHERE Nome like CONCAT('%',@nome,'%')";

                using (var connection = new SqlConnection(_connection))
                {
                    var parametros = new
                    {
                        nome
                    };
                    motoristaEncontrados = connection.QueryFirstOrDefault<MotoristaDto>(query, parametros);
                }

                return motoristaEncontrados;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return null;
            }

        }

        public bool Atualizar(int IdMotorista, Motorista motorista)
        {
            try
            {
                var query = @"UPDATE Motorista SET Nome = @nome, CNH = @CNH, Telefone = @telefone 
                                WHERE IdMotorista = @idMotorista";

                using (var sql = new SqlConnection(_connection))

                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@nome", motorista.Nome);
                    command.Parameters.AddWithValue("@CNH", motorista.CNH);
                    command.Parameters.AddWithValue("@telefone", motorista.Telefone);
                    command.Parameters.AddWithValue("@idMotorista", IdMotorista);
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
        public void Remover(MotoristaDto nome)
        {
            try
            {
                var query = @"DELETE FROM Motorista WHERE Nome = @nome";

                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);

                    command.Parameters.AddWithValue("@nome", nome.Nome);
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
