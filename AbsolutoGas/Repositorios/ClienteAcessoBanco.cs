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
    public class ClienteAcessoBanco
    {
        private readonly string _connection = @"Data Source=DESKTOP-IR1AB95;Initial Catalog=AbsolutoGas;Integrated Security=True;";//CASA
        //private readonly string _connection = @"Data Source=ITELABD04\SQLEXPRESS;Initial Catalog=AbsolutoGas;Integrated Security=True;";//SENAC

        public bool SalvarCliente(Cliente cliente)
        {

            try
            {
                var query = @"INSERT INTO Cliente 
                              (Nome, CPF, DataNascimento, Telefone, Rua, Numero, Bairro, Cidade, Referencia, TipoContato)
                              VALUES (@nome,@CPF,@dataNascimento,@telefone,@rua,@numero,@bairro,@cidade,@referencia,@tipoContato)";

                using (var sql = new SqlConnection(_connection))

                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@nome", cliente.Nome);
                    command.Parameters.AddWithValue("@CPF", cliente.CPF);
                    command.Parameters.AddWithValue("@dataNascimento", cliente.DataNascimento);
                    command.Parameters.AddWithValue("@telefone", cliente.Telefone);
                    command.Parameters.AddWithValue("@rua", cliente.Rua);
                    command.Parameters.AddWithValue("@numero", cliente.Numero);
                    command.Parameters.AddWithValue("@bairro", cliente.Bairro);
                    command.Parameters.AddWithValue("@cidade", cliente.Cidade);
                    command.Parameters.AddWithValue("@referencia", cliente.Referencia);
                    command.Parameters.AddWithValue("@tipoContato", cliente.TipoContato);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }

                Console.WriteLine("Cliente cadastrado com sucesso.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return false;
            }

        }

        public List<ClienteDto> BuscarTodos()
        {
            List<ClienteDto> clientesEncontrados;
            try
            {
                var query = @"SELECT IdCliente, Nome, CPF, DataNascimento, Telefone, Rua, Numero, Bairro, Cidade, Referencia, TipoContato  FROM Cliente";

                using (var connection = new SqlConnection(_connection))
                {

                    clientesEncontrados = connection.Query<ClienteDto>(query).ToList();
                }

                return clientesEncontrados;


            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);

                return null;
            }
        }

        public ClienteDto BuscarPorNome(string nome)
        {
            ClienteDto clientesEncontrados;
            try
            {
                var query = @"SELECT IdCliente, Nome, CPF, DataNascimento, Telefone, Rua, Numero, Bairro, Cidade, Referencia, TipoContato FROM Cliente
                                      WHERE Nome like CONCAT('%',@nome,'%')";

                using (var connection = new SqlConnection(_connection))
                {
                    var parametros = new
                    {
                        nome
                    };
                    clientesEncontrados = connection.QueryFirstOrDefault<ClienteDto>(query, parametros);
                }

                return clientesEncontrados;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return null;
            }

        }

        public bool Atualizar(int idCliente, Cliente cliente)
        {
            try
            {
                var query = @"UPDATE Cliente SET Nome = @nome, CPF = @CPF, DataNascimento = @dataNascimento, Telefone = @telefone, Rua = @rua, Numero = @numero, Bairro = @bairro, Cidade = @cidade, Referencia = @referencia, TipoContato = @tipoContato
                                WHERE IdCliente = @idCliente";

                using (var sql = new SqlConnection(_connection))

                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@nome", cliente.Nome);
                    command.Parameters.AddWithValue("@CPF", cliente.CPF);
                    command.Parameters.AddWithValue("@dataNascimento", cliente.DataNascimento);
                    command.Parameters.AddWithValue("@telefone", cliente.Telefone);
                    command.Parameters.AddWithValue("@rua", cliente.Rua);
                    command.Parameters.AddWithValue("@numero", cliente.Numero);
                    command.Parameters.AddWithValue("@bairro", cliente.Bairro);
                    command.Parameters.AddWithValue("@cidade", cliente.Cidade);
                    command.Parameters.AddWithValue("@referencia", cliente.Referencia);
                    command.Parameters.AddWithValue("@idCliente", idCliente);
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
        public void Remover(ClienteDto nome)
        {
            try
            {
                var query = @"DELETE FROM Cliente WHERE Nome = @nome";

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
