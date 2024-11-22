using Microsoft.AspNetCore.Routing.Constraints;
using AltaPresupuesto;
using claseCliente;
public class Presupuesto
{
    int idPresupuesto;
    Cliente clientes;
    List<PresupuestoDetalle> detalle;
    const double IVA = 0.21;

    public Presupuesto()
    {
        detalle = new List<PresupuestoDetalle>();
    }

    public Presupuesto(int id, Cliente cli)
    {
        IdPresupuesto = id;
        clientes = cli;
        detalle = new List<PresupuestoDetalle>();
    }
    public Presupuesto( int idclien)
    {
        clientes = new Cliente(idclien);
        detalle = new List<PresupuestoDetalle>();
    }
    public int IdPresupuesto { get => idPresupuesto; set => idPresupuesto = value; }

    public List<PresupuestoDetalle> Detalle { get => detalle; }
    public Cliente Clientes { get => clientes; set => clientes = value; }

    public void AgregaProducto(Producto prod, int Cantidad)
    {
        PresupuestoDetalle pd = new PresupuestoDetalle();
        pd.CargaDetalle(prod,Cantidad);
        detalle.Add(pd);
    }
    public void AgregarCliente(Cliente c)
    {
        Clientes = c;
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
        return MontoPresupuesto() * IVA;
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