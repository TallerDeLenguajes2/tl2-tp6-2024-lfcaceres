namespace AltaProductoPresupuesto
{
    public class AltaProductoPresupuestoViewModel
    {
        int idPresupuesto;
        List<Producto> listaProducto;
        PresupuestoDetalle detalle;

        public AltaProductoPresupuestoViewModel()
        {
        }
        public AltaProductoPresupuestoViewModel(int id, List<Producto> lista)
        {
            idPresupuesto = id;
            listaProducto = lista;
        }

        public List<Producto> ListaProducto { get => listaProducto; set => listaProducto = value; }
        public PresupuestoDetalle Detalle { get => detalle; set => detalle = value; }
        public int IdPresupuesto { get => idPresupuesto; set => idPresupuesto = value; }
    }
}