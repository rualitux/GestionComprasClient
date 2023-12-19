namespace CJPWASM.Models
{
    public class Inventario
    {
        public int Id { get; set; }
        public string? Estructura { get; set; } //Eg: Caja?? SixPack?? Saco 20 KG???
        public decimal? MultiplicadorUnidad { get; set; } = 1; //Caja de 6 unidades? Saco de 20.0 kg?
        public decimal? EstructuraCantidad { get; set; } //Cuantas cajas
        public decimal? Stock { get; set; }
        public int? ProductoId { get; set; }
        public int? AreaId { get; set; }
        public DateTime? FechaExpiracion { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public String? Lote { get; set; }

    }
}
