using CJPWASM.Models;

namespace CJPWASM.Services.CompraService
{
    public interface ICompraService
    {
        List<Compra> Compras { get; set; }
        Task GetCompras();
        Task<Compra> GetCompraById(int id);
        Task CreateCompra(Compra compra);
        Task UpdateCompra(Compra compra);
    }
}
