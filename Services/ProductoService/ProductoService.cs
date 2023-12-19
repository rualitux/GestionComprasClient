using CJPWASM.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Text.Json;
using CJPWASM.Pages;
using System.Net.Http.Json;

namespace CJPWASM.Services.ProductoService
{
    public class ProductoService : IProductoService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAddress;
        private readonly string _url;
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        private readonly NavigationManager _navigationManager;

        public ProductoService(HttpClient httpClient, NavigationManager navigationManager)
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
        public List<Producto> Productos { get; set; } = new List<Producto>();
        public List<Enumerado> Categorias { get; set; } = new List<Enumerado>();
        public List<Enumerado> UnidadMedidas { get; set; } = new List<Enumerado>();

        public async Task CreateProducto(Producto producto)
        {
            var result = await _httpClient.PostAsJsonAsync($"{_url}/productos/", producto);
            await SetProductos(result);
        }

        public async Task GetEnumerados()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Enumerado>>($"{_url}/enumerados", _jsonSerializerOptions);
            List<Enumerado> categoriasLista = new List<Enumerado>();
            List<Enumerado> unidadMedidaLista = new List<Enumerado>();
            foreach (var item in result)               
                {
                if (item.Padre == (int)EnumeradoTipo.Categoria)
                {
                    await Console.Out.WriteLineAsync(JsonSerializer.Serialize<Enumerado>(item));
                    categoriasLista.Add(item);
                }
                if (item.Padre == (int)EnumeradoTipo.UnidadMedida)
                {
                    await Console.Out.WriteLineAsync(JsonSerializer.Serialize<Enumerado>(item));
                    unidadMedidaLista.Add(item);
                }
            }
            Categorias = categoriasLista;
            UnidadMedidas = unidadMedidaLista;
        }

        public async Task<Producto> GetProductoById(int id)
        {
            try
            {
                //var odataQuery = "?$expand=Compras($expand=CompraDetalles($expand=Producto))";
                var result = await _httpClient.GetFromJsonAsync<List<Producto>>($"{_url}/productos/{id}", _jsonSerializerOptions);
                var singleResult = result[0];
                if (result != null)
                {
                    await Console.Out.WriteLineAsync($"Result no es null con Nombre{singleResult.Nombre}");
                    return singleResult;
                }
            }
            catch (Exception ex)
            {

                await Console.Out.WriteLineAsync($"nuevaEx{ex.Message}");
            }

            throw new Exception("No hay item???");
        }

        public async Task GetProductos()
        {
            var odataQuery = "?$expand=Categoria,UnidadMedida,CompraDetalles,Inventarios";
            var result = await _httpClient.GetFromJsonAsync<List<Producto>>($"{_url}/productos/{odataQuery}", _jsonSerializerOptions);
            if (result != null)
            {
                foreach (var item in result)
                {
                    await Console.Out.WriteLineAsync(JsonSerializer.Serialize<Producto>(item));
                }
                Productos = result;
            }
        }

        public async Task UpdateProducto(Producto producto)
        {
            var result = await _httpClient.PutAsJsonAsync($"{_url}/productos/{producto.Id}", producto);
            await SetProductos(result);
        }

        private async Task SetProductos(HttpResponseMessage result)
        {
            try
            {
                var response = await result.Content.ReadFromJsonAsync<List<Producto>>();
                Productos = response;
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
            _navigationManager.NavigateTo("productos");
        }

        enum EnumeradoTipo
        { 
            Categoria = 1,
            UnidadMedida=26
        }

    }
}
