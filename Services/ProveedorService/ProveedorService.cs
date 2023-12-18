using CJPWASM.Models;
using Microsoft.AspNetCore.Components;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CJPWASM.Services.ProveedorService
{
    public class ProveedorService : IProveedorService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAddress;
        private readonly string _url;
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        private readonly NavigationManager _navigationManager;

        public ProveedorService(HttpClient httpClient, NavigationManager navigationManager)
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
            _navigationManager=navigationManager;
        }
        public List<Proveedor> Proveedors { get; set; } = new List<Proveedor>();
        public List<Compra> Compras { get; set; } = new List<Compra>();

        public async Task CreateProveedor(Proveedor proveedor)
        {
            var result = await _httpClient.PostAsJsonAsync($"{_url}/proveedors/", proveedor);
            //var response = await result.Content.ReadFromJsonAsync<List<Proveedor>>();
            //Proveedors = response;
            await SetProveedores(result);
        }

        public Task GetCompras()
        {
            throw new NotImplementedException();
        }

        public async Task<Proveedor> GetProveedor(int id)
        {
            //try { 
            //HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/proveedors/{id}");
            //if (response.IsSuccessStatusCode)
            //{
            //        Console.WriteLine($"Entro a IsSuccesful: {response.StatusCode}");
            //        string content = await response.Content.ReadAsStringAsync();
            //         Console.WriteLine(content);
            //        try
            //        {
            //            var item = JsonSerializer.Deserialize<Proveedor>(content, _jsonSerializerOptions);
            //            Console.WriteLine($"enServiceLuegoDeserializada:{item.RUC}");
            //            return item;
            //        }
            //        catch (Exception ex)
            //        {
            //            Console.WriteLine(ex.Message);                        
            //        }        

            //}
            //else
            //{
            //        Console.WriteLine("Sin respusta 2XX");
            //}
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Exception: {ex.Message} ");
            //}
            //return null;
            try
            {
                var odataQuery = "?$expand=Compras($expand=CompraDetalles($expand=Producto))";
                var result = await _httpClient.GetFromJsonAsync<List<Proveedor>>($"{_url}/proveedors/{id}/{odataQuery}", _jsonSerializerOptions);
                var singleResult = result[0];
                if (result != null)
                {
                    await Console.Out.WriteLineAsync($"Result no es null con RUC{singleResult.RUC}");
                    return singleResult;
                }
            }
            catch (Exception ex)
            {

                await Console.Out.WriteLineAsync($"nuevaEx{ex.Message}"); 
            }
          
            throw new Exception("No hay proveedor???");
        }

        public async Task GetProveedores()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Proveedor>>($"{_url}/proveedors", _jsonSerializerOptions);
            if (result !=null)
            {
                foreach (var item in result)
                {                  
                    await Console.Out.WriteLineAsync(JsonSerializer.Serialize<Proveedor>(item));
                }
                Proveedors = result;
            }
        }

        public async Task UpdateProveedor(Proveedor proveedor)
        {
            var result = await _httpClient.PutAsJsonAsync($"{_url}/proveedors/{proveedor.Id}", proveedor);
            await SetProveedores(result);

        }

        private async Task SetProveedores(HttpResponseMessage result)
        {
            try
            {
                var response = await result.Content.ReadFromJsonAsync<List<Proveedor>>();
                Proveedors = response;
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
            _navigationManager.NavigateTo("proveedors");
        }
    }
}
