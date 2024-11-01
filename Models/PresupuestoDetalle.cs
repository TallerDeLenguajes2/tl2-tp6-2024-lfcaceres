
public class PresupuestoDetalle
{
    Producto producto;
    int cantidad;

    public PresupuestoDetalle()
    {
        producto=new Producto();
    }

    public int Cantidad { get => cantidad; set => cantidad = value; }
    public Producto Producto { get => producto; }

    public void CargaProducto(Producto prod)
    {
        producto=prod;
    }
}
