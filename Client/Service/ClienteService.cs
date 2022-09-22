using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using Client.Dtos;
using Client.Models;


namespace Client.Service
{
    class ClienteService
    {
        public List<ClienteDto> BuscarTodos()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            //Busca todos os clientes dentro da api;
            try
            {
                //monta a request para a api;
                response = httpClient.GetAsync("https://localhost:44335/cliente/buscartodos").Result;
                response.EnsureSuccessStatusCode();

                var resultado = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine(resultado);
                    return new List<ClienteDto>();
                }
                //converte os dados recebidos e retorna eles como objetos do C#;
                var objetoDesserializado = JsonConvert.DeserializeObject<List<ClienteDto>>(resultado);

                return objetoDesserializado;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                return new List<ClienteDto>();
            }
        }

        public void Salvar(Cliente cliente)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            var json = JsonConvert.SerializeObject(cliente);

            try
            {
                //monta a request para a api;
                response = httpClient.PostAsync("https://localhost:44335/cliente/save", new StringContent(json, Encoding.UTF8, "application/json")).Result;
                response.EnsureSuccessStatusCode();

                var resultado = response.Content.ReadAsStringAsync().Result;

                //converte os dados recebidos e retorna eles como objetos do C#;

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Salvar2(Cliente cliente) // SALVAR VIA API
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            var json = JsonConvert.SerializeObject(cliente);

            try
            {
                //monta a request para a api;
                response = httpClient.PostAsync("https://localhost:44335/cliente/salvarviaapi", new StringContent(json, Encoding.UTF8, "application/json")).Result;
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
                response = httpClient.DeleteAsync($"https://localhost:44335/cliente/remover?nome={nome}").Result;

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


        public void Atualizar(int idCliente, Cliente cliente)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            var viewModel = new
            {
                IdEncontrar = idCliente,
                Atualizar = cliente
            };

            try
            {
                var json = JsonConvert.SerializeObject(viewModel);
                //monta a request para a api;
                response = httpClient.PutAsync($"https://localhost:44335/cliente/atualizar", new StringContent(json, Encoding.UTF8, "application/json")).Result;

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
