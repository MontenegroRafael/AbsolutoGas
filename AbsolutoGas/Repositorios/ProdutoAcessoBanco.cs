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
    public class ProdutoAcessoBanco
    {
        //private readonly string _connection = @"Data Source=DESKTOP-IR1AB95;Initial Catalog=AbsolutoGas;Integrated Security=True;";//CASA
        private readonly string _connection = @"Data Source=ITELABD04\SQLEXPRESS;Initial Catalog=AbsolutoGas;Integrated Security=True;";//SENAC

        public bool SalvarProduto(Produto produto)
        {

            try
            {
                var query = @"INSERT INTO Produto (Valor, Descricao)
                              VALUES (@valor @descricao)";

                using (var sql = new SqlConnection(_connection))

                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@valor", produto.Valor);
                    command.Parameters.AddWithValue("@descricao", produto.Descricao);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }

                Console.WriteLine("Produto cadastrado com sucesso.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return false;
            }

        }

        public List<ProdutoDto> BuscarTodos()
        {
            List<ProdutoDto> produtoEncontrados;
            try
            {
                var query = @"SELECT IdProduto, Valor, Descricao  FROM Produto";

                using (var connection = new SqlConnection(_connection))
                {

                    produtoEncontrados = connection.Query<ProdutoDto>(query).ToList();
                }

                return produtoEncontrados;


            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);

                return null;
            }
        }

        public ProdutoDto BuscarPorId(int id)
        {
            ProdutoDto produtoEncontrados;
            try
            {
                var query = @"SELECT Valor ,Descricao FROM Produto
                                      WHERE IdProduto like CONCAT('%',@id,'%')";

                using (var connection = new SqlConnection(_connection))
                {
                    var parametros = new
                    {
                        id
                    };
                    produtoEncontrados = connection.QueryFirstOrDefault<ProdutoDto>(query, parametros);
                }

                return produtoEncontrados;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return null;
            }

        }

        public bool Atualizar(int IdProduto, Produto produto)
        {
            try
            {
                var query = @"UPDATE Produto SET Valor = @valor, Descricao = @descricao
                                WHERE IdProduto = @idProduto";

                using (var sql = new SqlConnection(_connection))

                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@valor", produto.Valor);
                    command.Parameters.AddWithValue("@descricao", produto.Descricao);
                    command.Parameters.AddWithValue("@idProduto", IdProduto);
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
        public void Remover(ProdutoDto id)
        {
            try
            {
                var query = @"DELETE FROM Produto WHERE IdProduto = @id";

                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);

                    command.Parameters.AddWithValue("@id", id.IdProduto);
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
