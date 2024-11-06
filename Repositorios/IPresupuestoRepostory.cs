public interface IPresupuestoRepostory
{
    //● Crear un nuevo Presupuesto. (recibe un objeto Presupuesto)
    public void CrearNuevo(Presupuesto pres);
    //● Obtener detalles de un Presupuesto por su ID. (recibe un Id y devuelve un Presupuesto)
    public Presupuesto ObtenerDetallePorID(int id);
    //● Permite agregar un Producto existente y una cantidad al presupuesto.
    public bool AgregarProducto(int id, Producto prod, int cant);
    //● Listar todos los Presupuestos registrados. (devuelve un List de Presupuestos)
    public List<Presupuesto> ListarPresupuestos();
    //● Eliminar un Presupuesto por ID
    public void EliminarPresupuesto(int id);





}