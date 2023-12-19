using CJPWASM.Models;
using CJPWASM.Pages;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CJPWASM.Services.CompraService
{
    public class CompraService : ICompraService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAddress;
        private readonly string _url;
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        private readonly NavigationManager _navigationManager;

        public CompraService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _baseAddress = "https://localhost:7213";
            _url = $"{_baseAddress}/api";
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,

                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                //ReferenceHandler = ReferenceHandler.Preserve,             
                PropertyNameCaseInsensitive = true,
                WriteIndented = true

            };
            _navigationManager = navigationManager;

        }
        public List<Compra> Compras { get; set; } = new List<Compra>();
        public Task CreateCompra(Compra compra) 
        {
            throw new NotImplementedException();
        }

        public async Task<Compra> GetCompraById(int id)
        {
            try
            {
                var odataQuery = "?$Expand=Proveedor";
                var result = await _httpClient.GetFromJsonAsync<List<Compra>>($"{_url}/compras/{id}/{odataQuery}", _jsonSerializerOptions);
                var singleResult = result[0];
                if (result != null)
                {
                    await Console.Out.WriteLineAsync($"Result no es null con Nombre{singleResult.NumeroReferencia}");
                    return singleResult;
                }
            }
            catch (Exception ex)
            {

                await Console.Out.WriteLineAsync($"nuevaEx{ex.Message}");
            }

            throw new Exception("No hay item???");
        }

        public async Task GetCompras()
        {
            var odataQuery = "?$Expand=Proveedor";
            var result = await _httpClient.GetFromJsonAsync<List<Compra>>($"{_url}/compras/{odataQuery}", _jsonSerializerOptions);
            if (result != null)
            {
                foreach (var item in result)
                {
                    await Console.Out.WriteLineAsync(JsonSerializer.Serialize<Compra>(item));
                }
                Compras = result;
            }
        }

        public Task UpdateCompra(Compra compra)
        {
            throw new NotImplementedException();
        }
    }
}
