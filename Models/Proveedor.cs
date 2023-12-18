using System.ComponentModel.DataAnnotations;

namespace CJPWASM.Models
{
    public class Proveedor
    {
        
        public int Id { get; set; }
        public string? RazonSocial { get; set; }
        [StringLength(11, ErrorMessage = "RUC debe tener 11 dígitos")]
        public string? RUC { get; set; }
        public string? NombreProveedor { get; set; }
        [Phone(ErrorMessage ="Teléfono no es válido")]
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        [EmailAddress(ErrorMessage = "Teléfono no es válido")]
        public string? Email { get; set; }
        //public bool? EstadoEntidad { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public List<Compra>? Compras { get; set; }
    }
}
