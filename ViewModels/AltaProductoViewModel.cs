using System.ComponentModel.DataAnnotations;

namespace AltaProducto
{
    public class AltaProductoViewModel
    {
        string? descripcion;
        int precio;

        public AltaProductoViewModel()
        {
        }

        public AltaProductoViewModel(Producto p)
        {
            descripcion = p.Descripcion;
            precio = p.Precio;
        }

        public AltaProductoViewModel(string Desc, int Pre)
        {
            descripcion = Desc;
            precio = Pre;
        }

        [StringLength(10,ErrorMessage = "Error Maximos caracteres 10")]
        public global::System.String Descripcion { get => descripcion; set => descripcion = value; }
        
        [Required(ErrorMessage = "El precio es obligatorio.")]
        [Range(1, double.MaxValue, ErrorMessage = "El precio debe ser un valor positivo.")]
        public global::System.Int32 Precio { get => precio; set => precio = value; }
    }
}