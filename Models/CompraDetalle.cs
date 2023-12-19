using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CJPWASM.Models
{
    public class CompraDetalle
    {
        public int Id { get; set; }
        public string? Estructura { get; set; } //Eg: Caja?? SixPack?? Saco 20 KG???
        public decimal? MultiplicadorUnidad { get; set; } = 1; //Caja de 6 unidades? Saco de 20.0 kg?

        public decimal? CantidadOrdenada { get; set; }
        public decimal? CantidadRecibida { get; set; }
        public decimal? CantidadRetornada { get; set; }
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Precio debe tener máximo 2 decimales")]
        public Decimal? CostoActual { get; set; }
        public Decimal? SubTotalOrdenado { get; set; }
        //public Decimal? SubTotalOrdenado
        //{
        //    get { return CostoActual * CantidadOrdenada; }
        //}
        public Decimal? SubTotalDiferencia { get; set; }
        //{
        //    get { return DiferenciaPrecio * CantidadRecibida; }
        //}
        public Decimal? SubTotalRecibido { get; set; }
        public Decimal? CostoRetornado { get; set; }

        //Decimal? _PrecioProducto
        //{
        //    get
        //    {
        //        if (Producto == null)
        //        {
        //            return 0;
        //        }
        //        return Producto.CostoEstandar;
        //    }
        //    set
        //    {
        //        if (_PrecioProducto != null)
        //            _PrecioProducto = value;
        //    }
        //}

        //private Decimal? PrecioProducto
        //{
        //    get => _PrecioProducto;
        //    set
        //    {
        //        if (_PrecioProducto == value)
        //        {
        //            return;
        //        }
        //        if (Producto != null)
        //        { _PrecioProducto = Producto.CostoEstandar; }
        //    }
        //}


        public Decimal? DiferenciaPrecio { get; set; }
        //{
        //    get
        //    {
        //        return CostoActual - _PrecioProducto;
        //    }
        //    set
        //    {
        //        if (_PrecioProducto != null)
        //        { return; }
        //        DiferenciaPrecio = value;
        //    }
        //}
        //public string? ProductoString
        //{
        //    get
        //    {
        //        if (Producto == null)
        //        {
        //            return null;
        //        }
        //        return Producto.Nombre;
        //    }
        //    set
        //    {
        //        if (ProductoString != null)
        //            ProductoString = value;
        //    }
        //}

        public string? EstadoAhorroItem { get; set; }
        //{
        //    get
        //    {
        //        if (SubTotalDiferencia != null)
        //        {
        //            if (SubTotalDiferencia >= 0)
        //                return "Gasto";
        //            return "Ahorro";
        //        }
        //        return null;
        //    }
        //}
        public DateTime? FechaExpiracion { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public String? Lote { get; set; }
        public int? CompraId { get; set; }
        [ForeignKey("ProductoId")]
        public int? ProductoId { get; set; }
        [JsonIgnore]
        public Producto? Producto { get; set; }
    }
}
