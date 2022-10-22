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
    public class PedidoAcessoBanco
    {
        private readonly string _connection = @"Data Source=DESKTOP-IR1AB95;Initial Catalog=AbsolutoGas;Integrated Security=True;";//CASA
        //private readonly string _connection = @"Data Source=ITELABD04\SQLEXPRESS;Initial Catalog=AbsolutoGas;Integrated Security=True;";//SENAC

        public bool SalvarPedido(Pedido pedido)
        {

            try
            {
                var query = @"INSERT INTO Pedido (DataEntrega, HoraEntrega, IdCliente, IdProduto, IdPagamento, IdVeiculo, IdMotorista, ValorTotal, Situacao)
                              VALUES (@dataEntrega, @horaEntrega, @idCliente, @idProduto, @idPagamento, @idVeiculo, @idMotorista, @valorTotal, @situacao)";


                using (var sql = new SqlConnection(_connection))

                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@dataEntrega", pedido.DataEntrega);
                    command.Parameters.AddWithValue("@horaEntrega", pedido.HoraEntrega);
                    command.Parameters.AddWithValue("@idCliente", pedido.IdCliente);
                    command.Parameters.AddWithValue("@idProduto", pedido.IdProduto);
                    command.Parameters.AddWithValue("@idPagamento", pedido.IdPagamento);
                    command.Parameters.AddWithValue("@idVeiculo", pedido.IdVeiculo);
                    command.Parameters.AddWithValue("@idMotorista", pedido.IdMotorista);
                    command.Parameters.AddWithValue("@valorTotal", pedido.ValorTotal);
                    command.Parameters.AddWithValue("@situacao", pedido.Situacao);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }

                Console.WriteLine("Pedido cadastrado com sucesso.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return false;
            }

        }

        public List<PedidoDto> BuscarTodos()
        {
            List<PedidoDto> pedidoEncontrados;
            try
            {
                var query = @"SELECT IdPedido, DataEntrega, HoraEntrega, IdCliente, IdProduto, IdPagamento, IdVeiculo, ValorTotal, Situacao  FROM Pedido";

                using (var connection = new SqlConnection(_connection))
                {

                    pedidoEncontrados = connection.Query<PedidoDto>(query).ToList();
                }

                return pedidoEncontrados;


            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);

                return null;
            }
        }

        public PedidoDto BuscarPorId(int idPedido)
        {
            PedidoDto pedidoEncontrados;
            try
            {
                var query = @"SELECT IdPedido, DataEntrega, HoraEntrega, IdCliente, IdProduto, IdPagamento, IdVeiculo, ValorTotal, Situacao FROM Pedido
                                      WHERE IdPedido like CONCAT('%',@idPedido,'%')";

                using (var connection = new SqlConnection(_connection))
                {
                    var parametros = new
                    {
                        idPedido
                    };
                    pedidoEncontrados = connection.QueryFirstOrDefault<PedidoDto>(query, parametros);
                }

                return pedidoEncontrados;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return null;
            }

        }

        public bool Atualizar(int IdPedido, Pedido pedido)
        {
            try
            {
                var query = @"UPDATE Pedido SET DataEntrega = @dataEntrega, HoraEntrega = @horaEntrega, IdCliente = @idCliente, IdProduto = @idProduto, IdPagamento = @idPagamento, IdVeiculo = @idVeiculo, ValorTotal = @valorTotal, Situacao = @Situacao 
                                WHERE IdPedido = @idPedido";

                using (var sql = new SqlConnection(_connection))

                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@dataEntrega", pedido.DataEntrega);
                    command.Parameters.AddWithValue("@horaEntrega", pedido.HoraEntrega);
                    command.Parameters.AddWithValue("@idCliente", pedido.IdCliente);
                    command.Parameters.AddWithValue("@idProduto", pedido.IdProduto);
                    command.Parameters.AddWithValue("@idPagamento", pedido.IdPagamento);
                    command.Parameters.AddWithValue("@idVeiculo", pedido.IdVeiculo);
                    command.Parameters.AddWithValue("@valorTotal", pedido.ValorTotal);
                    command.Parameters.AddWithValue("@situacao", pedido.Situacao);
                    command.Parameters.AddWithValue("@idPedido", IdPedido);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
                Console.WriteLine("Pedido atualizado com sucesso.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return false;
            }
        }
        public void Remover(PedidoDto id)
        {
            try
            {
                var query = @"DELETE FROM Pedido WHERE IdPedido = @id";

                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);

                    command.Parameters.AddWithValue("@id", id.IdPedido);
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
