
using Encrypt.Net.Text; // dotnet add package Encrypt.Net
using Microsoft.Data.Sqlite;

public class UsuarioRepository : IUsuarioRepository
{
    private string connectionString = "Data Source=db/Tienda.db";

    public UsuarioRepository()
    {
        
    }

    public Usuario GetUser(string username, string password)
    {
        Usuario user = null;

        string query = @"SELECT * FROM Usuarios WHERE Usuario = @username AND  Password = @contra ";

        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            SqliteCommand command = new SqliteCommand(query,connection);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@contra", password);
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    user = new Usuario();
                    user.Id = Convert.ToInt32(reader["Id"]);
                    user.Nombre = reader["Nombre"].ToString();
                    user.Username = reader["Usuario"].ToString();
                    user.Password = reader["Password"].ToString();
                    if(reader["Rol"].ToString() == "Admin")
                        user.AccessLevel = AccessLevel.Admin;
                    else
                        user.AccessLevel = AccessLevel.Cliente;
                }

            }
            connection.Close();            
        }
        return user;
    }

    public void AltaUsuario(Usuario usuario)
    {
        string query = @"INSERT INTO Usuarios (Nombre, Usuario, Password, Rol) VALUES (@nombre, @usu, @contra, @rol)";

        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            SqliteCommand command = new SqliteCommand(query,connection);
            command.Parameters.AddWithValue("@nombre", usuario.Nombre);
            command.Parameters.AddWithValue("@usu", usuario.Username);
            command.Parameters.AddWithValue("@contra", Cifrado.sha256(usuario.Password).Hash);
            command.Parameters.AddWithValue("@rol", usuario.AccessLevel);
            command.ExecuteNonQuery();
            connection.Close();            
        }

    }

}