/* - “Digno és tu, Senhor e Deus nosso, de receber a glória, a honra e o poder, 
      pois foste tu que criaste o universo; por tua vontade, ele não era e foi criado." 
   - Apocalipse 4:11 .*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Client.Models;
using Client.Service;
using Newtonsoft.Json;
using Client.Menu;

namespace Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // INSTANCIAR
            ClienteService clienteService = new ClienteService();
            MotoristaService motoristaService = new MotoristaService();
            PedidoService pedidoService = new PedidoService();
            ProdutoService produtoService = new ProdutoService();
            VeiculoService veiculoService = new VeiculoService();
            
            //ControleFrotaService controleFrotaService = new ControleFrotaService();

            Listar.MostarMenu();
            Console.Write("Qual Opção Deseja? ");
            int opcao = Convert.ToInt32(Console.ReadLine());

            while (true)
            {
                // CLIENTE - MOSTRAR LISTA DE CLIENTES
                if (opcao == 1)
                {
                    var resultado = clienteService.BuscarTodos();
                    // MOSTRA OS DADOS NA TELA
                    foreach (var item in resultado)
                    {
                        Console.WriteLine("=====================================");
                        Console.WriteLine("Id: " + item.IdCliente);
                        Console.WriteLine("Nome: " + item.Nome);
                        Console.WriteLine("CPF: " + item.CPF);
                        Console.WriteLine("Data de Nascimento: " + item.DataNascimento);
                        Console.WriteLine("Telefone: " + item.Telefone);
                        Console.WriteLine("Rua: " + item.Rua);
                        Console.WriteLine("Número: " + item.Numero);
                        Console.WriteLine("Bairro: " + item.Bairro);
                        Console.WriteLine("Cidade: " + item.Cidade);
                        Console.WriteLine("Referencia: " + item.Referencia);
                        Console.WriteLine("=====================================");
                    }
                }

                // CLIENTE - CADASTRAR CLIENTE
                else if (opcao == 2)
                {
                    Console.WriteLine("Informe os dados do Cliente:");
                    Console.Write("Nome: ");
                    string Nome = Console.ReadLine();
                    Console.Write("CPF: ");
                    string CPF = Console.ReadLine();
                    Console.Write("Data de Nascimento: ");
                    DateTime DataNascimento = Convert.ToDateTime(Console.ReadLine());
                    Console.Write("Telefone: ");
                    string Telefone = Console.ReadLine();
                    Console.Write("Rua: ");
                    string Rua = Console.ReadLine();
                    Console.Write("Número: ");
                    string Numero = Console.ReadLine();
                    Console.Write("Bairro: ");
                    string Bairro = Console.ReadLine();
                    Console.Write("Cidade: ");
                    string Cidade = Console.ReadLine();
                    Console.Write("Referencia: ");
                    string Referencia = Console.ReadLine();
                    Console.Write("Tipo de Contato[WhatsApp/Comercial/Residencial]: ");
                    string TipoContato = Console.ReadLine();

                    Cliente cliente = new Cliente(Nome, CPF, DataNascimento, Telefone, Rua, Numero, Bairro, Cidade, Referencia, TipoContato);

                    clienteService.Salvar(cliente);

                    Console.WriteLine("=====================================");
                    Console.WriteLine(" - Cliente CADASTRADO com sucesso!");
                    Console.WriteLine("=====================================");
                }

                // CLIENTE - EXCLUIR CLIENTE POR NOME
                else if (opcao == 3)
                {
                    Listar.ClienteMostrarIdNome();
                    Console.Write("Informe o NOME do cliente para excluir: ");
                    string nome = Console.ReadLine();

                    clienteService.Remover(nome);

                    Console.WriteLine("=====================================");
                    Console.WriteLine(" - Cliente DELETADO com sucesso!");
                    Console.WriteLine("=====================================");
                }

                // CLIENTE - ATUALIZAR CLIENTE POR ID
                else if (opcao == 4)
                {
                    Listar.ClienteMostrarIdNome();
                    Console.Write("Informe o Id do cliente para atualizar: ");
                    int idCliente = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("=====================================");
                    Console.WriteLine("Informe os dados do Cliente:");

                    Console.WriteLine("Informe os dados do Cliente:");
                    Console.Write("Nome: ");
                    string Nome = Console.ReadLine();
                    Console.Write("CPF: ");
                    string CPF = Console.ReadLine();
                    Console.Write("Data de Nascimento: ");
                    DateTime DataNascimento = Convert.ToDateTime(Console.ReadLine());
                    Console.Write("Telefone: ");
                    string Telefone = Console.ReadLine();
                    Console.Write("Rua: ");
                    string Rua = Console.ReadLine();
                    Console.Write("Número: ");
                    string Numero = Console.ReadLine();
                    Console.Write("Bairro: ");
                    string Bairro = Console.ReadLine();
                    Console.Write("Cidade: ");
                    string Cidade = Console.ReadLine();
                    Console.Write("Referencia: ");
                    string Referencia = Console.ReadLine();
                    Console.Write("Tipo de Contato[WhatsApp/Comercial/Residencial]: ");
                    string TipoContato = Console.ReadLine();
                    Console.WriteLine("=====================================");


                    Cliente cliente = new Cliente(Nome, CPF, DataNascimento, Telefone, Rua, Numero, Bairro, Cidade, Referencia, TipoContato);

                    clienteService.Atualizar(idCliente, cliente);
                    Console.WriteLine("=====================================");
                    Console.WriteLine(" - Cliente ATUALIZADO com sucesso!");
                    Console.WriteLine("=====================================");

                }

                // VEICULO - MOSTRAR LISTA DE VEICULOS
                else if (opcao == 5)
                {
                    var resultado = veiculoService.BuscarTodos();
                    // MOSTRA OS DADOS NA TELA
                    foreach (var item in resultado)
                    {
                        Console.WriteLine("=====================================");
                        Console.WriteLine("Id: " + item.IdVeiculo);
                        Console.WriteLine("Placa: " + item.Placa);
                        Console.WriteLine("=====================================");
                    }
                }

                // VEICULO - CADASTRAR VEICULO
                else if (opcao == 6)
                {
                    Console.WriteLine("Informe os dados do Veiculo:");
                    Console.Write("Placa: ");
                    string Placa = Console.ReadLine();

                    

                    Veiculo veiculo = new Veiculo(Placa);

                    veiculoService.Salvar(veiculo);

                    Console.WriteLine("=====================================");
                    Console.WriteLine(" - Veiculo CADASTRADO com sucesso!");
                    Console.WriteLine("=====================================");
                }

                // VEICULO - EXCLUIR VEICULO POR PLACA
                else if (opcao == 7)
                {
                    Listar.VeiculoMostrarIdModelo();
                    Console.Write("Informe a PLACA do veiculo para excluir: ");
                    string placa = Console.ReadLine();

                    veiculoService.Remover(placa);

                    Console.WriteLine("=====================================");
                    Console.WriteLine(" - Veiculo DELETADO com sucesso!");
                    Console.WriteLine("=====================================");
                }

                // VEICULO - ATUALIZAR VEICULO POR ID
                else if (opcao == 8)
                {
                    Listar.VeiculoMostrarIdModelo();
                    Console.Write("Informe o Id do veiculo para atualizar: ");
                    int idVeiculo = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("=====================================");
                    Console.WriteLine("Informe os dados do Veiculo:");

                    Console.Write("Placa: ");
                    string Placa = Console.ReadLine();
                    
                    Console.WriteLine("=====================================");

                    Veiculo veiculo = new Veiculo(Placa);

                    veiculoService.Atualizar(idVeiculo, veiculo);

                    Console.WriteLine("=====================================");
                    Console.WriteLine(" - Veiculo ATUALIZADO com sucesso!");
                    Console.WriteLine("=====================================");
                }

                // MOTORISTA - MOSTRAR LISTA DE MOTORISTAS
                else if (opcao == 9)
                {
                    var resultado = motoristaService.BuscarTodos();
                    // MOSTRA OS DADOS NA TELA
                    foreach (var item in resultado)
                    {
                        Console.WriteLine("=====================================");
                        Console.WriteLine("Id: " + item.IdMotorista);
                        Console.WriteLine("Nome: " + item.Nome);
                        Console.WriteLine("CNH: " + item.CNH);
                        Console.WriteLine("Telefone: " + item.Telefone);
                        Console.WriteLine("=====================================");
                    }
                }

                // MOTORISTA - CADASTRAR MOTORISTA
                else if (opcao == 10)
                {
                    Console.WriteLine("Informe os dados do Motorista:");
                    Console.Write("Nome: ");
                    string Nome = Console.ReadLine();
                    Console.Write("CNH: ");
                    string CNH = Console.ReadLine();
                    Console.Write("Telefone: ");
                    string Telefone = Console.ReadLine();
                    
                    Motorista motorista = new Motorista(Nome, CNH, Telefone);

                    motoristaService.Salvar(motorista);

                    Console.WriteLine("=====================================");
                    Console.WriteLine(" - Motorista CADASTRADO com sucesso!");
                    Console.WriteLine("=====================================");
                }

                // MOTORISTA - EXCLUIR MOTORISTA POR NOME
                else if (opcao == 11)
                {
                    Listar.MotoristaMostrarIdNome();
                    Console.Write("Informe o NOME do Motorista para excluir: ");
                    string nome = Console.ReadLine();

                    motoristaService.Remover(nome);

                    Console.WriteLine("=====================================");
                    Console.WriteLine(" - Motorista DELETADO com sucesso!");
                    Console.WriteLine("=====================================");
                }

                // MOTORISTA - ATUALIZAR MOTORISTA POR ID
                else if (opcao == 12)
                {
                    Listar.MotoristaMostrarIdNome();
                    Console.Write("Informe o Id do motorista para atualizar: ");
                    int idMotorista = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("=====================================");
                    Console.WriteLine("Informe os dados do Motorista:");

                    Console.Write("Nome: ");
                    string Nome = Console.ReadLine();
                    Console.Write("CNH: ");
                    string CNH = Console.ReadLine();
                    Console.Write("Telefone: ");
                    string Telefone = Console.ReadLine();
                    Console.WriteLine("=====================================");

                    Motorista motorista = new Motorista(Nome, CNH, Telefone);

                    motoristaService.Atualizar(idMotorista, motorista);
                    Console.WriteLine("=====================================");
                    Console.WriteLine(" - Motorista ATUALIZADO com sucesso!");
                    Console.WriteLine("=====================================");

                }


                // SAIR DO PROGRAMA
                else if (opcao == 0)
                {
                    break;
                }

                // OPÇÃO INVALIDA
                else
                {
                    Console.WriteLine("**** Opção Invalida! - DIGITE UMA OPÇÃO VALIDA - ");
                }

                Listar.MostarMenu();
                Console.Write("Qual Opção Deseja? ");
                opcao = Convert.ToInt32(Console.ReadLine());
            
            }
        }
    }
}
