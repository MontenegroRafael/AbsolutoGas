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
            //VeiculoService veiculoService = new VeiculoService();
            //SituacaoService situacaoService = new SituacaoService();
            //AluguelService aluguelService = new AluguelService();
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
                    Console.Write("CNH: ");
                    string Cnh = Console.ReadLine();
                    Console.Write("Login de Cadastro: ");
                    string LoginCadastro = Console.ReadLine();
                    
                    Cliente cliente = new Cliente(Nome, Cnh, LoginCadastro);

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

                    Console.Write("Nome:");
                    string Nome = Console.ReadLine();
                    Console.Write("CNH: ");
                    string Cnh = Console.ReadLine();
                    Console.Write("Login de Cadastro:");
                    string LoginCadastro = Console.ReadLine();
                    Console.WriteLine("=====================================");
                    //  VALIDAÇÃO DO LOGIN
                    while (!Validacao.Validar.Login(LoginCadastro))
                    {
                        Console.WriteLine("=====================================");
                        Console.WriteLine("###### - LOGIN INVALIDO! - ######");
                        Console.WriteLine("Digite novamente.");
                        Console.WriteLine("Login de Cadastro:");
                        LoginCadastro = Console.ReadLine();
                        Console.WriteLine("=====================================");
                    }
                    Cliente cliente = new Cliente(Nome, Cnh, LoginCadastro);

                    clienteService.Atualizar(idCliente, cliente);
                    Console.WriteLine("=====================================");
                    Console.WriteLine(" - Cliente ATUALIZADO com sucesso!");
                    Console.WriteLine("=====================================");

                }

            }
    }
}
