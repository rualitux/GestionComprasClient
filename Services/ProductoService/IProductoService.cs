using CJPWASM.Models;

namespace CJPWASM.Services.ProductoService
{
    public interface IProductoService
    {
        List<Producto> Productos { get;set; }
        Task GetProductos();
        Task<Producto> GetProductoById(int id);
        Task CreateProducto (Producto producto);
        Task UpdateProducto (Producto producto);

        
    }
}
