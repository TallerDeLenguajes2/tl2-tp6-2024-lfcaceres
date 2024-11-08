
public class PresupuestoDetalle
{
    List<Producto> producto;
    int cantidad;

    public PresupuestoDetalle()
    {
        Producto=new List<Producto>();
    }

    public int Cantidad { get => cantidad; set => cantidad = value; }
    public List<Producto> Producto { get => producto; set => producto = value; }

    public void CargaProducto(Producto prod)
    {
        Producto.Add(prod);
    }
}
