using Microsoft.AspNetCore.Routing.Constraints;

public class Presupuesto
{
    int idPresupuesto;
    string nombre;
    List<PresupuestoDetalle> detalle;
    const double IVA = 0.21;

    public Presupuesto()
    {
        detalle = new List<PresupuestoDetalle>();
    }

    public int IdPresupuesto { get => idPresupuesto; set => idPresupuesto = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public List<PresupuestoDetalle> Detalle { get => detalle;  }


    public void AgregaProducto(Producto prod,int Cantidad)
    {
        PresupuestoDetalle pd =new PresupuestoDetalle();
        pd.CargaProducto(prod);
        pd.Cantidad=Cantidad;
        detalle.Add(pd);
    }
    public double MontoPresupuesto()
    {
        int sumador = 0;
        foreach (var d in Detalle)
        {
            sumador = d.Producto.Precio + sumador;
        }
        return sumador;
    }
    public double MontoPresupuestoConIva()
    {
        return MontoPresupuesto()*IVA;
    }
    public int CantidadProductos()
    {
        int sumador = 0;
        foreach (var d in Detalle)
        {
            sumador = d.Cantidad + sumador;
        }
        return sumador;
    }

}