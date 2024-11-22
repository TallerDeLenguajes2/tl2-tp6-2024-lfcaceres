
using AspNetCoreGeneratedDocument;

public class PresupuestoDetalle
{
    Producto producto;
    int cantidad;

    public PresupuestoDetalle()
    {
        
    }

    public Producto Producto { get => producto; set => producto = value; }
    public int Cantidad { get => cantidad; set => cantidad = value; }

    public void CargaDetalle(Producto prod, int cant)
    {
        producto = prod;
        cantidad = cant;

    }
}
