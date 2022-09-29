using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using Client.Dtos;
using Client.Models;

namespace Client.Service
{
    public class MotoristaService
    {
        public List<MotoristaDto> BuscarTodos()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            //Busca todos os motoristas dentro da api;
            try
            {
                //monta a request para a api;
                response = httpClient.GetAsync("https://localhost:44345/motorista/buscartodos").Result; // CASA
                //response = httpClient.GetAsync("https://localhost:44335/motorista/buscartodos").Result; // SENAC
                response.EnsureSuccessStatusCode();

                var resultado = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine(resultado);
                    return new List<MotoristaDto>();
                }
                //converte os dados recebidos e retorna eles como objetos do C#;
                var objetoDesserializado = JsonConvert.DeserializeObject<List<MotoristaDto>>(resultado);

                return objetoDesserializado;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                return new List<MotoristaDto>();
            }
        }

        public void Salvar(Motorista motorista)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            var json = JsonConvert.SerializeObject(motorista);

            try
            {
                //monta a request para a api;
                response = httpClient.PostAsync("https://localhost:44345/motorista/save", new StringContent(json, Encoding.UTF8, "application/json")).Result; // CASA
                //response = httpClient.PostAsync("https://localhost:44335/motorista/save", new StringContent(json, Encoding.UTF8, "application/json")).Result; // SENAC
                response.EnsureSuccessStatusCode();

                var resultado = response.Content.ReadAsStringAsync().Result;

                //converte os dados recebidos e retorna eles como objetos do C#;

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Salvar2(Motorista motorista) // SALVAR VIA API
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            var json = JsonConvert.SerializeObject(motorista);

            try
            {
                //monta a request para a api;

                response = httpClient.PostAsync("https://localhost:44345/motorista/salvarviaapi", new StringContent(json, Encoding.UTF8, "application/json")).Result; // CASA
                //response = httpClient.PostAsync("https://localhost:44335/motorista/salvarviaapi", new StringContent(json, Encoding.UTF8, "application/json")).Result; // SENAC
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
                response = httpClient.DeleteAsync($"https://localhost:44345/motorista/remover?nome={nome}").Result; // CASA
                //response = httpClient.DeleteAsync($"https://localhost:44335/motorista/remover?nome={nome}").Result; // SENAC

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

        public void Atualizar(int idMotorista, Motorista motorista)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            var viewModel = new
            {
                IdEncontrar = idMotorista,
                Atualizar = motorista
            };

            try
            {
                var json = JsonConvert.SerializeObject(viewModel);
                //monta a request para a api;
                response = httpClient.PutAsync($"https://localhost:44345/motorista/atualizar", new StringContent(json, Encoding.UTF8, "application/json")).Result;
                //response = httpClient.PutAsync($"https://localhost:44335/motorista/atualizar", new StringContent(json, Encoding.UTF8, "application/json")).Result;

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
