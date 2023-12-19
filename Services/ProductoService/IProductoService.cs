using CJPWASM.Models;

namespace CJPWASM.Services.ProductoService
{
    public interface IProductoService
    {
        List<Producto> Productos { get;set; }
        List<Enumerado> Categorias { get; set; }
        List<Enumerado> UnidadMedidas { get; set; }
        Task GetProductos();
        Task GetEnumerados();
        Task<Producto> GetProductoById(int id);
        Task CreateProducto (Producto producto);
        Task UpdateProducto (Producto producto);

        
    }
}
