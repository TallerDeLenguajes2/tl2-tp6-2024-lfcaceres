using claseCliente;
public interface IClienteRepository
{
    public void CrearNuevo(Cliente client);
    public void ModificarCliente(int id, Cliente client);
    public List<Cliente> ListarCliente();
    public void EliminarCliente(int id);
}