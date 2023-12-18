using CJPWASM.Models;

namespace CJPWASM.Services.ProveedorService
{
    public interface IProveedorService
    {
        List<Proveedor> Proveedors { get; set; }
        List<Compra> Compras { get; set; }
        Task GetProveedores();
        Task GetCompras();
        Task<Proveedor> GetProveedor(int id);
        Task CreateProveedor(Proveedor proveedor);
        Task UpdateProveedor(Proveedor proveedor);

    }
}
