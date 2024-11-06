

public interface IProductoRepostory
{
    //● Crear un nuevo Producto. (recibe un objeto Producto)
    public void CrearNuevo(Producto prod);
    //● Modificar un Producto existente. (recibe un Id y un objeto Producto)
    public void ModificarProducto(int id, Producto prod);
    //● Obtener detalles de un Productos por su ID. (recibe un Id y devuelve un Producto)
    public Producto ObtenerProductoPorID(int id);
    //● Listar todos los Productos registrados. (devuelve un List de Producto)
    public List<Producto> ListarProducto();
    //● Eliminar un Producto por ID
    public void EliminarProducto(int id);


}