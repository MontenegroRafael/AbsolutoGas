using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using Client.Dtos;
using Client.Models;

namespace Client.Service
{
    public class ProdutoService
    {
        public List<ProdutoDto> BuscarTodos()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            //Busca todos os produtos dentro da api;
            try
            {
                //monta a request para a api;
                response = httpClient.GetAsync("https://localhost:44345/produto/buscartodos").Result; // CASA
                //response = httpClient.GetAsync("https://localhost:44335/produto/buscartodos").Result; // SENAC
                response.EnsureSuccessStatusCode();

                var resultado = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine(resultado);
                    return new List<ProdutoDto>();
                }
                //converte os dados recebidos e retorna eles como objetos do C#;
                var objetoDesserializado = JsonConvert.DeserializeObject<List<ProdutoDto>>(resultado);

                return objetoDesserializado;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                return new List<ProdutoDto>();
            }
        }

        public void Salvar(Produto produto)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            var json = JsonConvert.SerializeObject(produto);

            try
            {
                //monta a request para a api;
                response = httpClient.PostAsync("https://localhost:44345/produto/save", new StringContent(json, Encoding.UTF8, "application/json")).Result; // CASA
                //response = httpClient.PostAsync("https://localhost:44335/produto/save", new StringContent(json, Encoding.UTF8, "application/json")).Result; // SENAC
                response.EnsureSuccessStatusCode();

                var resultado = response.Content.ReadAsStringAsync().Result;

                //converte os dados recebidos e retorna eles como objetos do C#;

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Salvar2(Produto produto) // SALVAR VIA API
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            var json = JsonConvert.SerializeObject(produto);

            try
            {
                //monta a request para a api;

                response = httpClient.PostAsync("https://localhost:44345/produto/salvarviaapi", new StringContent(json, Encoding.UTF8, "application/json")).Result; // CASA
                //response = httpClient.PostAsync("https://localhost:44335/produto/salvarviaapi", new StringContent(json, Encoding.UTF8, "application/json")).Result; // SENAC
                response.EnsureSuccessStatusCode();

                var resultado = response.Content.ReadAsStringAsync().Result;

                //converte os dados recebidos e retorna eles como objetos do C#;

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Remover(string nome)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            //var viewModel = new
            //{
            //    IdEncontrar = nome
            //};

            try
            {
                //var json = JsonConvert.SerializeObject(viewModel);
                //monta a request para a api;
                response = httpClient.DeleteAsync($"https://localhost:44335/produto/remover?nome={nome}").Result; // CASA
                //response = httpClient.DeleteAsync($"https://localhost:44335/produto/remover?nome={nome}").Result; // SENAC

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
