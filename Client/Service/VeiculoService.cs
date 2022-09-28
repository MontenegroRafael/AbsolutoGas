using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using Client.Dtos;
using Client.Models;

namespace Client.Service
{
    public class VeiculoService
    {
        public List<VeiculoDto> BuscarTodos()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            //Busca todos os clientes dentro da api;
            try
            {
                //monta a request para a api;
                response = httpClient.GetAsync("https://localhost:44345/veiculo/buscartodos").Result; // CASA
                //response = httpClient.GetAsync("https://localhost:44335/veiculo/buscartodos").Result; // SENAC
                response.EnsureSuccessStatusCode();

                var resultado = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine(resultado);
                    return new List<VeiculoDto>();
                }
                //converte os dados recebidos e retorna eles como objetos do C#;
                var objetoDesserializado = JsonConvert.DeserializeObject<List<VeiculoDto>>(resultado);

                return objetoDesserializado;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                return new List<VeiculoDto>();
            }
        }

        public void Salvar(Veiculo veiculo)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            var json = JsonConvert.SerializeObject(veiculo);

            try
            {
                //monta a request para a api;
                response = httpClient.PostAsync("https://localhost:44345/veiculo/save", new StringContent(json, Encoding.UTF8, "application/json")).Result; // CASA
                //response = httpClient.PostAsync("https://localhost:44335/veiculo/save", new StringContent(json, Encoding.UTF8, "application/json")).Result; // SENAC
                response.EnsureSuccessStatusCode();

                var resultado = response.Content.ReadAsStringAsync().Result;

                //converte os dados recebidos e retorna eles como objetos do C#;

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Salvar2(Veiculo veiculo) // SALVAR VIA API
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            var json = JsonConvert.SerializeObject(veiculo);

            try
            {
                //monta a request para a api;

                response = httpClient.PostAsync("https://localhost:44345/veiculo/salvarviaapi", new StringContent(json, Encoding.UTF8, "application/json")).Result; // CASA
                //response = httpClient.PostAsync("https://localhost:44335/veiculo/salvarviaapi", new StringContent(json, Encoding.UTF8, "application/json")).Result; // SENAC
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
                response = httpClient.DeleteAsync($"https://localhost:44335/veiculo/remover?nome={nome}").Result; // CASA
                //response = httpClient.DeleteAsync($"https://localhost:44335/veiculo/remover?nome={nome}").Result; // SENAC

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

        public void Atualizar(int idVeiculo, Veiculo veiculo)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            var viewModel = new
            {
                IdEncontrar = idVeiculo,
                Atualizar = veiculo
            };

            try
            {
                var json = JsonConvert.SerializeObject(viewModel);
                // MONTA A REQUEST PARA A API;
                response = httpClient.PutAsync($"https://localhost:44335/veiculo/atualizar", new StringContent(json, Encoding.UTF8, "application/json")).Result;

                // CONVERTE OS DADOS RECEBIDOS E RETORNA ELES COMO OBJETOS DE C#;
                var resultado = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine(resultado);
                }

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
