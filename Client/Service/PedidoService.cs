using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using Client.Dtos;
using Client.Models;

namespace Client.Service
{
    public class PedidoService
    {
        public List<PedidoDto> BuscarTodos()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            //Busca todos os pedidos dentro da api;
            try
            {
                //monta a request para a api;
                response = httpClient.GetAsync("https://localhost:44345/pedido/buscartodos").Result; // CASA
                //response = httpClient.GetAsync("https://localhost:44335/pedido/buscartodos").Result; // SENAC
                response.EnsureSuccessStatusCode();

                var resultado = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine(resultado);
                    return new List<PedidoDto>();
                }
                //converte os dados recebidos e retorna eles como objetos do C#;
                var objetoDesserializado = JsonConvert.DeserializeObject<List<PedidoDto>>(resultado);

                return objetoDesserializado;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                return new List<PedidoDto>();
            }
        }

        public void Salvar(Pedido pedido)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            var json = JsonConvert.SerializeObject(pedido);

            try
            {
                //monta a request para a api;
                response = httpClient.PostAsync("https://localhost:44345/pedido/save", new StringContent(json, Encoding.UTF8, "application/json")).Result; // CASA
                //response = httpClient.PostAsync("https://localhost:44335/pedido/save", new StringContent(json, Encoding.UTF8, "application/json")).Result; // SENAC
                response.EnsureSuccessStatusCode();

                var resultado = response.Content.ReadAsStringAsync().Result;

                //converte os dados recebidos e retorna eles como objetos do C#;

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Salvar2(Pedido pedido) // SALVAR VIA API
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            var json = JsonConvert.SerializeObject(pedido);

            try
            {
                //monta a request para a api;

                response = httpClient.PostAsync("https://localhost:44345/pedido/salvarviaapi", new StringContent(json, Encoding.UTF8, "application/json")).Result; // CASA
                //response = httpClient.PostAsync("https://localhost:44335/pedido/salvarviaapi", new StringContent(json, Encoding.UTF8, "application/json")).Result; // SENAC
                response.EnsureSuccessStatusCode();

                var resultado = response.Content.ReadAsStringAsync().Result;

                //converte os dados recebidos e retorna eles como objetos do C#;

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Remover(int id)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            var viewModel = new
            {
                IdEncontrar = id
            };

            try
            {
                var json = JsonConvert.SerializeObject(viewModel);
                //monta a request para a api;
                response = httpClient.DeleteAsync($"https://localhost:44335/pedido/remover?idproduto={id}").Result; // CASA
                //response = httpClient.DeleteAsync($"https://localhost:44335/pedido/remover?idproduto={id}").Result; // SENAC

                var resultado = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine(resultado);
                }
                //converte os dados recebidos e retorna eles como objetos do C#;

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
