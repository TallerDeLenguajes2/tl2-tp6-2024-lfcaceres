using Microsoft.Data.Sqlite;
using claseCliente;
public class ClienteRepository :  IClienteRepository
{
    //private string cadenaConexion = "Data Source=db/Tienda.db";
    private readonly string connectionString;
    public ClienteRepository(string CadenaDeConexion)
    {
        connectionString = CadenaDeConexion;
    }

    public void CrearNuevo(Cliente client)
    {
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            var query = "INSERT INTO Clientes (Nombre, Email, Telefono) VALUES (@Nombre, @Email, @Telefono)";
            connection.Open();
            var command = new SqliteCommand(query, connection);
            command.Parameters.Add(new SqliteParameter("@Nombre", client.Nombre));
            command.Parameters.Add(new SqliteParameter("@Email", client.Email));
            command.Parameters.Add(new SqliteParameter("@Telefono", client.Telefono));
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
    public void ModificarCliente(int id, Cliente client)
    {
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            var query = "UPDATE Clientes SET Nombre = @NuevoNombre, Email = @NuevoEmail, Telefono = @NuevoTelefono WHERE ClienteId = @id";
            connection.Open();
            var command = new SqliteCommand(query, connection);
            command.Parameters.Add(new SqliteParameter("@NuevoNombre", client.Nombre));
            command.Parameters.Add(new SqliteParameter("@NuevoEmail", client.Email));
            command.Parameters.Add(new SqliteParameter("@NuevoTelefono", client.Email));
            command.Parameters.Add(new SqliteParameter("@id", id));
            command.ExecuteNonQuery();
            connection.Close();
        }
    }

    public List<Cliente> ListarCliente()
    {
        List<Cliente> listaClient = new List<Cliente>();
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            string query = "SELECT * FROM Clientes;";
            SqliteCommand command = new SqliteCommand(query, connection);
            connection.Open();
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var Cli = new Cliente();
                    Cli.ClienteId = Convert.ToInt32(reader["ClienteId"]);
                    Cli.Nombre = reader["Nombre"].ToString();
                    Cli.Email = reader["Email"].ToString();
                    Cli.Telefono = reader["Telefono"].ToString();
                    listaClient.Add(Cli);
                }
            }
            connection.Close();

        }
        return listaClient;
    }

    public void EliminarCliente(int id)
    {
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            string query = @"DELETE FROM Clientes WHERE ClienteId = @id;";
            connection.Open();
            SqliteCommand command = new SqliteCommand(query, connection);
            command.Parameters.Add(new SqliteParameter("@id", id));
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}