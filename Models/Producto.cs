using System.ComponentModel.DataAnnotations;

namespace CJPWASM.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Presentacion { get; set; }

        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Precio debe tener máximo 2 decimales")]
        public decimal? CostoEstandar { get; set; }
        public int? CategoriaId { get; set; } = 16;
        public Enumerado? Categoria { get; set; }
        public int? UnidadMedidaId { get; set; } = 27;
        public Enumerado? UnidadMedida { get; set; }
        public decimal? StockTotal { get; set; }
        //public int? StockTotal
        //{
        //    get
        //    {
        //        //Evita que crashee cuando hay un producto nuevo sin Inventario desde NuevaCompra
        //        if (Inventarios != null)
        //        {
        //            int? SumaTotal = 0;
        //            foreach (Inventario inventario in Inventarios)
        //            {
        //                SumaTotal += inventario.Stock;
        //            }
        //            return SumaTotal;
        //        }
        //        return null;
        //    }
        //}
        public decimal? StockMinimo { get; set; }
        public string? EstadoStock { get; set; }
        //public string? EstadoStock
        //{
        //    get
        //    {
        //        if (StockTotal != null)
        //        {
        //            if (StockTotal < StockMinimo)
        //                return "Stock Bajo";
        //            return "Stock Regular";
        //        }
        //        return null;
        //    }
        //}
        public List<Inventario>? Inventarios { get; set; }
        public List<CompraDetalle>? CompraDetalles { get; set; }

    }
}
